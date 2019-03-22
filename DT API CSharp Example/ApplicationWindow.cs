
namespace DT_API_CSharp_Example
{
	public partial class ApplicationWindow : System.Windows.Forms.Form
	{
		public ApplicationWindow() { InitializeComponent(); }

		private readonly System.Net.Http.HttpClient HTTPClient	= new System.Net.Http.HttpClient();
		private string LookupKey								= null;
		private string AccountKey								= null;

		private void Reset(bool ChangeResponse = true)
		{
			this.LookupKey = null;
			this.AccountKey = null;
			this.RequestUserAuth_btn.Enabled = true;
			this.CheckAuthStatus_btn.Enabled = false;
			this.ProfileLookup_btn.Enabled = false;
			this.Deauth_btn.Enabled = false;

			if (ChangeResponse)
				this.Response_txt.Text = "Reset";
		}


		private void ResetBtn_Click(object sender, System.EventArgs e) => this.Reset(true);

		private async System.Threading.Tasks.Task<System.Xml.XmlDocument> DonutTeamAPI(string Endpoint, string Path)
		{
			System.Net.Http.HttpResponseMessage Response = null;

			try
			{
				Response = await this.HTTPClient.GetAsync(this.Domain_txt.Text + "/" + Endpoint + ".xml/" + Path);
			}
			catch (System.Net.Http.HttpRequestException Exception)
			{
#if DEBUG
				throw Exception;
#else
				System.Windows.Forms.MessageBox.Show("Unsuccessful", "Response Fail", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return;
#endif
			}

			string ResponseTxt = await Response.Content.ReadAsStringAsync();
			this.Response_txt.Text = ResponseTxt;

			System.Xml.XmlDocument Data = new System.Xml.XmlDocument();

			try
			{
				Data.LoadXml(ResponseTxt);
			}
			catch (System.Xml.XmlException Exception)
			{
#if DEBUG
				throw Exception;
#else
				System.Windows.Forms.MessageBox.Show("Response not XML document", "Response Fail", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return;
#endif
			}

			System.Xml.XmlNodeList Errors = Data.GetElementsByTagName("ErrorText");
			foreach (System.Xml.XmlNode Error in Errors)
			{
				System.Windows.Forms.MessageBox.Show(Error.InnerText, "API Call Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}

			return Data;
		}

		private async void RequestUserAuth_btn_ClickAsync(object sender, System.EventArgs e)
		{
			this.Reset(true);

			System.Xml.XmlDocument Response = await this.DonutTeamAPI("RequestAuthentication", this.AppKey_txt.Text);

			System.Xml.XmlNode CodeNode = Response.SelectSingleNode("//Code");
			if (CodeNode == null)
				return;

			this.LookupKey = CodeNode.InnerText;

			System.Xml.XmlNode LinkNode = Response.SelectSingleNode("//Link");
			if (LinkNode != null)
				System.Diagnostics.Process.Start(LinkNode.InnerText);
			else
				System.Diagnostics.Debugger.Break();

			this.RequestUserAuth_btn.Enabled = false;
			this.CheckAuthStatus_btn.Enabled = true;
		}

		private async void CheckAuthStatus_btn_Click(object sender, System.EventArgs e)
		{
			System.Xml.XmlDocument Response = await this.DonutTeamAPI("CheckAuthenticateToken", this.AppKey_txt.Text + "/" + this.LookupKey);

			int HasSessionToken = Response.GetElementsByTagName("SessionToken").Count;
			if (HasSessionToken == 1)
			{
				this.AccountKey = Response.GetElementsByTagName("SessionToken")[0].InnerText;
				this.ProfileLookup_btn.Enabled = true;
				this.CheckAuthStatus_btn.Enabled = false;
			}
		}

		private async void ProfileLookup_btn_Click(object sender, System.EventArgs e)
		{
			System.Xml.XmlDocument Response = await this.DonutTeamAPI("ProfileLookup", "session/" + this.AccountKey);

			int HasUserElement = Response.GetElementsByTagName("User").Count;
			if (HasUserElement == 1)
			{
				this.Deauth_btn.Enabled = true;
			}
		}
	}
}
