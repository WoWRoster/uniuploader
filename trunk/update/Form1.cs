// ----------------------------------------------
/*
 * @version    SVN: $Id: Form1.cs 1983 2009-05-17 22:01:05Z Calystos $
 * @link       http://www.wowroster.net
*/
// ----------------------------------------------

using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Threading;
using CommandLine.Utility;
using System.Data;
using System.Text;
using cs_IniHandlerDevelop;

// ----------------------------------------------

namespace update
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Timer timer1;  // Retry timer if UniUploader is still running
		private System.Windows.Forms.Timer timer2;  // Automatically press the Launch New Version button timer
		private System.ComponentModel.IContainer components;
		public string uuver = "";
		public string updver_major = "1";
		public string updver_minor = "4";
		public string updver_build = "6";
		public string updver_revision = "3";
		public int numChecks;
		public int numLaunchChecks = 0;  // autoLaunch timers initial counter number (Default 0)
		public int autoLaunchTimer = 30; // How long (in seconds) til the update.exe autoLaunches the new UniUploader (Default 30)
		public bool autoLaunch = false;  // We don't want the countdown timer to actually start til the download is complete
		private System.Windows.Forms.ListBox DebugBox;
		private System.Windows.Forms.Button saveas;
		private System.Windows.Forms.Button launchUU;
		//public string updver = "1.4.0";// REMEMBER THIS!!!
		public string UULanguage = "";
		IniStructure ini = new cs_IniHandlerDevelop.IniStructure();
		public string UpdatesURL = "";

// ----------------------------------------------

		public Form1(string UniVer, string UULang)
		{
			//
			// Required for Windows Form Designer support
			//
			uuver = UniVer;
			UULanguage = UULang;
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

// ----------------------------------------------

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

// ----------------------------------------------

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.DebugBox = new System.Windows.Forms.ListBox();
			this.saveas = new System.Windows.Forms.Button();
			this.launchUU = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Downloading New Version of UniUploader.";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 24);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(568, 16);
			this.progressBar1.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 16);
			this.label3.TabIndex = 2;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Enabled = true;
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// DebugBox
			// 
			this.DebugBox.HorizontalScrollbar = true;
			this.DebugBox.Location = new System.Drawing.Point(8, 56);
			this.DebugBox.Name = "DebugBox";
			this.DebugBox.Size = new System.Drawing.Size(568, 121);
			this.DebugBox.TabIndex = 3;
			// 
			// saveas
			// 
			this.saveas.Enabled = false;
			this.saveas.Location = new System.Drawing.Point(8, 184);
			this.saveas.Name = "saveas";
			this.saveas.Size = new System.Drawing.Size(128, 23);
			this.saveas.TabIndex = 4;
			this.saveas.Text = "Save Debug Log As ...";
			this.saveas.Click += new System.EventHandler(this.saveas_Click);
			// 
			// launchUU
			// 
			this.launchUU.Enabled = false;
			this.launchUU.Location = new System.Drawing.Point(456, 184);
			this.launchUU.Name = "launchUU";
			this.launchUU.Size = new System.Drawing.Size(120, 23);
			this.launchUU.TabIndex = 5;
			this.launchUU.Text = "Launch New Version";
			this.launchUU.Click += new System.EventHandler(this.launchUU_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 214);
			this.Controls.Add(this.launchUU);
			this.Controls.Add(this.saveas);
			this.Controls.Add(this.DebugBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(592, 248);
			this.MinimumSize = new System.Drawing.Size(592, 248);
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Updater";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
		}
		#endregion

// ----------------------------------------------

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] Args) 
		{
			Arguments CommandLine=new Arguments(Args);
			if (CommandLine["uuver"] != null)
			{
				Application.Run(new Form1(CommandLine["uuver"],CommandLine["lang"]));
				//Application.Run(new Form1("test","English"));
			}
			else
			{
					MessageBox.Show("Please run the update process from within UniUploader.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
			}
		}

// ----------------------------------------------

		private void Form1_Load(object sender, System.EventArgs e)
		{
			string updVerString = updver_major+"."+updver_minor+"."+updver_build+"."+updver_revision;
			DebugLine("Updater v"+updVerString+" started");
			DebugLine("Waiting for UniUploader to close before initiating download.");
		}

// ----------------------------------------------

		public void timer2_Tick(object sender, System.EventArgs e)
		{
			if (numLaunchChecks <= autoLaunchTimer)
			{
				if (autoLaunch) { numLaunchChecks++; }  // Only increment the counter if we have actually finished the download
			}
			else
			{
				if (!autoLaunch) { return; }  // If we haven't actually finished the download yet then break and continue
				timer2.Stop();
				timer2.Enabled = false;
				numLaunchChecks = 0;
				DebugLine("Automatically launching new UniUploader version.");
				string UUPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","");
				System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(UUPath+"\\UniUploader.exe");
				System.Diagnostics.Process.Start(start);
				this.Close();
			}
		}

// ----------------------------------------------

		public void updateNOW()
		{
			ReadSettings();
			string UpdateQueryResponse = "";
			UpdateQueryResponse = RetrData(UpdatesURL,null,null,"OPERATION","GETLATEST","LANGUAGE",UULanguage,null,null,20000);
			string fileName = GetfileNameFromURI(UpdateQueryResponse);
			string FileLocalLocation = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","")+@"\"+fileName;
			DebugLine("Downloading ["+UpdateQueryResponse+"]");
			download(UpdateQueryResponse,FileLocalLocation);
			DebugLine("New UniUploader.exe downloaded, Please press the \"Launch New Version\" Button.");
			DebugLine("System will automatically launch new version after "+autoLaunchTimer+" seconds.");
			launchUU.Enabled = true;

			numLaunchChecks = 0;
			timer2.Enabled = true;
			timer2.Start();

			this.Show();
			this.TopLevel = true;
			this.WindowState = FormWindowState.Normal;
			this.Activate() ;
			this.TopMost = true;

			//System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(FileLocalLocation);
			//System.Diagnostics.Process.Start(start);
			//this.Close();
		}

// ----------------------------------------------

		string GetfileNameFromURI (string uri)
		{
			//string[] splitUri = new string[];
			char[] sep = {'/'};
			string[] splitUri;
			splitUri = uri.Split(sep);
			return splitUri[splitUri.Length - 1];
		}
	
// ----------------------------------------------

		public string RetrData(string url, CookieContainer cookies, CredentialCache credentials, string param1, string val1, string param2, string val2, string param3, string val3, int Timeout) 
		{
			// Initialize the request object
			HttpWebRequest req = (WebRequest.Create(url) as HttpWebRequest);
			if (cookies != null) req.CookieContainer = cookies;
			if (credentials != null) req.Credentials = credentials;

			string boundary = Guid.NewGuid().ToString().Replace("-", "");
			req.ContentType = "multipart/form-data; boundary=" + boundary;
			req.Method = "POST";
			req.UserAgent = "UniUploader "+updver_major + ".0 (UU " + updver_major+ "." + updver_minor + "." + updver_build + "." + updver_revision + "; " + UULanguage+")";
			if (Timeout > 0)
			{
				req.Timeout = Timeout;
			}
			MemoryStream postData = new MemoryStream();
			string newLine = "\r\n";
			StreamWriter sw = new StreamWriter(postData);

			if (param1 != null)
			{
				sw.Write("--" + boundary + newLine);
				sw.Write("Content-Disposition: form-data; name=\""+param1+"\";" , newLine); //param1-4 val1-4
				sw.Write("Content-Type: text/html" + newLine + newLine);
				sw.Flush();
				sw.Write(val1);
				sw.Write(newLine);
			}
			if (param2 != null)
			{
				sw.Write("--" + boundary + newLine);
				sw.Write("Content-Disposition: form-data; name=\""+param2+"\";" , newLine); //param1-4 val1-4
				sw.Write("Content-Type: text/html" + newLine + newLine);
				sw.Flush();
				sw.Write(val2);
				sw.Write(newLine);
			}
			if (param3 != null)
			{
				sw.Write("--" + boundary + newLine);
				sw.Write("Content-Disposition: form-data; name=\""+param3+"\";" , newLine); //param1-4 val1-4
				sw.Write("Content-Type: text/html" + newLine + newLine);
				sw.Flush();
				sw.Write(val3);
				sw.Write(newLine);
			}
			sw.Write("--{0}--{1}", boundary, newLine);
			sw.Flush();

			try 
			{
				using (Stream s = req.GetRequestStream())
				{
					postData.WriteTo(s);
				}
				postData.Close();
			}
			catch (Exception e) 
			{
				DebugLine("Data Retrieval Error: "+e.Message);
			}
			string responseString = "";
			try 
			{
				WebResponse resp = req.GetResponse();
				StreamReader reader = new StreamReader(resp.GetResponseStream() );
				responseString = reader.ReadToEnd();
				reader.Close();
				resp.Close();
			}
			catch (Exception e) 
			{
				DebugLine("RetrData: "+e.Message);
			}
			sw.Close();
			postData.Close();

			DebugLine("");
			DebugLine("RetrData: url: " + url);
			if (param1 != null)
			{
				DebugLine("RetrData: param1: " + param1);
				DebugLine("RetrData: val1: " + val1);
			}
			if (param2 != null)
			{
				DebugLine("RetrData: param2: " + param2);
				DebugLine("RetrData: val2: " + val2);
			}
			if (param3 != null)
			{
				DebugLine("RetrData: param3: " + param3);
				DebugLine("RetrData: val3: " + val3);
			}
			DebugLine("RetrData: Timeout: " + Timeout);

			DebugLine("RetrData: ------------------------------------------------------------------------");
			DebugLines(responseString.Split(new Char[] {'\n'}));
			DebugLine("RetrData: ------------------------------------------------------------------------");
			DebugLine("");

			return (responseString);
		}

// ----------------------------------------------

		private bool download(string path_download, string path_local)
		{
			// Declare a variable of type Boolean named result initialized to false.
			bool result = false;
			// Declare a variable of type HttpWebRequest named lHttpWebRequest.
			HttpWebRequest lHttpWebRequest;
			// Declare a variable of type HttpWebResponse named lHttpWebResponse.
			HttpWebResponse lHttpWebResponse;
			// Declare a variable of type Stream named lHttpWebResponseStream.
			Stream lHttpWebResponseStream;
			// Declare a variable of type FileStream named lFileStream.
			// Use a FileStream constructor to create a new FileStream object.
			// Assign the address (reference) of the new object
			// to the lFileStream variable.
			FileStream lFileStream = new FileStream(path_local, FileMode.Create);
			// Declare a variable of type Byte Array named byteBuffer.
			byte[] byteBuffer = new byte[999];
			// Declare a variable of type Integer named bytesRead.
			int bytesRead;
			try
			{
				// Instantiate the HttpWebRequest object.
				lHttpWebRequest = (HttpWebRequest)WebRequest.Create(path_download);
				lHttpWebRequest.Timeout = 20000;
				// Instantiate the HttpWebRespose object.
				lHttpWebResponse = (HttpWebResponse)lHttpWebRequest.GetResponse();
				// Instantiate the ResponseStream object.
				lHttpWebResponseStream = lHttpWebRequest.GetResponse().GetResponseStream();
				// Set the ProgressBars Maximum property equal to the length of the file
				// to be downloaded.
				progressBar1.Maximum = Convert.ToInt32(lHttpWebResponse.ContentLength);
				// progress counter to control when
				// the form label is updated
				double progress_counter = 0;
				do
				{
					// Read up to 1000 bytes into the bytesRead array.
					bytesRead = lHttpWebResponseStream.Read(byteBuffer, 0, 999);
					// Write the bytes read to the file stream.
					lFileStream.Write(byteBuffer, 0, bytesRead);
					// If the ProgressBar's value plus bytesRead is less than the length of the file...
					if((progressBar1.Value + bytesRead) <= progressBar1.Maximum)
					{
						// Add bytesRead to the ProgressBar's Value property.
						progressBar1.Value += bytesRead;
					}
					else
					{
						// Else files download is done so set ProgressBar's Value to the length of the file.
						progressBar1.Value = progressBar1.Maximum;
					}
					// calculate the current percentage
					double progress_now = Math.Floor((double)((progressBar1.Value/100) * 100) / (progressBar1.Maximum/100));
					// only upgrade the display label once per percentage increment
					if(progress_now > progress_counter)
					{
						// Update the ProgressLabel.
						label3.Text = String.Format("{0}% of {1}kb", progress_now.ToString(), (progressBar1.Maximum/1000).ToString("#,#"));
						// update the form
						Application.DoEvents(); 
						// increment the counter
						progress_counter++;
					}
				}while(bytesRead > 0);
				// Close the file and web response streams.
				lHttpWebResponseStream.Close();
				// Set result to True - download was successful.
				result = true;
				// Make sure that the timer2 knows this download was completed.
				autoLaunch = true;
			}
			catch(Exception download_error)
			{
				// display the whole error
				MessageBox.Show(download_error.ToString());
			}
			finally
			{
				// Close the file and web response streams.
				lFileStream.Close();
			}
			return result;
		}

// ----------------------------------------------

		public void timer1_Tick(object sender, System.EventArgs e)
		{
			int windowHandle = Win32.FindWindow(null ,"UniUploader");
			if (numChecks <= 10)
			{
				if (windowHandle != 0)
				{
					DebugLine("UniUploader is still running, waiting for it to close ...");
					numChecks++;
				}
				else
				{
					timer1.Stop();
					timer1.Enabled = false;
					DebugLine("UniUploader window not found.");
					if (isUUWritable())
					{
						DebugLine("UniUploader.exe is now unlocked.");
						DebugLine("Commencing Upgrade.");
						startDownload();
					}
					else
					{
						DebugLine("UniUploader.exe is still Locked.");
						timer1.Enabled = true;
						timer1.Start();
					}
				}
			}
			else
			{
				timer1.Stop();
				timer1.Enabled = false;
				DebugLine("Waited 10 seconds for UniUploader to close. Forcing check.");
				if (isUUWritable())
				{
					DebugLine("UniUploader.exe is now unlocked.");
					DebugLine("Commencing Upgrade.");
					startDownload();
				}
				else
				{
					DebugLine("UniUploader.exe is still Locked.");
					timer1.Enabled = true;
					timer1.Start();
				}
			}
		}

// ----------------------------------------------

		public bool isUUWritable()
		{
			try
			{
				FileStream fs = new FileStream("UniUploader.exe", FileMode.OpenOrCreate,FileAccess.Write);
				if (fs.CanWrite)
				{
					fs.Close();
					return true;
				}
			}
			catch(Exception e)
			{
				return false;
			}
			return false;
		}

// ----------------------------------------------

		public void DebugLine(string Text)
		{
			string[] TextSplit =  Text.Split(new Char[] {'\n'});
			foreach (string line in TextSplit)
			{
				DebugBox.Items.Add("["+GetDateAndTime()+"] "+ line);
			}
			saveas.Enabled = true;
			int numLines = DebugBox.Items.Count;
			DebugBox.SelectedIndex = numLines - 1;
		}

// ----------------------------------------------

		public void DebugLines(string[] Text)
		{
			foreach (string line in Text)
			{
				DebugBox.Items.Add("["+GetDateAndTime()+"] "+ line);
			}
			int numLines = DebugBox.Items.Count;
			DebugBox.SelectedIndex = numLines - 1;
		}

// ----------------------------------------------

		public string GetDateAndTime()
		{
			return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
		}

// ----------------------------------------------

		private void saveas_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Text file|*.txt|Document|*.doc";
			saveFileDialog1.Title = "Save As ...";
			saveFileDialog1.ShowDialog(); 
			if(saveFileDialog1.FileName != "")
			{
				// Saves the Image via a FileStream created by the OpenFile method.
				System.IO.FileStream fs = 
					(System.IO.FileStream)saveFileDialog1.OpenFile();
				string[] DebugBoxArray = new string[DebugBox.Items.Count]; 
				DebugBox.Items.CopyTo(DebugBoxArray,0);
				string DebugString = "";
				foreach (string line in DebugBoxArray)
				{
					DebugString = DebugString + line + "\r\n";
				}
				System.Text.ASCIIEncoding  encoding=new System.Text.ASCIIEncoding();
				byte[] logByteArray = encoding.GetBytes(DebugString);
				fs.Write(logByteArray,0,logByteArray.Length);
				fs.Close();
			}
		}

// ----------------------------------------------

		private void startDownload()
		{
			timer1.Stop();
			timer1.Enabled=false;
			//timer2.Stop();
			//timer2.Enabled=false;
			numLaunchChecks = 0;
			ThreadStart job = new ThreadStart(updateNOW);
			Thread thread = new Thread(job);
			thread.Start();
		}

// ----------------------------------------------

		private void launchUU_Click(object sender, System.EventArgs e)
		{
			timer2.Stop();
			timer2.Enabled=false;
			numLaunchChecks = 0;
			string UUPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","");
			System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(UUPath+"\\UniUploader.exe");
			System.Diagnostics.Process.Start(start);
			this.Close();
		}

// ----------------------------------------------

		private string findSettingFile()
		{
			string thisAppDataPath = Application.ExecutablePath; // Application.UserAppDataPath;
			string versionContextPath = Path.GetFullPath(thisAppDataPath + "\\..");

			DirectoryInfo di = new DirectoryInfo(versionContextPath);

			ArrayList a = new ArrayList();
			foreach (DirectoryInfo di2 in di.GetDirectories())
			{
				if (di2.Name != "." && di2.Name != "..")
				{
					DirectoryInfo di3 = new DirectoryInfo(di2.FullName);
					foreach (FileInfo fi in di3.GetFiles())
					{
						if (fi.Name.ToLower() == "settings.ini")
						{
							Hashtable h = new Hashtable();
							h[fi.FullName] = fi.LastWriteTime;
							a.Add(h);
						}
					}
				}
			}
			string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
			di = new DirectoryInfo(exePath);
			foreach (FileInfo fi in di.GetFiles())
			{
				if (fi.Name.ToLower() == "settings.ini")
				{
					Hashtable h = new Hashtable();
					h[fi.FullName] = fi.LastWriteTime;
					a.Add(h);
				}
			}

			string key_i;
			DateTime val_i = new DateTime();
			string key_r;
			DateTime val_r = new DateTime();
			for (int i = 0; i < a.Count; i++)
			{
				for (int r = 0; r < a.Count; r++)
				{
					foreach (DictionaryEntry de in ((Hashtable)a[r]))
					{
						key_r = (string)de.Key;
						val_r = (DateTime)de.Value;
					}
					foreach (DictionaryEntry de in ((Hashtable)a[i]))
					{
						key_i = (string)de.Key;
						val_i = (DateTime)de.Value;
					}
					if (val_i.CompareTo(val_r) > 0)
					{
						Hashtable temp = (Hashtable)a[i];
						a[i] = a[r];
						a[r] = temp;
					}
				}
			}
			string outVal = "";
			if (a.Count > 0)
			{
				foreach (DictionaryEntry de in ((Hashtable)a[0]))
				{
					outVal = (string)de.Key;
				}
			}
			return outVal;
		}

// ----------------------------------------------

		private void ReadSettings()
		{
			string file = findSettingFile();
			try
			{
				if (File.Exists(file) == true)
				{
					ini = IniStructure.ReadIni(file);
					string[] allCategories = ini.GetCategories();
					string[] keys;
					foreach (string category in allCategories)
					{
						keys = ini.GetKeys(category);
						foreach (string key in keys)
						{
							string settingValue = ini.GetValue(category, key);
							bool settingValueBool;
							if (settingValue != "")
							{
								try
								{
									settingValueBool = Convert.ToBoolean(settingValue);
								}
								catch
								{
									settingValueBool = false;
								}
							}
							else
							{
								settingValueBool = false;
							}

							switch (key)
							{
								#region cases
								case "UPDATESURL":
									UpdatesURL = settingValue;
									break;
								case "AUTOLAUNCHTIMER":
									autoLaunchTimer = Convert.ToInt32(settingValue);
									break;
								#endregion
								default:
									break;
							}
						}
					}
				}
				else
				{
					//settings file doesn't exist yet, manually set the UpdatesURL thing with the defaults
					// UpdatesURL = "http://wowroster.net/uniuploader_updater2/update.php";
				}
			}
			catch (Exception e)
			{
				DebugLine("ReadSettings: " + e.Message);
				if (e.Message == "Object reference not set to an instance of an object.")
				{
					MessageBox.Show("Your settings file is somehow corrupted.\nPlease delete settings.ini or repair it.");
				}
				return;
			}
		}

// ----------------------------------------------

	}
}

// ----------------------------------------------
