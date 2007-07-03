using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Threading;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip;
using System.Management;
using Microsoft.Win32;
using System.Xml;
using System.Security.Cryptography;
using cs_IniHandlerDevelop;
using System.Globalization;
using System.Text.RegularExpressions; 

namespace WindowsApplication3
{
	///	<summary>
	///	uploader for "World of Warcraft" SavedVariables.lua files
	///	</summary>
	///	



	public class Form1 : System.Windows.Forms.Form
	{
		private	System.Windows.Forms.TextBox URL;
		private	System.Windows.Forms.Label label2;
		private	System.Windows.Forms.Button	UploadNow;
		private	System.Windows.Forms.Label label3;
		private	System.Windows.Forms.Label label1;
		private	System.Windows.Forms.Label version;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.CheckBox autoUploader;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel libLink;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.ComboBox AccountList;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage Settings;
		private System.Windows.Forms.TabPage Options;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox servResponse;
		private System.Windows.Forms.TabPage response;
		private System.Windows.Forms.GroupBox vargrp;
		private System.Windows.Forms.CheckBox arg1check;
		private System.Windows.Forms.CheckBox arg4check;
		private System.Windows.Forms.CheckBox arg3check;
		private System.Windows.Forms.CheckBox arg2check;
		private System.Windows.Forms.TextBox arrg1;
		private System.Windows.Forms.TextBox arrg4;
		private System.Windows.Forms.TextBox arrg3;
		private System.Windows.Forms.TextBox arrg2;
		public System.Windows.Forms.TextBox valu1;
		private System.Windows.Forms.TextBox valu3;
		private System.Windows.Forms.TextBox valu2;
		private System.Windows.Forms.TextBox valu4;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.TabPage About;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TabPage Help;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.TextBox addurl4;
		private System.Windows.Forms.TextBox addurl2;
		private System.Windows.Forms.TextBox addurl3;
		private System.Windows.Forms.TextBox addurl1;
		private System.Windows.Forms.CheckBox chaddurl2;
		private System.Windows.Forms.CheckBox chaddurl3;
		private System.Windows.Forms.CheckBox chaddurl1;
		private System.Windows.Forms.CheckBox chaddurl4;
		private System.Windows.Forms.TabPage Advanced;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox GZcompress;
		private System.Windows.Forms.CheckBox retrdatafromsite;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Button wowlaunch;
		private System.Windows.Forms.TextBox retrdatawindow;
		FileSystemWatcher watcher =	new	FileSystemWatcher();
		public bool IsUploading = false;
		public string windowstate = "starting";
		private System.Windows.Forms.Timer mini_timer;
		private System.Windows.Forms.Timer Upload_Timer; 
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.CheckBox delaych;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox DelaySecs;
		private System.Windows.Forms.Timer close_timer;
		public System.Timers.Timer myTimer;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label copyrightInfoLabel;
		public System.Timers.Timer myTimer2;
		
		private System.Windows.Forms.TabPage wowAddons;
		private System.Windows.Forms.CheckBox addonAutoUpdate;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.TextBox AutoAddonURL;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button autoAddonSyncNow;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.CheckBox uuSettingsUpdater;
		private System.Windows.Forms.CheckBox UUUpdaterCheck;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TabPage Debugger;
		private System.Windows.Forms.ListBox DebugBox;
		private System.Windows.Forms.Button debugSaveAs;
		private System.Windows.Forms.Button button5;
		IniStructure ini = new cs_IniHandlerDevelop.IniStructure();
		IniStructure LanguageIni = new cs_IniHandlerDevelop.IniStructure();
		private bool updating = false;
		private string uniVersionMajor = "2";
		private string uniVersionMinor = "6";
		private string uniVersionRevision = "8";
		private bool testVersion = true;
		private string UUuserAgent;
		private CookieContainer cookieJar = new CookieContainer();

		private string selectedAcc = "";
		private ArrayList allLangs = new ArrayList();

		private string wowExeLoc = "";
		private string wowExeLocBrowsed = "";

		private System.Windows.Forms.MenuItem downloadItem;
		private System.Windows.Forms.MenuItem homeLink = new MenuItem("Guild Website");
		private System.Windows.Forms.MenuItem forumLink = new MenuItem("Guild Forums");
		private string homeLinkURL = "";
		private string forumLinkURL = "";
		//this.UploadNow.Click += new System.EventHandler(this.button1_Click);
		private System.Windows.Forms.MenuItem installItem;

		private string mainSvLocation = ""; //location of SavedVariables.lua
		private System.Windows.Forms.Button Mode;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.ComboBox langselect;
		public string Language = "English";
		public string ProgramMode = "Advanced";

		public ThreadStart job;// = new ThreadStart(upload);
		public Thread UploadThread;// = new Thread(job);
		public ThreadStart acejob;// = new ThreadStart(upload);
		public Thread aceUploadThread;// = new Thread(job);
		public bool PathFound = false;
		private string[] checkedSVsFromSettings = null;
		private ArrayList checkedAddons = new ArrayList();
		private ArrayList availableAddons = new ArrayList();
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.CheckBox stwowlaunch;
		private System.Windows.Forms.CheckBox stmin;
		private System.Windows.Forms.CheckBox stboot;
		private System.Windows.Forms.TextBox retrDataUrl;
		private System.Windows.Forms.Button siteToWowSaveas;
		private System.Windows.Forms.Button servResponseSaveas;
		private System.Windows.Forms.Button ClearServResp;
		private System.Windows.Forms.Button ClearSiteWoW;
		private System.Windows.Forms.CheckBox exe1;
		private System.Windows.Forms.TextBox exe3Location;
		private System.Windows.Forms.Button exe3Browse;
		private System.Windows.Forms.CheckBox exe3;
		private System.Windows.Forms.TextBox exe2Location;
		private System.Windows.Forms.Button exe2Browse;
		private System.Windows.Forms.CheckBox exe2;
		private System.Windows.Forms.TextBox exe1Location;
		private System.Windows.Forms.Button exe1Browse;
		private System.Windows.Forms.RadioButton exeOnWowLaunch;
		private System.Windows.Forms.GroupBox otherexes;
		private System.Windows.Forms.RadioButton exeOnUuStart;
		public bool filesysDelay_enabled = false;
		public bool filesysDelay_flag1 = false;
		public string singleUpdateTmp = "";
		

		public string[] presets = {
									  "PvPLog",
									  "CharacterProfiler"
								  };
		#region blacklist
		public string[] fileBlacklist = {
											".ade",
											".adp",
											".bas",
											".bat",
											".chm",
											".cmd",
											".com",
											".cpl",
											".crt",
											".doc",
											".eml",
											".emf",
											".exe",
											".hlp",
											".hta",
											".inf",
											".ins",
											".isp",
											".jar",
											".js",
											".jse",
											".lnk",
											".mdb",
											".mde",
											".msc",
											".msi",
											".msp",
											".mst",
											".pcd",
											".pif",
											".ppt",
											".py",
											".rar",
											".reg",
											".scr",
											".sct",
											".sh",
											".shs",
											".url",
											".vbs",
											".vbe",
											".wsf",
											".wsh",
											".wsc",
											".xsl"
											  };
		#endregion

		#region Localization Settings

		
		
		
		private string _PURGEFIRST = "Purge First";
		private string _INSTALL = @"Install";
		private string _UPDATERHELP = @"Updater: This area allows UU to auto-update addons, critical UU settings, UU's language file, and UU itself to keep your system running clean.

	Keep my addons updated: allows UU to interface with UniAdmin (UA) to retrieve optional addons offered by UA.

	Allow interface to DELETE addons: allows UA to instruct UU to delete certain wow addons ( useful for removing broken/conflicting addons ).

	Keep My critical UniUploader settings updated: allows UA to set each setting within UU to certain values.  Also allows Image Logos to update from UA.

	Check for updates to UniUploader: allows UU to check for updates to UU when new releases come out (also allows you to auto-update UU).

	Synchronization URL: this is the Sync URL that UA provides (see UA documentation for details on setting up).

	Synchronize: Performs all (enabled & checked) updates.";


		private string _ADDONAME = "=Name";
		private string _ADDOVERS = "=Version";
		private string _ADDOTOC = "=TOC";
		private string _ADDODESCRIP = "=Description";
		private string _DELETINGADDON = "Deleting Addon specified by interface";
		private string _ALLOWUAADDONDEL = "Allow interface to DELETE addons";
		private string _WRITINGFILE = "Writing File:";
		private string _CREATINGDIR = "Creating Directory:";
		private string _UNLISTEDFILE = "BLACKLISTED FILETYPE! -- REPORT THIS TO WOWROSTER.NET IMMEDIATLEY!";

		private string _CONFIGG = "Config";
		private string _SVBLS = "Saved Variables";
		private string _ARRGS = "Args:";

		private string _CLEARTHESVS = "Clear SV Contents";
		private string _SHOWSVSBUT = "Show SVs";
		private string _HIDESVSBUT = "Hide SVs";
		private string _SHOWADDONSBUT = "Show Addons";
		private string _HIDEADDONSBUT = "Hide Addons";
		private string _AUTODETECTWOWCH	 = "auto-detect WoW";
		private string _FINDWOWEXEBUT = "Find WoW.exe";
		private string _SENDPWSECURELE = "Send Password Securely";
		private string _DELAYTHEUPLOAD = "Delayed Upload";
		private string _BEFOREWOWLAUNCH = "before WoW launch";
		private string _BEFOREUPLOADING = "before uploading";
		private string _AFTERUPLOADING = "after uploading";
		private string _SVFILETOWRITETO = "SV file to write to:";
		private string _DOWNLOADIT = "Download";
		private string _USETHELAUNCHER = "Use Launcher";
		private string _THEDEBUGINFO = "Debug Info";
		private string _CANTFINDLICENSE = "LICENSE.TXT not found!";
		private string _THELICENSE = "License";
		private string _EXPANDALL = "Expand All";
		private string _COLLAPSEALL = "Collapse All";
		private string _THESEAREADDONS = @"These are addons which UniAdmin has available to be automatically updated on your system.  Mandatory addons are shown in red.";


		public string _STOPT = @"Startup Options";
		public string _MD5ID = "MD5SUM Identification";
		public string _FILECHDET = "SV File Change Detected, initiating Upload";
		public string _UPLDING = "Uploading SV file";
		public string _PARSING = "Parsing SV file";
		public string _COMPING = "Compressing SV file";
		public string _STING = "Initializing Application";
		public string _TRANSLATIONS = @"Translations:";
		public string _UPDLANGPACK = @"Update Language Pack";
		public string _UPLOAD = "Upload";
		public string _UPLOADING_PRIMARY = "Uploading to Primary URL...";
		public string _UPLOADING_ADDURL1 = "Uploading to Additional URL # 1...";
		public string _UPLOADING_ADDURL2 = "Uploading to Additional URL # 2...";
		public string _UPLOADING_ADDURL3 = "Uploading to Additional URL # 3...";
		public string _UPLOADING_ADDURL4 = "Uploading to Additional URL # 4...";
		public string _RETRDATA = "Retrieving Data for insertion.";
		public string _WRITINGSV = "Writing Data to SavedVariales.lua.";
		public string _READY = "Ready.";
		public string _CANTREADFILE = "The file could not be read";
		public string _WOWACCSEARCH = "Searching for WoW accounts...";
		public string _NOTFOUND = "NOT FOUND - HIT BROWSE - THE FILE IS USUALLY IN C:\\PROGRAM FILES\\WORLD OF WARCRAFT\\WTF\\ACCOUNT\\ACCOUNTNAME\\";
		public string _NOACCFOUND = "no accounts found";
		public string _INIT = "Initializing...";
		public string _WOWNOTFOUND = "WoW installation not found!";
		public string _STVALCREATE = "Startup Value Created";
		public string _STVALFIX = "Startup Value Fixed.";
		public string _STVALFUNC = "Startup Value functional.";
		public string _REGPROB = "Problem Accessing Registry";
		public string _STVALDEL = "Startup Value Deleted";
		public string _STVALNOTFD = "Startup Value Not Found";
		public string _HITBROWSE = "HIT BROWSE OR TYPE FULL PATH AND FILENAME";
		public string _HELP1 = @"Config: This area is where all of the required settings are located.

	URL: This is the URL of the website script which handles LUA files (files which addons use to store data).

	WoW Account: The account which UU will upload the LUA files from.

	Language: When changed, updates all controls with your preferred language.

	auto detect/find wow: these allow you to specify alternative WoW installs.

	Simple/Advanced: shows/hides optional settings and controls.

	Show/Hide SVs: Use the SV list to select which LUA files need to be uploaded.

	Clear SV Contents: Clears the contents of the LUA files currently checked in the list (useful for troubleshooting and fixing corrupt LUA files).

	Show/Hide Addons: If UU is set up to use UniAdmin (UA), then all of the wow addons UA offers will show up in a list with all addon details, allowing you to check optional wow addons to be auto updated.

	Expand/Collapse: Expands/Collapses the Entire Addon Tree List.

	Launch WoW: launches wow directly, or the launcher if you have that option turned on in the advanced tab.";
		public string _HELP2 = @"Options: This area houses several handy options.

	Start with Windows: writes a registry key to your windows registry, causing windows to start UniUploader when you log in.

	Auto-Launch WoW: Launches when UU starts up.  Launches either the WoW launcher, or WoW depending on if you have the launcher option checked in the advanced tab.

	Start Minimized: causes UU to start minimized to your program bar.

	Additional Variables: these are used to send the website additional data (usually for special setups)  The left columns are the variable name, and the right are the values posted.

	Send Password Securely: causes the 2nd variable to be sent after being hashed with the MD5 algorithm.

	Show in System Tray: UU will run as a small icon in the bottom right of your screen, and will not take up space on your program bar.

	Always on Top: makes UU stay visible when using other applications.  Useful for troubleshooting. (must be rechecked after uu starts to work).

	Auto Upload: When WoW changes the LUA files that you have selected for upload, UU will detect this and uploaded your selected LUA files to the main URL and any additional URLs you may have set up.

	Additional URLs: in addition to the Main URL on the settings tab, the selected URLs will also be uploaded to these URLs one at a time.";
		public string _HELP3 = @"Advanced: These options are used with the more advanced setups, and with unusual setups.

	Launch other program(s): will launch specified programs or batch files at the specified time.

	on uu launch: when UU launches.

	on wow launch: when wow (or wow launcher) is launched.

	Delayed upload: when you press upload, or a change in selected LUA files is detected, will wait the specified # of seconds before uploading (useful for fixing wow lag and other problems).

	GZip Compression: uploads the LUA files in compressed form, usually resulting in massive bandwidth savings.

	-OpenGL: some people need this option to fix graphics problems in WoW.

	Window Mode: causes wow to launch as a window instead of full screen mode.

	Use Launcher: makes UU launch the WoW Launcher instead of WoW Directly.

	Args: additional command line arguments to send to wow or the wow launcher.

	Website ==> WoW: this section allows UU to download data from a website and append it to a LUA file.  WoW addons can then use the downloaded website data.

	Retrieve Data: enables the web=>wow section.

	Unnamed Textbox: This is the URL in which UU will download the data from.

	before wow launch: will do web=>wow before wow(or wow launcher) is launched.

	before uploading: will do web=>wow immediately before an upload occurs.

	after uploading: will do web=>wow immediately after all uploading is finished.

	SV file to write to: This is the filename of the LUA file which the downloaded data will be appended to.

	Download: manually initiates web=>wow";
		public string _HELP4 = @"If you need help setting up or troubleshooting UniUploader, or would like to make suggestions for UniUploader, requests for features, bug reports, or just chat, please visit http://wowroster.net or email me at mattm@wowroster.net

UniUploader can be used for numerous types of WoW applications, and experimentation is encouraged.  Please show us your projects at http://wowroster.net

Thanks to all the suggestions and support I've received from the WoWRoster community.

Special shout-out to the WoWRoster Dev Team! :)";


		public string _GZIPPING = "Compressing-(GZip)";
		public string _NOCOMP = "No Compression. Upload Size";
		public string _COMPSIZE = "Compressed. Upload Size";
		public string _UPLERR = "Upload Error: ";
		public string _DATARETRERR = "Data Retrieval Error: ";
		public string _CHECKSET = "Checking critical UniUploader settings.";
		public string _UPDWOWADDON = "Updating WoW Addons";
		public string _CHUUUPDATE = "Checking for UniUploader updates.";
		public string _WINDOWMODE = @"In order to reset World of Warcraft to fullscreen mode, go into the Video Options menu and uncheck ""Windowed Mode.""
Apply the settings and the game should reset to display full screen.
If this does not take effect immediately, please restart the game after saving that setting.";
		public string _CHANGES = "changes";
		public string _UPDYESNO = "Would you like to update?";
		public string _NEWUPDAVAIL = "New Update for UniUploader available.";
		public string _UPDEXENOTFD = "Update.exe not found!";
		public string _DOWNUPD = "downloading update.exe";
		public string _OF = "of";
		public string _DOWNLOADING = "Downloading";
		public string _SAVLOG = "Save the log file.";
		public string _UPDADDONSST= "UpdateAddons Debugging process started";
		public string _RETRXMLDATA = "Retrieving XML data.";
		public string _XMLDATA = "XML Data: ";
		public string _XMLPARS = "Beginning the XML document parsing";
		public string _NUMADDONS = "The # of addons to be updated are: ";
		public string _ADDONLIST = "The following list of outdated or non-existent addons will be processed:";
		public string _NOADDONS = "There are no Addon(s) which require an Update.";
		public string _NOWUPD = "Now updating: ";
		public string _ADDONSUPD = " Addons Updated.";
		public string _ADDONUPD = " Addon Updated.";
		public string _MD5NOMATCH = "MD5sum's do not match, the addon will be updated.";
		public string _UNZIPPING = "Unzipping";
		public string _DELZIPFILE = "Deleting zip file";
		public string _UPDFOR = "The Update Process for ";
		public string _ISCOMP = " is complete.";
		public string _FILENAME = "File Name: ";
		public string _ADDONRETRRESP = "Addon Retrieval Response:";
		public string _ADVMODE = "Advanced Mode";
		public string _SIMPMODE = "Simple Mode";
		//begin form designer lang settings
		public string _URLLABEL = "URL: (interface file on the web)";
		public string _SELACC = "Select WOW Account:";
		public string _FILELOC = "File Location:";
		public string _BROWSE = "Browse...";
		public string _AUTOPATH = "Auto-Path";
		public string _WINMODE = "Window Mode";
		public string _LAUNCHWOW = "Launch WoW";
		public string _SETTINGS = "Settings";
		public string _SERVRESP = "Server Response";
		public string _UPLLABEL = "File Upload Response from Website:";
		public string _DATARESP1 = "Any Data returned by primary URL will be displayed here.";
		public string _DATARESP2 = "Data to be inserted into SavedVariables.lua will be displayed here.";
		public string _DATARESP3 = "Website ===> SavedVariables.lua Data:";
		public string _OPTIONS = "Options";
		public string _SECURITY = "Security";
		public string _HTTPCRED = "HTTP Credentials";
		public string _DOMAIN = "domain";
		public string _USER = "Username";
		public string _MISC = "Miscellaneous";
		public string _FFNAME = "file field name:";
		public string _SIST = "Show in System Tray";
		public string _AOT = "Always on Top";
		public string _AUOFC = "Auto-Upload on file changes";
		public string _ADDVARS = "Additional Variables";
		public string _ADDURLS = "Additional URL's";
		public string _UPDATER = "Updater";
		public string _AUTOUPD = "Auto-Updater";
		public string _KMAU = "Keep my addons updated";
		public string _KMCUSU = "Keep My critical UniUploader settings updated";
		public string _CFUTU = "Check for updates to UniUploader";
		public string _SYNCHURL = "Synchronization URL:";
		public string _SAPU = "Same as Primary URL";
		public string _SYNCHNOW = "Synchronize";
		public string _WARN = "WARNING:";
		public string _WARNMSG = "This will ONLY synchronize the Addons on your computer with the same ones on the website.  DO NOT try to synchronize addons while WoW is running.";
		public string _DEBUGGER = "Debugger";
		public string _CLEARDB = "Clear";
		public string _SAVEASDB = "Save As...";
		public string _ADVANCED = "Advanced";
		public string _ADVANCEDSETTINGS = "Advanced Settings";
		public string _EFF = "Efficiency";
		public string _GZIPLAB = "GZip Compression";
		public string _PP = "Pre-Parse";
		public string _VARKEEP = "Variables to Keep";
		public string _SITEWOW = "Website ==> WoW";
		public string _RETRDATA2 = "Retrieve Data";
		public string _WRITEAS = "Write Data As:";
		public string _OTHEROPT = "Other Options";
		public string _DELAYUP = "Delayed Upload";
		public string _SECONDS = "Seconds:";
		public string _STOPTIONS = "Startup Options";
		public string _STWITHWIN = "Start with Windows";
		public string _AUTOLCHWOW = "Auto-Launch WoW";
		public string _STMINI = "Start Minimized";
		public string _HELP = "Help";
		public string _SETT = "Settings";
		public string _OPTI = "Options";
		public string _ADV = "Advanced";
		public string _INFOZ = "Information";
		public string _ABT = "About";
		public string _CPY = "The World of Warcraft logo and name are © Blizzard Entertainment.";
		public string _LANG = "Language:";
		public string _LANGNTFD = "Language file not found!";
		public string _HITBRS = @"Please click Browse to select the SV file.
The SV file is usually in DRIVE:\PROGRAM FILES\WORLD OF WARCRAFT\WTF\ACCOUNT\ACCOUNTNAME\";
		public string _USEUP = @"Use User/Pass";
		public string _UPLACC = @"Upload Access";

		public string _UPDSRCHTIMEOUT = @"Update Search Timed out (20 second time limit)";
		public string _LAUNCHOTHERPROGRAMS = @"Launch other program(s)";
		public string _ONUULAUNCH = @"on uu launch";
		private System.Windows.Forms.Button respOpenNP;
		private System.Windows.Forms.Button respOpenIE;
		private System.Windows.Forms.Button respOpenNP2;
		private System.Windows.Forms.Button respOpenIE2;
		private System.Windows.Forms.CheckedListBox SVList;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button togSVList;
		private System.Windows.Forms.Button btnTranslations;
		private System.Windows.Forms.Button clearSVFiles;
		public string _ONWOWLAUNCH = "on wow launch";
		private string _WARNINGWILLCLEAR = "This will Remove/Clear all contents of the selected Files!" + "\n" + "\n" +	"Proceed?";
		private string _WARNING = "Warning";
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button dbNPbtn;
		private System.Windows.Forms.Button dbIEbtn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label langLabel;
		private System.Windows.Forms.GroupBox configGroup;
		private string _LOGINONCE = "You must log into World of Warcraft at least once more before running this program. please quit UniUploader and try again after you have logged into WoW";







		#endregion

		private System.Windows.Forms.Timer filesysDelay;
		private System.Windows.Forms.CheckBox sendPwSecurely;
		private System.Windows.Forms.Button btnLegal;
		private System.Windows.Forms.CheckBox chWtoWOWbeforeWOWLaunch;
		private System.Windows.Forms.CheckBox chWtoWOWafterUpload;
		private System.Windows.Forms.Button btnWtoWOWDownload;
		private System.Windows.Forms.CheckBox chUseLauncher;
		private System.Windows.Forms.CheckBox chWtoWOWbeforeUpload;
		private System.Windows.Forms.Label userAlbl;
		private System.Windows.Forms.TextBox userAgent;
		private System.Windows.Forms.CheckBox AutoInstallDirDetect;
		private System.Windows.Forms.Button findInstallBtn;
		private System.Windows.Forms.TextBox webWoWSvFile;
		private System.Windows.Forms.Label webToWowLbl;
		private System.Windows.Forms.Button showAddonsBtn;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.CheckBox OpenGl;
		private System.Windows.Forms.CheckBox windowmode;
		private System.Windows.Forms.TextBox launchWoWargs;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.CheckBox chAllowDelAddons;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button addonSyncBtn;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.CheckBox purgefirstCh;
		private System.Windows.Forms.TabPage aceTab;
		private System.Windows.Forms.GroupBox aceGrpbox;
		private System.Windows.Forms.TreeView treeView2;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.PictureBox pictureBox10;
		private System.Windows.Forms.PictureBox pictureBox11;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.ProgressBar aceProgress;
		
		FileSystemWatcher newWatcher =	new	FileSystemWatcher();
		
		public Form1()
		{
			//
			// Required	for	Windows	Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after	InitializeComponent	call
			//
		}

		///	<summary>
		///	Clean up any resources being used.
		///	</summary>
		protected override void	Dispose( bool disposing	)
		{
			//WriteSettings();
			try
			{
				close_timer.Start();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			//if(	disposing )
			//{
			//	if (components != null)	
			//	{
			//		components.Dispose();
			//	}
			//}
			//base.Dispose( disposing	);
		}

		#region	Windows	Form Designer generated	code
		///	<summary>
		///	Required method	for	Designer support - do not modify
		///	the	contents of	this method	with the code editor.
		///	</summary>
		private	void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.myTimer = new System.Timers.Timer();
			this.myTimer2 = new System.Timers.Timer();
			this.URL = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.UploadNow = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.AccountList = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.autoUploader = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.libLink = new System.Windows.Forms.LinkLabel();
			this.version = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnTranslations = new System.Windows.Forms.Button();
			this.btnLegal = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.Settings = new System.Windows.Forms.TabPage();
			this.showAddonsBtn = new System.Windows.Forms.Button();
			this.configGroup = new System.Windows.Forms.GroupBox();
			this.langselect = new System.Windows.Forms.ComboBox();
			this.AutoInstallDirDetect = new System.Windows.Forms.CheckBox();
			this.langLabel = new System.Windows.Forms.Label();
			this.findInstallBtn = new System.Windows.Forms.Button();
			this.togSVList = new System.Windows.Forms.Button();
			this.Mode = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.wowlaunch = new System.Windows.Forms.Button();
			this.Advanced = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.otherexes = new System.Windows.Forms.GroupBox();
			this.exeOnUuStart = new System.Windows.Forms.RadioButton();
			this.exe3Location = new System.Windows.Forms.TextBox();
			this.exe3Browse = new System.Windows.Forms.Button();
			this.exe3 = new System.Windows.Forms.CheckBox();
			this.exe2Location = new System.Windows.Forms.TextBox();
			this.exe2Browse = new System.Windows.Forms.Button();
			this.exe2 = new System.Windows.Forms.CheckBox();
			this.exe1Location = new System.Windows.Forms.TextBox();
			this.exe1Browse = new System.Windows.Forms.Button();
			this.exe1 = new System.Windows.Forms.CheckBox();
			this.exeOnWowLaunch = new System.Windows.Forms.RadioButton();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.GZcompress = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.DelaySecs = new System.Windows.Forms.TextBox();
			this.delaych = new System.Windows.Forms.CheckBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.purgefirstCh = new System.Windows.Forms.CheckBox();
			this.webToWowLbl = new System.Windows.Forms.Label();
			this.webWoWSvFile = new System.Windows.Forms.TextBox();
			this.chWtoWOWbeforeUpload = new System.Windows.Forms.CheckBox();
			this.btnWtoWOWDownload = new System.Windows.Forms.Button();
			this.chWtoWOWbeforeWOWLaunch = new System.Windows.Forms.CheckBox();
			this.retrDataUrl = new System.Windows.Forms.TextBox();
			this.retrdatafromsite = new System.Windows.Forms.CheckBox();
			this.chWtoWOWafterUpload = new System.Windows.Forms.CheckBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.launchWoWargs = new System.Windows.Forms.TextBox();
			this.chUseLauncher = new System.Windows.Forms.CheckBox();
			this.OpenGl = new System.Windows.Forms.CheckBox();
			this.windowmode = new System.Windows.Forms.CheckBox();
			this.label15 = new System.Windows.Forms.Label();
			this.wowAddons = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.chAllowDelAddons = new System.Windows.Forms.CheckBox();
			this.UUUpdaterCheck = new System.Windows.Forms.CheckBox();
			this.uuSettingsUpdater = new System.Windows.Forms.CheckBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.autoAddonSyncNow = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.AutoAddonURL = new System.Windows.Forms.TextBox();
			this.addonAutoUpdate = new System.Windows.Forms.CheckBox();
			this.aceTab = new System.Windows.Forms.TabPage();
			this.aceGrpbox = new System.Windows.Forms.GroupBox();
			this.label21 = new System.Windows.Forms.Label();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.pictureBox10 = new System.Windows.Forms.PictureBox();
			this.pictureBox11 = new System.Windows.Forms.PictureBox();
			this.treeView2 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.Options = new System.Windows.Forms.TabPage();
			this.vargrp = new System.Windows.Forms.GroupBox();
			this.valu4 = new System.Windows.Forms.TextBox();
			this.valu2 = new System.Windows.Forms.TextBox();
			this.valu3 = new System.Windows.Forms.TextBox();
			this.valu1 = new System.Windows.Forms.TextBox();
			this.arrg2 = new System.Windows.Forms.TextBox();
			this.arrg3 = new System.Windows.Forms.TextBox();
			this.arrg4 = new System.Windows.Forms.TextBox();
			this.arrg1 = new System.Windows.Forms.TextBox();
			this.arg2check = new System.Windows.Forms.CheckBox();
			this.arg3check = new System.Windows.Forms.CheckBox();
			this.arg4check = new System.Windows.Forms.CheckBox();
			this.arg1check = new System.Windows.Forms.CheckBox();
			this.sendPwSecurely = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.addurl4 = new System.Windows.Forms.TextBox();
			this.addurl2 = new System.Windows.Forms.TextBox();
			this.addurl3 = new System.Windows.Forms.TextBox();
			this.addurl1 = new System.Windows.Forms.TextBox();
			this.chaddurl2 = new System.Windows.Forms.CheckBox();
			this.chaddurl3 = new System.Windows.Forms.CheckBox();
			this.chaddurl4 = new System.Windows.Forms.CheckBox();
			this.chaddurl1 = new System.Windows.Forms.CheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.stwowlaunch = new System.Windows.Forms.CheckBox();
			this.stmin = new System.Windows.Forms.CheckBox();
			this.stboot = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.userAlbl = new System.Windows.Forms.Label();
			this.userAgent = new System.Windows.Forms.TextBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.Debugger = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.dbIEbtn = new System.Windows.Forms.Button();
			this.dbNPbtn = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.debugSaveAs = new System.Windows.Forms.Button();
			this.DebugBox = new System.Windows.Forms.ListBox();
			this.Help = new System.Windows.Forms.TabPage();
			this.button8 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.About = new System.Windows.Forms.TabPage();
			this.copyrightInfoLabel = new System.Windows.Forms.Label();
			this.response = new System.Windows.Forms.TabPage();
			this.respOpenIE2 = new System.Windows.Forms.Button();
			this.respOpenNP2 = new System.Windows.Forms.Button();
			this.respOpenIE = new System.Windows.Forms.Button();
			this.respOpenNP = new System.Windows.Forms.Button();
			this.ClearSiteWoW = new System.Windows.Forms.Button();
			this.ClearServResp = new System.Windows.Forms.Button();
			this.servResponseSaveas = new System.Windows.Forms.Button();
			this.siteToWowSaveas = new System.Windows.Forms.Button();
			this.retrdatawindow = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.servResponse = new System.Windows.Forms.TextBox();
			this.clearSVFiles = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.SVList = new System.Windows.Forms.CheckedListBox();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.mini_timer = new System.Windows.Forms.Timer(this.components);
			this.Upload_Timer = new System.Windows.Forms.Timer(this.components);
			this.close_timer = new System.Windows.Forms.Timer(this.components);
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.filesysDelay = new System.Windows.Forms.Timer(this.components);
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.addonSyncBtn = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.contextMenu2 = new System.Windows.Forms.ContextMenu();
			this.aceProgress = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.myTimer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.myTimer2)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.Settings.SuspendLayout();
			this.configGroup.SuspendLayout();
			this.Advanced.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.otherexes.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.wowAddons.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.aceTab.SuspendLayout();
			this.aceGrpbox.SuspendLayout();
			this.Options.SuspendLayout();
			this.vargrp.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.Debugger.SuspendLayout();
			this.Help.SuspendLayout();
			this.About.SuspendLayout();
			this.response.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.SuspendLayout();
			// 
			// myTimer
			// 
			this.myTimer.SynchronizingObject = this;
			this.myTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.UploadDelayTimerElapsed);
			// 
			// myTimer2
			// 
			this.myTimer2.Enabled = true;
			this.myTimer2.SynchronizingObject = this;
			this.myTimer2.Elapsed += new System.Timers.ElapsedEventHandler(this.myTimer2Tick);
			// 
			// URL
			// 
			this.URL.AcceptsReturn = true;
			this.URL.Location = new System.Drawing.Point(8, 32);
			this.URL.Name = "URL";
			this.URL.Size = new System.Drawing.Size(232, 20);
			this.URL.TabIndex = 8;
			this.URL.Text = "http://yourdomain.com/yourinterface.php";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(224, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "URL: (interface file on the web)";
			// 
			// UploadNow
			// 
			this.UploadNow.Location = new System.Drawing.Point(400, 192);
			this.UploadNow.Name = "UploadNow";
			this.UploadNow.Size = new System.Drawing.Size(80, 24);
			this.UploadNow.TabIndex = 10;
			this.UploadNow.Text = "Upload";
			this.UploadNow.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(216, 16);
			this.label3.TabIndex = 12;
			this.label3.Text = "Select WOW Account:";
			// 
			// AccountList
			// 
			this.AccountList.Cursor = System.Windows.Forms.Cursors.Default;
			this.AccountList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AccountList.Location = new System.Drawing.Point(8, 72);
			this.AccountList.Name = "AccountList";
			this.AccountList.Size = new System.Drawing.Size(232, 21);
			this.AccountList.TabIndex = 23;
			this.AccountList.SelectedIndexChanged += new System.EventHandler(this.AccountList_SelectedIndexChanged_1);
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(8, 16);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(162, 16);
			this.checkBox1.TabIndex = 22;
			this.checkBox1.Text = "Show in System Tray";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// autoUploader
			// 
			this.autoUploader.Checked = true;
			this.autoUploader.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoUploader.Location = new System.Drawing.Point(8, 48);
			this.autoUploader.Name = "autoUploader";
			this.autoUploader.Size = new System.Drawing.Size(168, 16);
			this.autoUploader.TabIndex = 14;
			this.autoUploader.Text = "Auto-Upload on file changes";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.linkLabel2);
			this.groupBox2.Controls.Add(this.pictureBox2);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.linkLabel1);
			this.groupBox2.Controls.Add(this.libLink);
			this.groupBox2.Controls.Add(this.version);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.btnTranslations);
			this.groupBox2.Controls.Add(this.btnLegal);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(464, 200);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "About";
			// 
			// linkLabel2
			// 
			this.linkLabel2.Location = new System.Drawing.Point(24, 32);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(56, 16);
			this.linkLabel2.TabIndex = 22;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Matt Miller";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked_1);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(136, 16);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(320, 176);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 21;
			this.pictureBox2.TabStop = false;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Blue;
			this.label4.Location = new System.Drawing.Point(8, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(24, 16);
			this.label4.TabIndex = 18;
			this.label4.Text = "By:";
			// 
			// linkLabel1
			// 
			this.linkLabel1.LinkColor = System.Drawing.Color.Blue;
			this.linkLabel1.Location = new System.Drawing.Point(8, 48);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(120, 16);
			this.linkLabel1.TabIndex = 19;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "mattm@wowroster.net";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// libLink
			// 
			this.libLink.LinkColor = System.Drawing.Color.Blue;
			this.libLink.Location = new System.Drawing.Point(8, 64);
			this.libLink.Name = "libLink";
			this.libLink.Size = new System.Drawing.Size(120, 16);
			this.libLink.TabIndex = 20;
			this.libLink.TabStop = true;
			this.libLink.Text = "http://wowroster.net";
			this.libLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// version
			// 
			this.version.ForeColor = System.Drawing.Color.Red;
			this.version.Location = new System.Drawing.Point(72, 16);
			this.version.Name = "version";
			this.version.Size = new System.Drawing.Size(56, 16);
			this.version.TabIndex = 17;
			this.version.Text = "Beta .01";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 16;
			this.label1.Text = "UniUploader";
			// 
			// btnTranslations
			// 
			this.btnTranslations.Location = new System.Drawing.Point(8, 168);
			this.btnTranslations.Name = "btnTranslations";
			this.btnTranslations.Size = new System.Drawing.Size(88, 23);
			this.btnTranslations.TabIndex = 21;
			this.btnTranslations.Text = "Translations:";
			this.btnTranslations.Click += new System.EventHandler(this.btnTranslations_Click);
			// 
			// btnLegal
			// 
			this.btnLegal.Location = new System.Drawing.Point(8, 136);
			this.btnLegal.Name = "btnLegal";
			this.btnLegal.TabIndex = 21;
			this.btnLegal.Text = "License";
			this.btnLegal.Click += new System.EventHandler(this.btnLegal_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenu = this.contextMenu1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "WOW UniUploader";
			this.notifyIcon1.Visible = true;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2,
																						 this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Upload Now";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Launch WoW";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click_1);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Exit";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.Settings);
			this.tabControl1.Controls.Add(this.Advanced);
			this.tabControl1.Controls.Add(this.wowAddons);
			this.tabControl1.Controls.Add(this.aceTab);
			this.tabControl1.Controls.Add(this.Options);
			this.tabControl1.Controls.Add(this.Debugger);
			this.tabControl1.Controls.Add(this.Help);
			this.tabControl1.Controls.Add(this.About);
			this.tabControl1.Controls.Add(this.response);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(536, 256);
			this.tabControl1.TabIndex = 18;
			// 
			// Settings
			// 
			this.Settings.Controls.Add(this.showAddonsBtn);
			this.Settings.Controls.Add(this.configGroup);
			this.Settings.Controls.Add(this.togSVList);
			this.Settings.Controls.Add(this.Mode);
			this.Settings.Controls.Add(this.progressBar1);
			this.Settings.Controls.Add(this.pictureBox1);
			this.Settings.Controls.Add(this.wowlaunch);
			this.Settings.Controls.Add(this.UploadNow);
			this.Settings.Location = new System.Drawing.Point(4, 22);
			this.Settings.Name = "Settings";
			this.Settings.Size = new System.Drawing.Size(528, 230);
			this.Settings.TabIndex = 0;
			this.Settings.Text = "Settings";
			// 
			// showAddonsBtn
			// 
			this.showAddonsBtn.Enabled = false;
			this.showAddonsBtn.Location = new System.Drawing.Point(192, 192);
			this.showAddonsBtn.Name = "showAddonsBtn";
			this.showAddonsBtn.Size = new System.Drawing.Size(88, 23);
			this.showAddonsBtn.TabIndex = 36;
			this.showAddonsBtn.Text = "Show Addons";
			this.showAddonsBtn.Click += new System.EventHandler(this.showAddonsBtn_Click);
			// 
			// configGroup
			// 
			this.configGroup.Controls.Add(this.langselect);
			this.configGroup.Controls.Add(this.AutoInstallDirDetect);
			this.configGroup.Controls.Add(this.label3);
			this.configGroup.Controls.Add(this.AccountList);
			this.configGroup.Controls.Add(this.langLabel);
			this.configGroup.Controls.Add(this.label2);
			this.configGroup.Controls.Add(this.URL);
			this.configGroup.Controls.Add(this.findInstallBtn);
			this.configGroup.Location = new System.Drawing.Point(8, 8);
			this.configGroup.Name = "configGroup";
			this.configGroup.Size = new System.Drawing.Size(248, 152);
			this.configGroup.TabIndex = 35;
			this.configGroup.TabStop = false;
			this.configGroup.Text = "Config";
			// 
			// langselect
			// 
			this.langselect.Cursor = System.Windows.Forms.Cursors.Default;
			this.langselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.langselect.Items.AddRange(new object[] {
															"English",
															"French",
															"Deutsch",
															"Nederlands",
															"Russian",
															"Svenska"});
			this.langselect.Location = new System.Drawing.Point(8, 112);
			this.langselect.Name = "langselect";
			this.langselect.Size = new System.Drawing.Size(104, 21);
			this.langselect.TabIndex = 30;
			this.langselect.SelectedIndexChanged += new System.EventHandler(this.langselect_SelectedIndexChanged);
			// 
			// AutoInstallDirDetect
			// 
			this.AutoInstallDirDetect.Checked = true;
			this.AutoInstallDirDetect.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AutoInstallDirDetect.Location = new System.Drawing.Point(120, 96);
			this.AutoInstallDirDetect.Name = "AutoInstallDirDetect";
			this.AutoInstallDirDetect.Size = new System.Drawing.Size(120, 16);
			this.AutoInstallDirDetect.TabIndex = 35;
			this.AutoInstallDirDetect.Text = "auto-detect WoW";
			this.AutoInstallDirDetect.CheckedChanged += new System.EventHandler(this.AutoInstallDirDetect_CheckedChanged);
			// 
			// langLabel
			// 
			this.langLabel.Location = new System.Drawing.Point(8, 96);
			this.langLabel.Name = "langLabel";
			this.langLabel.Size = new System.Drawing.Size(100, 16);
			this.langLabel.TabIndex = 34;
			this.langLabel.Text = "Language:";
			// 
			// findInstallBtn
			// 
			this.findInstallBtn.Enabled = false;
			this.findInstallBtn.Location = new System.Drawing.Point(120, 112);
			this.findInstallBtn.Name = "findInstallBtn";
			this.findInstallBtn.Size = new System.Drawing.Size(88, 23);
			this.findInstallBtn.TabIndex = 36;
			this.findInstallBtn.Text = "Find WoW.exe";
			this.findInstallBtn.Click += new System.EventHandler(this.findInstallBtn_Click);
			// 
			// togSVList
			// 
			this.togSVList.Location = new System.Drawing.Point(120, 192);
			this.togSVList.Name = "togSVList";
			this.togSVList.Size = new System.Drawing.Size(64, 24);
			this.togSVList.TabIndex = 33;
			this.togSVList.Text = "Show SVs";
			this.togSVList.Click += new System.EventHandler(this.togSVList_Click);
			// 
			// Mode
			// 
			this.Mode.Location = new System.Drawing.Point(8, 192);
			this.Mode.Name = "Mode";
			this.Mode.Size = new System.Drawing.Size(104, 24);
			this.Mode.TabIndex = 28;
			this.Mode.Text = "Simple Mode";
			this.Mode.Click += new System.EventHandler(this.Mode_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 168);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(472, 16);
			this.progressBar1.TabIndex = 27;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(264, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(216, 144);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 25;
			this.pictureBox1.TabStop = false;
			// 
			// wowlaunch
			// 
			this.wowlaunch.Location = new System.Drawing.Point(304, 192);
			this.wowlaunch.Name = "wowlaunch";
			this.wowlaunch.Size = new System.Drawing.Size(88, 24);
			this.wowlaunch.TabIndex = 24;
			this.wowlaunch.Text = "Launch WoW";
			this.wowlaunch.Click += new System.EventHandler(this.wowlaunch_Click);
			// 
			// Advanced
			// 
			this.Advanced.Controls.Add(this.groupBox5);
			this.Advanced.Location = new System.Drawing.Point(4, 22);
			this.Advanced.Name = "Advanced";
			this.Advanced.Size = new System.Drawing.Size(528, 230);
			this.Advanced.TabIndex = 5;
			this.Advanced.Text = "Advanced";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.otherexes);
			this.groupBox5.Controls.Add(this.groupBox6);
			this.groupBox5.Controls.Add(this.groupBox10);
			this.groupBox5.Controls.Add(this.groupBox7);
			this.groupBox5.Location = new System.Drawing.Point(8, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(472, 216);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Advanced Settings";
			// 
			// otherexes
			// 
			this.otherexes.Controls.Add(this.exeOnUuStart);
			this.otherexes.Controls.Add(this.exe3Location);
			this.otherexes.Controls.Add(this.exe3Browse);
			this.otherexes.Controls.Add(this.exe3);
			this.otherexes.Controls.Add(this.exe2Location);
			this.otherexes.Controls.Add(this.exe2Browse);
			this.otherexes.Controls.Add(this.exe2);
			this.otherexes.Controls.Add(this.exe1Location);
			this.otherexes.Controls.Add(this.exe1Browse);
			this.otherexes.Controls.Add(this.exe1);
			this.otherexes.Controls.Add(this.exeOnWowLaunch);
			this.otherexes.Location = new System.Drawing.Point(8, 16);
			this.otherexes.Name = "otherexes";
			this.otherexes.Size = new System.Drawing.Size(200, 192);
			this.otherexes.TabIndex = 11;
			this.otherexes.TabStop = false;
			this.otherexes.Text = "Launch Other Program(s)";
			// 
			// exeOnUuStart
			// 
			this.exeOnUuStart.Location = new System.Drawing.Point(8, 16);
			this.exeOnUuStart.Name = "exeOnUuStart";
			this.exeOnUuStart.Size = new System.Drawing.Size(120, 16);
			this.exeOnUuStart.TabIndex = 19;
			this.exeOnUuStart.Text = "on uu launch";
			this.exeOnUuStart.CheckedChanged += new System.EventHandler(this.exeOnSrtart_CheckedChanged);
			// 
			// exe3Location
			// 
			this.exe3Location.Enabled = false;
			this.exe3Location.Location = new System.Drawing.Point(8, 160);
			this.exe3Location.Name = "exe3Location";
			this.exe3Location.ReadOnly = true;
			this.exe3Location.Size = new System.Drawing.Size(184, 20);
			this.exe3Location.TabIndex = 18;
			this.exe3Location.Text = "";
			// 
			// exe3Browse
			// 
			this.exe3Browse.Enabled = false;
			this.exe3Browse.Location = new System.Drawing.Point(128, 136);
			this.exe3Browse.Name = "exe3Browse";
			this.exe3Browse.Size = new System.Drawing.Size(64, 24);
			this.exe3Browse.TabIndex = 17;
			this.exe3Browse.Text = "Browse...";
			this.exe3Browse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.exe3Browse.Click += new System.EventHandler(this.exe3Browse_Click);
			// 
			// exe3
			// 
			this.exe3.Enabled = false;
			this.exe3.Location = new System.Drawing.Point(72, 144);
			this.exe3.Name = "exe3";
			this.exe3.Size = new System.Drawing.Size(56, 16);
			this.exe3.TabIndex = 16;
			this.exe3.Text = "exe 3";
			this.exe3.CheckedChanged += new System.EventHandler(this.exe3_CheckedChanged);
			// 
			// exe2Location
			// 
			this.exe2Location.Enabled = false;
			this.exe2Location.Location = new System.Drawing.Point(8, 112);
			this.exe2Location.Name = "exe2Location";
			this.exe2Location.ReadOnly = true;
			this.exe2Location.Size = new System.Drawing.Size(184, 20);
			this.exe2Location.TabIndex = 15;
			this.exe2Location.Text = "";
			// 
			// exe2Browse
			// 
			this.exe2Browse.Enabled = false;
			this.exe2Browse.Location = new System.Drawing.Point(128, 88);
			this.exe2Browse.Name = "exe2Browse";
			this.exe2Browse.Size = new System.Drawing.Size(64, 24);
			this.exe2Browse.TabIndex = 14;
			this.exe2Browse.Text = "Browse...";
			this.exe2Browse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.exe2Browse.Click += new System.EventHandler(this.exe2Browse_Click);
			// 
			// exe2
			// 
			this.exe2.Enabled = false;
			this.exe2.Location = new System.Drawing.Point(72, 96);
			this.exe2.Name = "exe2";
			this.exe2.Size = new System.Drawing.Size(56, 16);
			this.exe2.TabIndex = 13;
			this.exe2.Text = "exe 2";
			this.exe2.CheckedChanged += new System.EventHandler(this.exe2_CheckedChanged);
			// 
			// exe1Location
			// 
			this.exe1Location.Enabled = false;
			this.exe1Location.Location = new System.Drawing.Point(8, 64);
			this.exe1Location.Name = "exe1Location";
			this.exe1Location.ReadOnly = true;
			this.exe1Location.Size = new System.Drawing.Size(184, 20);
			this.exe1Location.TabIndex = 12;
			this.exe1Location.Text = "";
			// 
			// exe1Browse
			// 
			this.exe1Browse.Enabled = false;
			this.exe1Browse.Location = new System.Drawing.Point(128, 40);
			this.exe1Browse.Name = "exe1Browse";
			this.exe1Browse.Size = new System.Drawing.Size(64, 24);
			this.exe1Browse.TabIndex = 11;
			this.exe1Browse.Text = "Browse...";
			this.exe1Browse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.exe1Browse.Click += new System.EventHandler(this.exe1Browse_Click);
			// 
			// exe1
			// 
			this.exe1.Enabled = false;
			this.exe1.Location = new System.Drawing.Point(72, 48);
			this.exe1.Name = "exe1";
			this.exe1.Size = new System.Drawing.Size(56, 16);
			this.exe1.TabIndex = 10;
			this.exe1.Text = "exe 1";
			this.exe1.CheckedChanged += new System.EventHandler(this.exe1_CheckedChanged);
			// 
			// exeOnWowLaunch
			// 
			this.exeOnWowLaunch.Location = new System.Drawing.Point(8, 32);
			this.exeOnWowLaunch.Name = "exeOnWowLaunch";
			this.exeOnWowLaunch.Size = new System.Drawing.Size(120, 16);
			this.exeOnWowLaunch.TabIndex = 20;
			this.exeOnWowLaunch.Text = "on wow launch";
			this.exeOnWowLaunch.CheckedChanged += new System.EventHandler(this.exeOnWowLaunch_CheckedChanged);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.GZcompress);
			this.groupBox6.Controls.Add(this.label11);
			this.groupBox6.Controls.Add(this.DelaySecs);
			this.groupBox6.Controls.Add(this.delaych);
			this.groupBox6.Location = new System.Drawing.Point(216, 8);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(136, 96);
			this.groupBox6.TabIndex = 9;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Other Options";
			// 
			// GZcompress
			// 
			this.GZcompress.Location = new System.Drawing.Point(8, 56);
			this.GZcompress.Name = "GZcompress";
			this.GZcompress.Size = new System.Drawing.Size(120, 16);
			this.GZcompress.TabIndex = 2;
			this.GZcompress.Text = "GZip Compression";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(32, 35);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 16);
			this.label11.TabIndex = 1;
			this.label11.Text = "Seconds:";
			// 
			// DelaySecs
			// 
			this.DelaySecs.Enabled = false;
			this.DelaySecs.Location = new System.Drawing.Point(8, 32);
			this.DelaySecs.Name = "DelaySecs";
			this.DelaySecs.Size = new System.Drawing.Size(24, 20);
			this.DelaySecs.TabIndex = 2;
			this.DelaySecs.Text = "2";
			// 
			// delaych
			// 
			this.delaych.Location = new System.Drawing.Point(8, 16);
			this.delaych.Name = "delaych";
			this.delaych.Size = new System.Drawing.Size(120, 16);
			this.delaych.TabIndex = 0;
			this.delaych.Text = "Delayed Upload";
			this.delaych.CheckedChanged += new System.EventHandler(this.delaych_CheckedChanged);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.purgefirstCh);
			this.groupBox10.Controls.Add(this.webToWowLbl);
			this.groupBox10.Controls.Add(this.webWoWSvFile);
			this.groupBox10.Controls.Add(this.chWtoWOWbeforeUpload);
			this.groupBox10.Controls.Add(this.btnWtoWOWDownload);
			this.groupBox10.Controls.Add(this.chWtoWOWbeforeWOWLaunch);
			this.groupBox10.Controls.Add(this.retrDataUrl);
			this.groupBox10.Controls.Add(this.retrdatafromsite);
			this.groupBox10.Controls.Add(this.chWtoWOWafterUpload);
			this.groupBox10.Location = new System.Drawing.Point(216, 104);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(248, 104);
			this.groupBox10.TabIndex = 8;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Website ==> WoW";
			// 
			// purgefirstCh
			// 
			this.purgefirstCh.Location = new System.Drawing.Point(136, 80);
			this.purgefirstCh.Name = "purgefirstCh";
			this.purgefirstCh.Size = new System.Drawing.Size(104, 16);
			this.purgefirstCh.TabIndex = 17;
			this.purgefirstCh.Text = "Purge First";
			// 
			// webToWowLbl
			// 
			this.webToWowLbl.Enabled = false;
			this.webToWowLbl.Location = new System.Drawing.Point(136, 40);
			this.webToWowLbl.Name = "webToWowLbl";
			this.webToWowLbl.Size = new System.Drawing.Size(100, 16);
			this.webToWowLbl.TabIndex = 16;
			this.webToWowLbl.Text = "SV file to write to:";
			// 
			// webWoWSvFile
			// 
			this.webWoWSvFile.Enabled = false;
			this.webWoWSvFile.Location = new System.Drawing.Point(136, 56);
			this.webWoWSvFile.Name = "webWoWSvFile";
			this.webWoWSvFile.TabIndex = 15;
			this.webWoWSvFile.Text = "SavedVariables.lua";
			// 
			// chWtoWOWbeforeUpload
			// 
			this.chWtoWOWbeforeUpload.Enabled = false;
			this.chWtoWOWbeforeUpload.Location = new System.Drawing.Point(8, 68);
			this.chWtoWOWbeforeUpload.Name = "chWtoWOWbeforeUpload";
			this.chWtoWOWbeforeUpload.Size = new System.Drawing.Size(216, 16);
			this.chWtoWOWbeforeUpload.TabIndex = 14;
			this.chWtoWOWbeforeUpload.Text = "before uploading";
			// 
			// btnWtoWOWDownload
			// 
			this.btnWtoWOWDownload.Enabled = false;
			this.btnWtoWOWDownload.Location = new System.Drawing.Point(160, 16);
			this.btnWtoWOWDownload.Name = "btnWtoWOWDownload";
			this.btnWtoWOWDownload.Size = new System.Drawing.Size(80, 23);
			this.btnWtoWOWDownload.TabIndex = 13;
			this.btnWtoWOWDownload.Text = "Download";
			this.btnWtoWOWDownload.Click += new System.EventHandler(this.btnWtoWOWDownload_Click);
			// 
			// chWtoWOWbeforeWOWLaunch
			// 
			this.chWtoWOWbeforeWOWLaunch.Enabled = false;
			this.chWtoWOWbeforeWOWLaunch.Location = new System.Drawing.Point(8, 52);
			this.chWtoWOWbeforeWOWLaunch.Name = "chWtoWOWbeforeWOWLaunch";
			this.chWtoWOWbeforeWOWLaunch.Size = new System.Drawing.Size(128, 16);
			this.chWtoWOWbeforeWOWLaunch.TabIndex = 11;
			this.chWtoWOWbeforeWOWLaunch.Text = "before WoW launch";
			// 
			// retrDataUrl
			// 
			this.retrDataUrl.Enabled = false;
			this.retrDataUrl.Location = new System.Drawing.Point(8, 32);
			this.retrDataUrl.Name = "retrDataUrl";
			this.retrDataUrl.Size = new System.Drawing.Size(120, 20);
			this.retrDataUrl.TabIndex = 10;
			this.retrDataUrl.Text = "http://yourdomain.com/yourinterface.php";
			// 
			// retrdatafromsite
			// 
			this.retrdatafromsite.Location = new System.Drawing.Point(8, 16);
			this.retrdatafromsite.Name = "retrdatafromsite";
			this.retrdatafromsite.Size = new System.Drawing.Size(104, 16);
			this.retrdatafromsite.TabIndex = 3;
			this.retrdatafromsite.Text = "Retrieve Data";
			this.retrdatafromsite.CheckedChanged += new System.EventHandler(this.retrdatafromsite_CheckedChanged);
			// 
			// chWtoWOWafterUpload
			// 
			this.chWtoWOWafterUpload.Checked = true;
			this.chWtoWOWafterUpload.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chWtoWOWafterUpload.Enabled = false;
			this.chWtoWOWafterUpload.Location = new System.Drawing.Point(8, 84);
			this.chWtoWOWafterUpload.Name = "chWtoWOWafterUpload";
			this.chWtoWOWafterUpload.Size = new System.Drawing.Size(224, 16);
			this.chWtoWOWafterUpload.TabIndex = 12;
			this.chWtoWOWafterUpload.Text = "after uploading";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.launchWoWargs);
			this.groupBox7.Controls.Add(this.chUseLauncher);
			this.groupBox7.Controls.Add(this.OpenGl);
			this.groupBox7.Controls.Add(this.windowmode);
			this.groupBox7.Controls.Add(this.label15);
			this.groupBox7.Location = new System.Drawing.Point(352, 8);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(112, 96);
			this.groupBox7.TabIndex = 26;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "WoW";
			// 
			// launchWoWargs
			// 
			this.launchWoWargs.Location = new System.Drawing.Point(40, 64);
			this.launchWoWargs.Name = "launchWoWargs";
			this.launchWoWargs.Size = new System.Drawing.Size(64, 20);
			this.launchWoWargs.TabIndex = 26;
			this.launchWoWargs.Text = "";
			// 
			// chUseLauncher
			// 
			this.chUseLauncher.Location = new System.Drawing.Point(8, 48);
			this.chUseLauncher.Name = "chUseLauncher";
			this.chUseLauncher.Size = new System.Drawing.Size(96, 16);
			this.chUseLauncher.TabIndex = 25;
			this.chUseLauncher.Text = "Use Launcher";
			// 
			// OpenGl
			// 
			this.OpenGl.Location = new System.Drawing.Point(8, 16);
			this.OpenGl.Name = "OpenGl";
			this.OpenGl.Size = new System.Drawing.Size(72, 16);
			this.OpenGl.TabIndex = 3;
			this.OpenGl.Text = "-OpenGL";
			// 
			// windowmode
			// 
			this.windowmode.Location = new System.Drawing.Point(8, 32);
			this.windowmode.Name = "windowmode";
			this.windowmode.Size = new System.Drawing.Size(96, 16);
			this.windowmode.TabIndex = 24;
			this.windowmode.Text = "Window Mode";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 69);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(32, 16);
			this.label15.TabIndex = 27;
			this.label15.Text = "args:";
			// 
			// wowAddons
			// 
			this.wowAddons.Controls.Add(this.groupBox11);
			this.wowAddons.Location = new System.Drawing.Point(4, 22);
			this.wowAddons.Name = "wowAddons";
			this.wowAddons.Size = new System.Drawing.Size(528, 230);
			this.wowAddons.TabIndex = 6;
			this.wowAddons.Text = "Updater";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.chAllowDelAddons);
			this.groupBox11.Controls.Add(this.UUUpdaterCheck);
			this.groupBox11.Controls.Add(this.uuSettingsUpdater);
			this.groupBox11.Controls.Add(this.groupBox12);
			this.groupBox11.Controls.Add(this.autoAddonSyncNow);
			this.groupBox11.Controls.Add(this.label12);
			this.groupBox11.Controls.Add(this.AutoAddonURL);
			this.groupBox11.Controls.Add(this.addonAutoUpdate);
			this.groupBox11.Location = new System.Drawing.Point(8, 8);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(472, 216);
			this.groupBox11.TabIndex = 1;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Auto-Updater";
			// 
			// chAllowDelAddons
			// 
			this.chAllowDelAddons.Enabled = false;
			this.chAllowDelAddons.Location = new System.Drawing.Point(8, 40);
			this.chAllowDelAddons.Name = "chAllowDelAddons";
			this.chAllowDelAddons.Size = new System.Drawing.Size(448, 16);
			this.chAllowDelAddons.TabIndex = 10;
			this.chAllowDelAddons.Text = "Allow interface to DELETE addons";
			this.chAllowDelAddons.CheckedChanged += new System.EventHandler(this.chAllowDelAddons_CheckedChanged);
			// 
			// UUUpdaterCheck
			// 
			this.UUUpdaterCheck.Checked = true;
			this.UUUpdaterCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.UUUpdaterCheck.Location = new System.Drawing.Point(8, 72);
			this.UUUpdaterCheck.Name = "UUUpdaterCheck";
			this.UUUpdaterCheck.Size = new System.Drawing.Size(320, 16);
			this.UUUpdaterCheck.TabIndex = 9;
			this.UUUpdaterCheck.Text = "Check for updates to UniUploader";
			this.UUUpdaterCheck.CheckedChanged += new System.EventHandler(this.UUUpdaterCheck_CheckedChanged);
			// 
			// uuSettingsUpdater
			// 
			this.uuSettingsUpdater.Location = new System.Drawing.Point(8, 56);
			this.uuSettingsUpdater.Name = "uuSettingsUpdater";
			this.uuSettingsUpdater.Size = new System.Drawing.Size(344, 16);
			this.uuSettingsUpdater.TabIndex = 8;
			this.uuSettingsUpdater.Text = "Keep My critical UniUploader settings updated";
			this.uuSettingsUpdater.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.label14);
			this.groupBox12.Location = new System.Drawing.Point(8, 144);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(456, 64);
			this.groupBox12.TabIndex = 7;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "WARNING:";
			// 
			// label14
			// 
			this.label14.ForeColor = System.Drawing.Color.Red;
			this.label14.Location = new System.Drawing.Point(8, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(440, 40);
			this.label14.TabIndex = 6;
			this.label14.Text = "This will ONLY synchronize the Addons on your computer with the same ones on the " +
				"website.  DO NOT try to synchronize addons while WoW is running.";
			// 
			// autoAddonSyncNow
			// 
			this.autoAddonSyncNow.Enabled = false;
			this.autoAddonSyncNow.Location = new System.Drawing.Point(384, 96);
			this.autoAddonSyncNow.Name = "autoAddonSyncNow";
			this.autoAddonSyncNow.Size = new System.Drawing.Size(80, 23);
			this.autoAddonSyncNow.TabIndex = 4;
			this.autoAddonSyncNow.Text = "Synchronize";
			this.autoAddonSyncNow.Click += new System.EventHandler(this.autoAddonSyncNow_Click);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 88);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(152, 16);
			this.label12.TabIndex = 3;
			this.label12.Text = "Synchronization URL:";
			// 
			// AutoAddonURL
			// 
			this.AutoAddonURL.Enabled = false;
			this.AutoAddonURL.Location = new System.Drawing.Point(8, 112);
			this.AutoAddonURL.Name = "AutoAddonURL";
			this.AutoAddonURL.Size = new System.Drawing.Size(280, 20);
			this.AutoAddonURL.TabIndex = 2;
			this.AutoAddonURL.Text = "http://XXXXXXX.XXX/uniadmin/interface.php";
			// 
			// addonAutoUpdate
			// 
			this.addonAutoUpdate.Location = new System.Drawing.Point(8, 24);
			this.addonAutoUpdate.Name = "addonAutoUpdate";
			this.addonAutoUpdate.Size = new System.Drawing.Size(272, 16);
			this.addonAutoUpdate.TabIndex = 0;
			this.addonAutoUpdate.Text = "Keep my addons updated";
			this.addonAutoUpdate.CheckedChanged += new System.EventHandler(this.addonAutoUpdate_CheckedChanged);
			// 
			// aceTab
			// 
			this.aceTab.Controls.Add(this.aceGrpbox);
			this.aceTab.Location = new System.Drawing.Point(4, 22);
			this.aceTab.Name = "aceTab";
			this.aceTab.Size = new System.Drawing.Size(528, 230);
			this.aceTab.TabIndex = 8;
			this.aceTab.Text = "Ace Addons";
			// 
			// aceGrpbox
			// 
			this.aceGrpbox.Controls.Add(this.aceProgress);
			this.aceGrpbox.Controls.Add(this.label21);
			this.aceGrpbox.Controls.Add(this.button10);
			this.aceGrpbox.Controls.Add(this.button11);
			this.aceGrpbox.Controls.Add(this.button9);
			this.aceGrpbox.Controls.Add(this.label17);
			this.aceGrpbox.Controls.Add(this.pictureBox8);
			this.aceGrpbox.Controls.Add(this.label18);
			this.aceGrpbox.Controls.Add(this.label19);
			this.aceGrpbox.Controls.Add(this.label20);
			this.aceGrpbox.Controls.Add(this.pictureBox9);
			this.aceGrpbox.Controls.Add(this.pictureBox10);
			this.aceGrpbox.Controls.Add(this.pictureBox11);
			this.aceGrpbox.Controls.Add(this.treeView2);
			this.aceGrpbox.Location = new System.Drawing.Point(8, 8);
			this.aceGrpbox.Name = "aceGrpbox";
			this.aceGrpbox.Size = new System.Drawing.Size(512, 216);
			this.aceGrpbox.TabIndex = 0;
			this.aceGrpbox.TabStop = false;
			this.aceGrpbox.Text = "Ace Addons";
			this.aceGrpbox.VisibleChanged += new System.EventHandler(this.aceGrpbox_VisibleChanged);
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 176);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 16);
			this.label21.TabIndex = 47;
			this.label21.Text = "Progress";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(424, 104);
			this.button10.Name = "button10";
			this.button10.TabIndex = 45;
			this.button10.Text = "Collapse All";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(424, 136);
			this.button11.Name = "button11";
			this.button11.TabIndex = 44;
			this.button11.Text = "Expand All";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(424, 16);
			this.button9.Name = "button9";
			this.button9.TabIndex = 43;
			this.button9.Text = "Install";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(128, 168);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(48, 16);
			this.label17.TabIndex = 42;
			this.label17.Text = "=Name";
			// 
			// pictureBox8
			// 
			this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
			this.pictureBox8.Location = new System.Drawing.Point(112, 168);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(16, 16);
			this.pictureBox8.TabIndex = 41;
			this.pictureBox8.TabStop = false;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(336, 168);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(80, 16);
			this.label18.TabIndex = 40;
			this.label18.Text = "=Version";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(280, 168);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(40, 16);
			this.label19.TabIndex = 39;
			this.label19.Text = "=TOC";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(192, 168);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(72, 16);
			this.label20.TabIndex = 38;
			this.label20.Text = "=Description";
			// 
			// pictureBox9
			// 
			this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
			this.pictureBox9.Location = new System.Drawing.Point(176, 168);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(16, 16);
			this.pictureBox9.TabIndex = 37;
			this.pictureBox9.TabStop = false;
			// 
			// pictureBox10
			// 
			this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
			this.pictureBox10.Location = new System.Drawing.Point(264, 168);
			this.pictureBox10.Name = "pictureBox10";
			this.pictureBox10.Size = new System.Drawing.Size(16, 16);
			this.pictureBox10.TabIndex = 36;
			this.pictureBox10.TabStop = false;
			// 
			// pictureBox11
			// 
			this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
			this.pictureBox11.Location = new System.Drawing.Point(320, 168);
			this.pictureBox11.Name = "pictureBox11";
			this.pictureBox11.Size = new System.Drawing.Size(16, 16);
			this.pictureBox11.TabIndex = 35;
			this.pictureBox11.TabStop = false;
			// 
			// treeView2
			// 
			this.treeView2.CheckBoxes = true;
			this.treeView2.FullRowSelect = true;
			this.treeView2.HotTracking = true;
			this.treeView2.ImageList = this.imageList1;
			this.treeView2.Location = new System.Drawing.Point(8, 16);
			this.treeView2.Name = "treeView2";
			this.treeView2.Size = new System.Drawing.Size(408, 144);
			this.treeView2.TabIndex = 25;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Options
			// 
			this.Options.Controls.Add(this.vargrp);
			this.Options.Controls.Add(this.groupBox4);
			this.Options.Controls.Add(this.groupBox9);
			this.Options.Controls.Add(this.groupBox1);
			this.Options.Location = new System.Drawing.Point(4, 22);
			this.Options.Name = "Options";
			this.Options.Size = new System.Drawing.Size(528, 230);
			this.Options.TabIndex = 1;
			this.Options.Text = "Options";
			// 
			// vargrp
			// 
			this.vargrp.Controls.Add(this.valu4);
			this.vargrp.Controls.Add(this.valu2);
			this.vargrp.Controls.Add(this.valu3);
			this.vargrp.Controls.Add(this.valu1);
			this.vargrp.Controls.Add(this.arrg2);
			this.vargrp.Controls.Add(this.arrg3);
			this.vargrp.Controls.Add(this.arrg4);
			this.vargrp.Controls.Add(this.arrg1);
			this.vargrp.Controls.Add(this.arg2check);
			this.vargrp.Controls.Add(this.arg3check);
			this.vargrp.Controls.Add(this.arg4check);
			this.vargrp.Controls.Add(this.arg1check);
			this.vargrp.Controls.Add(this.sendPwSecurely);
			this.vargrp.Location = new System.Drawing.Point(8, 80);
			this.vargrp.Name = "vargrp";
			this.vargrp.Size = new System.Drawing.Size(184, 144);
			this.vargrp.TabIndex = 24;
			this.vargrp.TabStop = false;
			this.vargrp.Text = "Additional Variables";
			// 
			// valu4
			// 
			this.valu4.Enabled = false;
			this.valu4.Location = new System.Drawing.Point(64, 112);
			this.valu4.Name = "valu4";
			this.valu4.Size = new System.Drawing.Size(110, 20);
			this.valu4.TabIndex = 11;
			this.valu4.Text = "value4";
			// 
			// valu2
			// 
			this.valu2.Enabled = false;
			this.valu2.Location = new System.Drawing.Point(64, 40);
			this.valu2.Name = "valu2";
			this.valu2.PasswordChar = '*';
			this.valu2.Size = new System.Drawing.Size(110, 20);
			this.valu2.TabIndex = 10;
			this.valu2.Text = "value2";
			// 
			// valu3
			// 
			this.valu3.Enabled = false;
			this.valu3.Location = new System.Drawing.Point(64, 88);
			this.valu3.Name = "valu3";
			this.valu3.Size = new System.Drawing.Size(110, 20);
			this.valu3.TabIndex = 9;
			this.valu3.Text = "value3";
			// 
			// valu1
			// 
			this.valu1.Enabled = false;
			this.valu1.Location = new System.Drawing.Point(64, 16);
			this.valu1.Name = "valu1";
			this.valu1.Size = new System.Drawing.Size(110, 20);
			this.valu1.TabIndex = 8;
			this.valu1.Text = "UserName";
			// 
			// arrg2
			// 
			this.arrg2.Enabled = false;
			this.arrg2.Location = new System.Drawing.Point(24, 40);
			this.arrg2.Name = "arrg2";
			this.arrg2.Size = new System.Drawing.Size(40, 20);
			this.arrg2.TabIndex = 7;
			this.arrg2.Text = "password";
			// 
			// arrg3
			// 
			this.arrg3.Enabled = false;
			this.arrg3.Location = new System.Drawing.Point(24, 88);
			this.arrg3.Name = "arrg3";
			this.arrg3.Size = new System.Drawing.Size(40, 20);
			this.arrg3.TabIndex = 6;
			this.arrg3.Text = "arg3";
			// 
			// arrg4
			// 
			this.arrg4.Enabled = false;
			this.arrg4.Location = new System.Drawing.Point(24, 112);
			this.arrg4.Name = "arrg4";
			this.arrg4.Size = new System.Drawing.Size(40, 20);
			this.arrg4.TabIndex = 5;
			this.arrg4.Text = "arg4";
			// 
			// arrg1
			// 
			this.arrg1.Enabled = false;
			this.arrg1.Location = new System.Drawing.Point(24, 16);
			this.arrg1.Name = "arrg1";
			this.arrg1.Size = new System.Drawing.Size(40, 20);
			this.arrg1.TabIndex = 4;
			this.arrg1.Text = "username";
			// 
			// arg2check
			// 
			this.arg2check.Location = new System.Drawing.Point(8, 40);
			this.arg2check.Name = "arg2check";
			this.arg2check.Size = new System.Drawing.Size(16, 16);
			this.arg2check.TabIndex = 3;
			this.arg2check.CheckedChanged += new System.EventHandler(this.arg2check_CheckedChanged);
			// 
			// arg3check
			// 
			this.arg3check.Location = new System.Drawing.Point(8, 88);
			this.arg3check.Name = "arg3check";
			this.arg3check.Size = new System.Drawing.Size(16, 16);
			this.arg3check.TabIndex = 2;
			this.arg3check.CheckedChanged += new System.EventHandler(this.arg3check_CheckedChanged);
			// 
			// arg4check
			// 
			this.arg4check.Location = new System.Drawing.Point(8, 112);
			this.arg4check.Name = "arg4check";
			this.arg4check.Size = new System.Drawing.Size(16, 16);
			this.arg4check.TabIndex = 1;
			this.arg4check.CheckedChanged += new System.EventHandler(this.arg4check_CheckedChanged);
			// 
			// arg1check
			// 
			this.arg1check.Location = new System.Drawing.Point(8, 16);
			this.arg1check.Name = "arg1check";
			this.arg1check.Size = new System.Drawing.Size(148, 16);
			this.arg1check.TabIndex = 0;
			this.arg1check.Text = "Use User/Pass";
			this.arg1check.CheckedChanged += new System.EventHandler(this.arg1check_CheckedChanged);
			// 
			// sendPwSecurely
			// 
			this.sendPwSecurely.Enabled = false;
			this.sendPwSecurely.Location = new System.Drawing.Point(24, 64);
			this.sendPwSecurely.Name = "sendPwSecurely";
			this.sendPwSecurely.Size = new System.Drawing.Size(152, 16);
			this.sendPwSecurely.TabIndex = 3;
			this.sendPwSecurely.Text = "Send Password Securely";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.addurl4);
			this.groupBox4.Controls.Add(this.addurl2);
			this.groupBox4.Controls.Add(this.addurl3);
			this.groupBox4.Controls.Add(this.addurl1);
			this.groupBox4.Controls.Add(this.chaddurl2);
			this.groupBox4.Controls.Add(this.chaddurl3);
			this.groupBox4.Controls.Add(this.chaddurl4);
			this.groupBox4.Controls.Add(this.chaddurl1);
			this.groupBox4.Location = new System.Drawing.Point(200, 104);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(280, 120);
			this.groupBox4.TabIndex = 25;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Additional URL\'s";
			// 
			// addurl4
			// 
			this.addurl4.Enabled = false;
			this.addurl4.Location = new System.Drawing.Point(24, 88);
			this.addurl4.Name = "addurl4";
			this.addurl4.Size = new System.Drawing.Size(248, 20);
			this.addurl4.TabIndex = 11;
			this.addurl4.Text = "http://wherever4.com";
			// 
			// addurl2
			// 
			this.addurl2.Enabled = false;
			this.addurl2.Location = new System.Drawing.Point(24, 40);
			this.addurl2.Name = "addurl2";
			this.addurl2.Size = new System.Drawing.Size(248, 20);
			this.addurl2.TabIndex = 10;
			this.addurl2.Text = "http://wherever2.com";
			// 
			// addurl3
			// 
			this.addurl3.Enabled = false;
			this.addurl3.Location = new System.Drawing.Point(24, 64);
			this.addurl3.Name = "addurl3";
			this.addurl3.Size = new System.Drawing.Size(248, 20);
			this.addurl3.TabIndex = 9;
			this.addurl3.Text = "http://wherever3.com";
			// 
			// addurl1
			// 
			this.addurl1.Enabled = false;
			this.addurl1.Location = new System.Drawing.Point(24, 16);
			this.addurl1.Name = "addurl1";
			this.addurl1.Size = new System.Drawing.Size(248, 20);
			this.addurl1.TabIndex = 8;
			this.addurl1.Text = "http://wherever.com";
			// 
			// chaddurl2
			// 
			this.chaddurl2.Location = new System.Drawing.Point(8, 40);
			this.chaddurl2.Name = "chaddurl2";
			this.chaddurl2.Size = new System.Drawing.Size(16, 16);
			this.chaddurl2.TabIndex = 3;
			this.chaddurl2.CheckedChanged += new System.EventHandler(this.chaddurl2_CheckedChanged);
			// 
			// chaddurl3
			// 
			this.chaddurl3.Location = new System.Drawing.Point(8, 64);
			this.chaddurl3.Name = "chaddurl3";
			this.chaddurl3.Size = new System.Drawing.Size(16, 16);
			this.chaddurl3.TabIndex = 2;
			this.chaddurl3.CheckedChanged += new System.EventHandler(this.chaddurl3_CheckedChanged);
			// 
			// chaddurl4
			// 
			this.chaddurl4.Location = new System.Drawing.Point(8, 88);
			this.chaddurl4.Name = "chaddurl4";
			this.chaddurl4.Size = new System.Drawing.Size(16, 16);
			this.chaddurl4.TabIndex = 1;
			this.chaddurl4.CheckedChanged += new System.EventHandler(this.chaddurl_CheckedChanged);
			// 
			// chaddurl1
			// 
			this.chaddurl1.Location = new System.Drawing.Point(8, 16);
			this.chaddurl1.Name = "chaddurl1";
			this.chaddurl1.Size = new System.Drawing.Size(16, 16);
			this.chaddurl1.TabIndex = 0;
			this.chaddurl1.CheckedChanged += new System.EventHandler(this.chaddurl1_CheckedChanged);
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.stwowlaunch);
			this.groupBox9.Controls.Add(this.stmin);
			this.groupBox9.Controls.Add(this.stboot);
			this.groupBox9.Location = new System.Drawing.Point(8, 8);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(184, 72);
			this.groupBox9.TabIndex = 3;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Startup Options";
			// 
			// stwowlaunch
			// 
			this.stwowlaunch.Location = new System.Drawing.Point(8, 32);
			this.stwowlaunch.Name = "stwowlaunch";
			this.stwowlaunch.Size = new System.Drawing.Size(120, 16);
			this.stwowlaunch.TabIndex = 2;
			this.stwowlaunch.Text = "Auto-Launch WoW";
			this.stwowlaunch.CheckedChanged += new System.EventHandler(this.stwowlaunch_CheckedChanged);
			// 
			// stmin
			// 
			this.stmin.Location = new System.Drawing.Point(8, 48);
			this.stmin.Name = "stmin";
			this.stmin.Size = new System.Drawing.Size(104, 16);
			this.stmin.TabIndex = 1;
			this.stmin.Text = "Start Minimized";
			// 
			// stboot
			// 
			this.stboot.Location = new System.Drawing.Point(8, 16);
			this.stboot.Name = "stboot";
			this.stboot.Size = new System.Drawing.Size(136, 16);
			this.stboot.TabIndex = 0;
			this.stboot.Text = "Start with Windows";
			this.stboot.CheckedChanged += new System.EventHandler(this.stboot_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.userAlbl);
			this.groupBox1.Controls.Add(this.userAgent);
			this.groupBox1.Controls.Add(this.checkBox6);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.autoUploader);
			this.groupBox1.Location = new System.Drawing.Point(200, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 96);
			this.groupBox1.TabIndex = 23;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Miscellaneous";
			// 
			// userAlbl
			// 
			this.userAlbl.Location = new System.Drawing.Point(8, 72);
			this.userAlbl.Name = "userAlbl";
			this.userAlbl.Size = new System.Drawing.Size(64, 16);
			this.userAlbl.TabIndex = 25;
			this.userAlbl.Text = "User Agent:";
			this.userAlbl.Visible = false;
			// 
			// userAgent
			// 
			this.userAgent.Location = new System.Drawing.Point(72, 69);
			this.userAgent.Name = "userAgent";
			this.userAgent.Size = new System.Drawing.Size(200, 20);
			this.userAgent.TabIndex = 24;
			this.userAgent.Text = "";
			this.userAgent.Visible = false;
			// 
			// checkBox6
			// 
			this.checkBox6.Location = new System.Drawing.Point(8, 32);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(162, 16);
			this.checkBox6.TabIndex = 23;
			this.checkBox6.Text = "Always on Top";
			this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
			// 
			// Debugger
			// 
			this.Debugger.Controls.Add(this.label5);
			this.Debugger.Controls.Add(this.dbIEbtn);
			this.Debugger.Controls.Add(this.dbNPbtn);
			this.Debugger.Controls.Add(this.button5);
			this.Debugger.Controls.Add(this.debugSaveAs);
			this.Debugger.Controls.Add(this.DebugBox);
			this.Debugger.Location = new System.Drawing.Point(4, 22);
			this.Debugger.Name = "Debugger";
			this.Debugger.Size = new System.Drawing.Size(528, 230);
			this.Debugger.TabIndex = 7;
			this.Debugger.Text = "Debugger";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(248, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Debug Info";
			// 
			// dbIEbtn
			// 
			this.dbIEbtn.Image = ((System.Drawing.Image)(resources.GetObject("dbIEbtn.Image")));
			this.dbIEbtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.dbIEbtn.Location = new System.Drawing.Point(392, 8);
			this.dbIEbtn.Name = "dbIEbtn";
			this.dbIEbtn.Size = new System.Drawing.Size(24, 24);
			this.dbIEbtn.TabIndex = 4;
			this.dbIEbtn.Click += new System.EventHandler(this.dbIEbtn_Click);
			// 
			// dbNPbtn
			// 
			this.dbNPbtn.Image = ((System.Drawing.Image)(resources.GetObject("dbNPbtn.Image")));
			this.dbNPbtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.dbNPbtn.Location = new System.Drawing.Point(360, 8);
			this.dbNPbtn.Name = "dbNPbtn";
			this.dbNPbtn.Size = new System.Drawing.Size(24, 24);
			this.dbNPbtn.TabIndex = 3;
			this.dbNPbtn.Click += new System.EventHandler(this.dbNPbtn_Click);
			// 
			// button5
			// 
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button5.Location = new System.Drawing.Point(424, 8);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(24, 24);
			this.button5.TabIndex = 2;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// debugSaveAs
			// 
			this.debugSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("debugSaveAs.Image")));
			this.debugSaveAs.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.debugSaveAs.Location = new System.Drawing.Point(456, 8);
			this.debugSaveAs.Name = "debugSaveAs";
			this.debugSaveAs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.debugSaveAs.Size = new System.Drawing.Size(24, 24);
			this.debugSaveAs.TabIndex = 1;
			this.debugSaveAs.Click += new System.EventHandler(this.debugSaveAs_Click);
			// 
			// DebugBox
			// 
			this.DebugBox.HorizontalScrollbar = true;
			this.DebugBox.Location = new System.Drawing.Point(8, 32);
			this.DebugBox.Name = "DebugBox";
			this.DebugBox.Size = new System.Drawing.Size(472, 186);
			this.DebugBox.TabIndex = 0;
			// 
			// Help
			// 
			this.Help.Controls.Add(this.button8);
			this.Help.Controls.Add(this.button3);
			this.Help.Controls.Add(this.button4);
			this.Help.Controls.Add(this.button2);
			this.Help.Controls.Add(this.button1);
			this.Help.Controls.Add(this.richTextBox1);
			this.Help.Location = new System.Drawing.Point(4, 22);
			this.Help.Name = "Help";
			this.Help.Size = new System.Drawing.Size(528, 230);
			this.Help.TabIndex = 4;
			this.Help.Text = "Help";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(96, 8);
			this.button8.Name = "button8";
			this.button8.TabIndex = 6;
			this.button8.Text = "Updater";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(264, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(80, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Advanced";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(352, 8);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(80, 23);
			this.button4.TabIndex = 4;
			this.button4.Text = "Information";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(176, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Options";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Settings";
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// richTextBox1
			// 
			this.richTextBox1.AcceptsTab = true;
			this.richTextBox1.AllowDrop = true;
			this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.richTextBox1.Location = new System.Drawing.Point(0, 32);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(480, 184);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// About
			// 
			this.About.Controls.Add(this.copyrightInfoLabel);
			this.About.Controls.Add(this.groupBox2);
			this.About.Location = new System.Drawing.Point(4, 22);
			this.About.Name = "About";
			this.About.Size = new System.Drawing.Size(528, 230);
			this.About.TabIndex = 3;
			this.About.Text = "About";
			// 
			// copyrightInfoLabel
			// 
			this.copyrightInfoLabel.Location = new System.Drawing.Point(8, 208);
			this.copyrightInfoLabel.Name = "copyrightInfoLabel";
			this.copyrightInfoLabel.Size = new System.Drawing.Size(464, 16);
			this.copyrightInfoLabel.TabIndex = 22;
			this.copyrightInfoLabel.Text = "The World of Warcraft logo and name are © Blizzard Entertainment.";
			// 
			// response
			// 
			this.response.Controls.Add(this.respOpenIE2);
			this.response.Controls.Add(this.respOpenNP2);
			this.response.Controls.Add(this.respOpenIE);
			this.response.Controls.Add(this.respOpenNP);
			this.response.Controls.Add(this.ClearSiteWoW);
			this.response.Controls.Add(this.ClearServResp);
			this.response.Controls.Add(this.servResponseSaveas);
			this.response.Controls.Add(this.siteToWowSaveas);
			this.response.Controls.Add(this.retrdatawindow);
			this.response.Controls.Add(this.label7);
			this.response.Controls.Add(this.label6);
			this.response.Controls.Add(this.servResponse);
			this.response.Location = new System.Drawing.Point(4, 22);
			this.response.Name = "response";
			this.response.Size = new System.Drawing.Size(528, 230);
			this.response.TabIndex = 2;
			this.response.Text = "Server Response";
			// 
			// respOpenIE2
			// 
			this.respOpenIE2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.respOpenIE2.Image = ((System.Drawing.Image)(resources.GetObject("respOpenIE2.Image")));
			this.respOpenIE2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.respOpenIE2.Location = new System.Drawing.Point(392, 136);
			this.respOpenIE2.Name = "respOpenIE2";
			this.respOpenIE2.Size = new System.Drawing.Size(24, 24);
			this.respOpenIE2.TabIndex = 31;
			this.respOpenIE2.Click += new System.EventHandler(this.respOpenIE2_Click);
			// 
			// respOpenNP2
			// 
			this.respOpenNP2.Image = ((System.Drawing.Image)(resources.GetObject("respOpenNP2.Image")));
			this.respOpenNP2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.respOpenNP2.Location = new System.Drawing.Point(360, 136);
			this.respOpenNP2.Name = "respOpenNP2";
			this.respOpenNP2.Size = new System.Drawing.Size(24, 24);
			this.respOpenNP2.TabIndex = 30;
			this.respOpenNP2.Click += new System.EventHandler(this.respOpenNP2_Click);
			// 
			// respOpenIE
			// 
			this.respOpenIE.Image = ((System.Drawing.Image)(resources.GetObject("respOpenIE.Image")));
			this.respOpenIE.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.respOpenIE.Location = new System.Drawing.Point(392, 8);
			this.respOpenIE.Name = "respOpenIE";
			this.respOpenIE.Size = new System.Drawing.Size(24, 24);
			this.respOpenIE.TabIndex = 29;
			this.respOpenIE.Click += new System.EventHandler(this.respOpenIE_Click);
			// 
			// respOpenNP
			// 
			this.respOpenNP.Image = ((System.Drawing.Image)(resources.GetObject("respOpenNP.Image")));
			this.respOpenNP.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.respOpenNP.Location = new System.Drawing.Point(360, 8);
			this.respOpenNP.Name = "respOpenNP";
			this.respOpenNP.Size = new System.Drawing.Size(24, 24);
			this.respOpenNP.TabIndex = 28;
			this.respOpenNP.Click += new System.EventHandler(this.respOpenNP_Click);
			// 
			// ClearSiteWoW
			// 
			this.ClearSiteWoW.Image = ((System.Drawing.Image)(resources.GetObject("ClearSiteWoW.Image")));
			this.ClearSiteWoW.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.ClearSiteWoW.Location = new System.Drawing.Point(424, 136);
			this.ClearSiteWoW.Name = "ClearSiteWoW";
			this.ClearSiteWoW.Size = new System.Drawing.Size(24, 24);
			this.ClearSiteWoW.TabIndex = 27;
			this.ClearSiteWoW.Click += new System.EventHandler(this.ClearSiteWoW_Click);
			// 
			// ClearServResp
			// 
			this.ClearServResp.Image = ((System.Drawing.Image)(resources.GetObject("ClearServResp.Image")));
			this.ClearServResp.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.ClearServResp.Location = new System.Drawing.Point(424, 8);
			this.ClearServResp.Name = "ClearServResp";
			this.ClearServResp.Size = new System.Drawing.Size(24, 24);
			this.ClearServResp.TabIndex = 26;
			this.ClearServResp.Click += new System.EventHandler(this.ClearServResp_Click);
			// 
			// servResponseSaveas
			// 
			this.servResponseSaveas.Image = ((System.Drawing.Image)(resources.GetObject("servResponseSaveas.Image")));
			this.servResponseSaveas.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.servResponseSaveas.Location = new System.Drawing.Point(456, 8);
			this.servResponseSaveas.Name = "servResponseSaveas";
			this.servResponseSaveas.Size = new System.Drawing.Size(24, 24);
			this.servResponseSaveas.TabIndex = 25;
			this.servResponseSaveas.Click += new System.EventHandler(this.servResponseSaveas_Click);
			// 
			// siteToWowSaveas
			// 
			this.siteToWowSaveas.Image = ((System.Drawing.Image)(resources.GetObject("siteToWowSaveas.Image")));
			this.siteToWowSaveas.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.siteToWowSaveas.Location = new System.Drawing.Point(456, 136);
			this.siteToWowSaveas.Name = "siteToWowSaveas";
			this.siteToWowSaveas.Size = new System.Drawing.Size(24, 24);
			this.siteToWowSaveas.TabIndex = 24;
			this.siteToWowSaveas.Click += new System.EventHandler(this.siteToWowSaveas_Click);
			// 
			// retrdatawindow
			// 
			this.retrdatawindow.AcceptsReturn = true;
			this.retrdatawindow.AcceptsTab = true;
			this.retrdatawindow.Location = new System.Drawing.Point(8, 160);
			this.retrdatawindow.Multiline = true;
			this.retrdatawindow.Name = "retrdatawindow";
			this.retrdatawindow.ReadOnly = true;
			this.retrdatawindow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.retrdatawindow.Size = new System.Drawing.Size(472, 64);
			this.retrdatawindow.TabIndex = 22;
			this.retrdatawindow.Text = "Data to be inserted into SavedVariables.lua will be displayed here.";
			this.retrdatawindow.WordWrap = false;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(240, 16);
			this.label7.TabIndex = 21;
			this.label7.Text = "File Upload Response from Website:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(248, 16);
			this.label6.TabIndex = 20;
			this.label6.Text = "Website ===> SavedVariables.lua Data:";
			// 
			// servResponse
			// 
			this.servResponse.AcceptsReturn = true;
			this.servResponse.AcceptsTab = true;
			this.servResponse.Location = new System.Drawing.Point(8, 32);
			this.servResponse.Multiline = true;
			this.servResponse.Name = "servResponse";
			this.servResponse.ReadOnly = true;
			this.servResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.servResponse.Size = new System.Drawing.Size(472, 96);
			this.servResponse.TabIndex = 19;
			this.servResponse.Text = "Any Data returned by primary URL will be displayed here.";
			this.servResponse.WordWrap = false;
			// 
			// clearSVFiles
			// 
			this.clearSVFiles.Location = new System.Drawing.Point(8, 192);
			this.clearSVFiles.Name = "clearSVFiles";
			this.clearSVFiles.Size = new System.Drawing.Size(112, 23);
			this.clearSVFiles.TabIndex = 21;
			this.clearSVFiles.Text = "Clear SV Contents";
			this.clearSVFiles.Click += new System.EventHandler(this.clearSVFiles_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.SVList);
			this.groupBox3.Controls.Add(this.clearSVFiles);
			this.groupBox3.Location = new System.Drawing.Point(544, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(128, 224);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Saved Variables";
			// 
			// SVList
			// 
			this.SVList.CheckOnClick = true;
			this.SVList.Location = new System.Drawing.Point(8, 16);
			this.SVList.Name = "SVList";
			this.SVList.Size = new System.Drawing.Size(112, 169);
			this.SVList.TabIndex = 21;
			this.SVList.SelectedIndexChanged += new System.EventHandler(this.SVList_SelectedIndexChanged);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 250);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(530, 22);
			this.statusBar1.SizingGrip = false;
			this.statusBar1.TabIndex = 19;
			this.statusBar1.Text = "Idle";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.Text = "Idle";
			this.statusBarPanel1.Width = 530;
			// 
			// mini_timer
			// 
			this.mini_timer.Interval = 1000;
			this.mini_timer.Tick += new System.EventHandler(this.mini_timer_Tick);
			// 
			// Upload_Timer
			// 
			this.Upload_Timer.Tick += new System.EventHandler(this.Upload_Timer_Tick);
			// 
			// close_timer
			// 
			this.close_timer.Interval = 1000;
			this.close_timer.Tick += new System.EventHandler(this.close_timer_Tick);
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage1);
			this.tabControl2.Controls.Add(this.tabPage8);
			this.tabControl2.Location = new System.Drawing.Point(0, 0);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(496, 256);
			this.tabControl2.TabIndex = 20;
			this.tabControl2.Visible = false;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox14);
			this.tabPage1.Controls.Add(this.groupBox15);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(488, 230);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Settings";
			// 
			// groupBox14
			// 
			this.groupBox14.Location = new System.Drawing.Point(312, 3);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(160, 85);
			this.groupBox14.TabIndex = 24;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Upload Access";
			// 
			// groupBox15
			// 
			this.groupBox15.Location = new System.Drawing.Point(312, 88);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(160, 72);
			this.groupBox15.TabIndex = 3;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Startup Options";
			// 
			// tabPage8
			// 
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(488, 230);
			this.tabPage8.TabIndex = 3;
			this.tabPage8.Text = "About";
			this.tabPage8.Visible = false;
			// 
			// filesysDelay
			// 
			this.filesysDelay.Enabled = true;
			this.filesysDelay.Interval = 5000;
			this.filesysDelay.Tick += new System.EventHandler(this.filesysDelay_Tick);
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.addonSyncBtn);
			this.groupBox8.Controls.Add(this.label16);
			this.groupBox8.Controls.Add(this.pictureBox7);
			this.groupBox8.Controls.Add(this.label13);
			this.groupBox8.Controls.Add(this.label10);
			this.groupBox8.Controls.Add(this.label9);
			this.groupBox8.Controls.Add(this.pictureBox6);
			this.groupBox8.Controls.Add(this.pictureBox5);
			this.groupBox8.Controls.Add(this.pictureBox4);
			this.groupBox8.Controls.Add(this.button7);
			this.groupBox8.Controls.Add(this.button6);
			this.groupBox8.Controls.Add(this.label8);
			this.groupBox8.Controls.Add(this.treeView1);
			this.groupBox8.Location = new System.Drawing.Point(8, 256);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(480, 168);
			this.groupBox8.TabIndex = 21;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Addons";
			// 
			// addonSyncBtn
			// 
			this.addonSyncBtn.Location = new System.Drawing.Point(400, 112);
			this.addonSyncBtn.Name = "addonSyncBtn";
			this.addonSyncBtn.TabIndex = 35;
			this.addonSyncBtn.Text = "Synchronize";
			this.addonSyncBtn.Click += new System.EventHandler(this.addonSyncBtn_Click);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(32, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(48, 16);
			this.label16.TabIndex = 34;
			this.label16.Text = "=Name";
			// 
			// pictureBox7
			// 
			this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
			this.pictureBox7.Location = new System.Drawing.Point(16, 16);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(16, 16);
			this.pictureBox7.TabIndex = 33;
			this.pictureBox7.TabStop = false;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(240, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(80, 16);
			this.label13.TabIndex = 32;
			this.label13.Text = "=Version";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(184, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 16);
			this.label10.TabIndex = 31;
			this.label10.Text = "=TOC";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(96, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 30;
			this.label9.Text = "=Description";
			// 
			// pictureBox6
			// 
			this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
			this.pictureBox6.Location = new System.Drawing.Point(80, 16);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(16, 16);
			this.pictureBox6.TabIndex = 29;
			this.pictureBox6.TabStop = false;
			// 
			// pictureBox5
			// 
			this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
			this.pictureBox5.Location = new System.Drawing.Point(168, 16);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(16, 16);
			this.pictureBox5.TabIndex = 28;
			this.pictureBox5.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(224, 16);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(16, 16);
			this.pictureBox4.TabIndex = 27;
			this.pictureBox4.TabStop = false;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(400, 136);
			this.button7.Name = "button7";
			this.button7.TabIndex = 26;
			this.button7.Text = "Collapse All";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(320, 136);
			this.button6.Name = "button6";
			this.button6.TabIndex = 25;
			this.button6.Text = "Expand All";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(320, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(152, 96);
			this.label8.TabIndex = 0;
			this.label8.Text = "These are addons which UniAdmin has available to be automatically updated on your" +
				" system.  The addons which are marked \"required\" in UniAdmin can\'t be unchecked." +
				"";
			// 
			// treeView1
			// 
			this.treeView1.CheckBoxes = true;
			this.treeView1.FullRowSelect = true;
			this.treeView1.HotTracking = true;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(8, 32);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(304, 128);
			this.treeView1.TabIndex = 24;
			this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.node_AfterCheck);
			this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
			this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
			this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(504, 264);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(120, 112);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 22;
			this.pictureBox3.TabStop = false;
			// 
			// aceProgress
			// 
			this.aceProgress.Location = new System.Drawing.Point(8, 192);
			this.aceProgress.Name = "aceProgress";
			this.aceProgress.Size = new System.Drawing.Size(488, 16);
			this.aceProgress.TabIndex = 48;
			// 
			// Form1
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(530, 272);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox8);
			this.Controls.Add(this.pictureBox3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1160, 608);
			this.MinimumSize = new System.Drawing.Size(500, 287);
			this.Name = "Form1";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UniUploader";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.myTimer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.myTimer2)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.Settings.ResumeLayout(false);
			this.configGroup.ResumeLayout(false);
			this.Advanced.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.otherexes.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.wowAddons.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.aceTab.ResumeLayout(false);
			this.aceGrpbox.ResumeLayout(false);
			this.Options.ResumeLayout(false);
			this.vargrp.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.Debugger.ResumeLayout(false);
			this.Help.ResumeLayout(false);
			this.About.ResumeLayout(false);
			this.response.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		///	<summary>
		///	The	main entry point for the application.
		///	</summary>
		[STAThread]
		static void	Main() 
		{
			try
			{
				Application.Run(new	Form1());
			}
			catch(Exception ex)
			{
				if (ex.GetType() == typeof(System.Security.SecurityException))
					MessageBox.Show("UniUploader is unable to run due to constraints set by the current .NET Framework security policy.","Failure",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Stop);
				else
					MessageBox.Show(ex.ToString(),"Failure",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Stop);
			}
		}



		private	void Form1_Load(object sender, System.EventArgs	e)
		{
			windowstate = "starting";
			IsUploading = true;
			DebugLine(_STING);
			DebugLine(".NET Framework "+System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion());
			Thread.CurrentThread.Name = "Main thread";

			statusBarPanel1.Text = _INIT;
			UUuserAgent = buildUserAgent();
			userAgent.Text = UUuserAgent;
			version.Text = uniVersionMajor + "." +uniVersionMinor + "." +uniVersionRevision;
			libLink.Links.Remove(libLink.Links[0]);
			libLink.Links.Add(0, libLink.Text.Length, "http://wowroster.net");
			this.Resize += new EventHandler(Form1_Resize);
			notifyIcon1.DoubleClick += new EventHandler(notifyIcon1_DoubleClick); 

			watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Attributes |  NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
			watcher.Changed += new FileSystemEventHandler(OnChanged);
			newWatcher.Created += new FileSystemEventHandler(newWatcherHandler);


			PopulateLanguageSelector();
			
			
			ReadSettings();
			populateAccountList();
			populateSvList();
			SwitchMode();
			setupWatchers();

			



			if (stmin.Checked)
			{
				if (checkBox1.Checked)
				{
					windowstate = "min";
					WindowState = FormWindowState.Normal;
					WindowState = FormWindowState.Minimized;
					mini_timer.Enabled = true;
					mini_timer.Start();


					//Hide(); //for some reason this doesent always work, is it timing?
				}
				else
				{
					WindowState = FormWindowState.Minimized;
				}
			}

			if(stwowlaunch.Checked){LaunchWoW();}

			Upload_Timer.Enabled = true;
			Upload_Timer.Stop();
			close_timer.Enabled = true;
			close_timer.Stop();

			myTimer.Enabled = false;
			/*
			if(checkBox6.Checked==true)
			{
				Form1.ActiveForm.TopMost=true;
				
			}
			*/
			if (addonAutoUpdate.Checked || uuSettingsUpdater.Checked || UUUpdaterCheck.Checked)
			{
				autoAddonSyncNow_Click(null,new System.EventArgs());
			}
			

			string UUPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","");

			try 
			{
				if (File.Exists(UUPath + @"\logo1.gif"))
				{
					pictureBox1.Image = Image.FromFile(UUPath + @"\logo1.gif");
				}
				if (File.Exists(UUPath + @"\logo2.gif"))
				{
					pictureBox2.Image = Image.FromFile(UUPath + @"\logo2.gif");
				}
			}
			catch (Exception err)
			{
				DebugLine(@"Form1_load, pictureBoxX.Image = Image.FromFile(UUPath + @""\logoX.gif"");:"+err.Message);
			}


			if (exeOnUuStart.Checked)
			{
				LaunchEXEs();
			}


			if (retrdatafromsite.Checked)
			{
				doWebsiteToWow();
			}


			if (testVersion)
			{
				UUUpdaterCheck.Checked = false;
				UUUpdaterCheck.Enabled = false;
			}
			populateContextMenu2();

			string uuver = uniVersionMajor+"."+uniVersionMinor+"."+uniVersionRevision;
			DebugLine("v"+uuver+" "+_READY);
			statusBarPanel1.Text = _READY;
			IsUploading = false;
			windowstate = "";

			//UpdateAddons();
		}

		private void setupWatchers()
		{
			string InstallPath = GetInstallPath();
			string goodpath = InstallPath+"\\WTF\\Account\\"+AccountList.SelectedItem;
			if (Directory.Exists(goodpath))
			{
				mainSvLocation = goodpath+"\\SavedVariables.lua";
			}

			if (Directory.Exists(mainSvLocation.Replace(".lua","")))
			{
				watcher.Path = mainSvLocation.Replace(".lua","");
				watcher.EnableRaisingEvents = true;
				newWatcher.EnableRaisingEvents = false;
			}
			else
			{
				// the savedvariables directory isn't there
				// disable file watcher
				newWatcher.Path = "";
				newWatcher.EnableRaisingEvents = false;
			}

		}
		private void doLogos(string url)
		{
			string filename = Path.GetFileName(url);
			string serverMD5 = RetrData(AutoAddonURL.Text,null,null,"OPERATION","GETFILEMD5","FILENAME",filename,null,null,20000,null,null);
			if (serverMD5 != "")
			{
				string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\","") + "\\" + filename;
				string md5sum = "";
				if (File.Exists(path))
				{
					md5sum = MD5SUM(FileToByteArray(path));
					DebugLine("MD5SUM of local " + filename + ": " + md5sum);
				}

				if (md5sum != serverMD5)
				{
					updateLogo(url);
				}
			}
		}
		private	void upload()
		{
			UploadNow.Enabled=false;
			GC.Collect();
			GC.WaitForPendingFinalizers();

			IsUploading = true;
			servResponse.Clear();
			
			string path = mainSvLocation.Replace(".lua","");
			//string file = "";

			string param1;
			string param2;
			string param3;
			string param4;

			string val1;
			string val2;
			string val3;
			string val4;
			string responseFromServer = "";
			string CRLF = Environment.NewLine; // \r\n

			if (arg1check.Checked == true){param1 = arrg1.Text; val1 = valu1.Text;}	
			else{param1 = null; val1 = null;}
			if (arg2check.Checked == true)
			{
				param2 = arrg2.Text;
				if (sendPwSecurely.Checked)
					val2 = MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text));
				else
					val2 = valu2.Text;
			}

			else{param2 = null; val2 = null;}
			if (arg3check.Checked == true){param3 = arrg3.Text; val3 = valu3.Text;}	
			else{param3 = null; val3 = null;}
			if (arg4check.Checked == true){param4 = arrg4.Text; val4 = valu4.Text;}	
			else{param4 = null; val4 = null;}

			if (retrdatafromsite.Checked && chWtoWOWbeforeUpload.Checked)
			{
				doWebsiteToWow();
			}

			//do the primary URL
			statusBarPanel1.Text = _UPLOADING_PRIMARY + " - "+ URL.Text;
			DebugLine(_UPLOADING_PRIMARY + ": "+ URL.Text);
			responseFromServer = Upload(null,	URL.Text,	null,	null,null,param1,param2,param3,param4,val1,val2,val3,val4);
			responseFromServer = responseFromServer.Replace("\n",CRLF);
			responseFromServer = servResponse.Text + "<!-- ############ "+ _UPLOADING_PRIMARY +CRLF+
				"     ############ " + URL.Text  + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF;
			servResponse.Text = responseFromServer;

			if (chaddurl1.Checked)
			{
				statusBarPanel1.Text = _UPLOADING_ADDURL1 + " - "+ addurl1.Text;
				DebugLine(_UPLOADING_ADDURL1 + " - "+ addurl1.Text);
				responseFromServer = Upload(null,	addurl1.Text,	null,	null,null,param1,param2,param3,param4,val1,val2,val3,val4);
				responseFromServer = responseFromServer.Replace("\n",CRLF);
				responseFromServer = servResponse.Text + "<!-- ############ "+ _UPLOADING_ADDURL1 +CRLF+
					"     ############ " + addurl1.Text  + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF;
				servResponse.Text = responseFromServer;
			}
			if (chaddurl2.Checked)
			{
				statusBarPanel1.Text = _UPLOADING_ADDURL2 + " - "+ addurl2.Text;
				DebugLine(_UPLOADING_ADDURL2 + " - "+ addurl2.Text);
				responseFromServer = Upload(null,	addurl2.Text,	null,	null,null,param1,param2,param3,param4,val1,val2,val3,val4);
				responseFromServer = responseFromServer.Replace("\n",CRLF);
				responseFromServer = servResponse.Text + "<!-- ############ "+ _UPLOADING_ADDURL2 +CRLF+
					"     ############ " + addurl2.Text  + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF;
				servResponse.Text = responseFromServer;
			}
			if (chaddurl3.Checked)
			{
				statusBarPanel1.Text = _UPLOADING_ADDURL3 + " - "+ addurl3.Text;
				DebugLine(_UPLOADING_ADDURL3 + " - "+ addurl3.Text);
				responseFromServer = Upload(null,	addurl3.Text,	null,	null,null,param1,param2,param3,param4,val1,val2,val3,val4);
				responseFromServer = responseFromServer.Replace("\n",CRLF);
				responseFromServer = servResponse.Text + "<!-- ############ "+ _UPLOADING_ADDURL3 +CRLF+
					"     ############ " + addurl3.Text  + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF;
				servResponse.Text = responseFromServer;
			}
			if (chaddurl4.Checked)
			{
				statusBarPanel1.Text = _UPLOADING_ADDURL4 + " - "+ addurl4.Text;
				DebugLine(_UPLOADING_ADDURL4 + " - "+ addurl4.Text);
				responseFromServer = Upload(null,	addurl4.Text,	null,	null,null,param1,param2,param3,param4,val1,val2,val3,val4);
				responseFromServer = responseFromServer.Replace("\n",CRLF);
				responseFromServer = servResponse.Text + "<!-- ############ "+ _UPLOADING_ADDURL4 +CRLF+
					"     ############ " + addurl4.Text  + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF;
				servResponse.Text = responseFromServer;
			}
			

			if (retrdatafromsite.Checked && chWtoWOWafterUpload.Checked)
			{
				doWebsiteToWow();
			}
			
			myTimer2.Interval = 2000;
			myTimer2.Enabled = true;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			UploadNow.Enabled=true;
			statusBarPanel1.Text = _READY;
			//UploadThread.Abort();
			
		}

		public void doWebsiteToWow()
		{
			statusBarPanel1.Text = _RETRDATA;
			string retrdatadfromsite = "";
			string pw = "";
			if (sendPwSecurely.Checked)
				pw = MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text));
			else
				pw = valu2.Text;

			if (arg1check.Checked && arg2check.Checked)
			{


				retrdatadfromsite = RetrData(retrDataUrl.Text,null,null,"OPERATION","GETDATA",arrg1.Text,valu1.Text,arrg2.Text,pw,-1,null,null);
			}
			else
			{
				retrdatadfromsite = RetrData(retrDataUrl.Text,null,null,"OPERATION","GETDATA",null,null,null,null,-1,null,null);
			}
			retrdatawindow.Lines = retrdatadfromsite.Split(new Char[] {'\n'});
			statusBarPanel1.Text = _WRITINGSV;
			string filename = "";
			if (webWoWSvFile.Text != "SavedVariables.lua")
			{
				filename = mainSvLocation.Replace(".lua","") + @"\" + webWoWSvFile.Text;
			}
			else
			{
				filename = mainSvLocation;
			}

			byte[]  finalArray = new UTF8Encoding().GetBytes(retrdatadfromsite  + "\n"); //i think its UTF8 default?

			System.IO.FileMode accessType = System.IO.FileMode.Append;
			if (!File.Exists(filename))
			{
				accessType = System.IO.FileMode.Create;
			}
			else
			{
				if (purgefirstCh.Checked)
				{
                    accessType = System.IO.FileMode.Truncate;
				}
				else
				{
                    accessType = System.IO.FileMode.Append;
				}
			}

			using (FileStream inFile = new FileStream(filename, accessType)) 
			{
				inFile.Write(finalArray,0,finalArray.Length);
				inFile.Close();
			}
			
			
			statusBarPanel1.Text = _READY;
		}

		private	string ReadFileToString(string fullPath)
		{
			string FileString = "";
			try 
			{
				StreamReader sr = new StreamReader(new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
				string s = sr.ReadToEnd();
				sr.Close();
				FileString = s;
			}
			catch (Exception e) 
			{
				DebugLine(_CANTREADFILE+": "+e.Message);
			}
			return FileString;
		}

		private	void ReadSettings()
		{
			string file = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","")+"\\settings.ini";
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
							string settingValue = ini.GetValue(category,key);
							bool settingValueBool;
							try
							{
								settingValueBool = Convert.ToBoolean(settingValue);
							}
							catch
							{
								settingValueBool = false;
							}
							switch (key)
							{
									#region cases

								case "PURGEFIRST":
									purgefirstCh.Checked = settingValueBool;
									break;

								case "ALLOWADDONDEL":
									chAllowDelAddons.Checked = settingValueBool;
									break;

								case "SELECTEDACCT":
									selectedAcc = settingValue;
									break;

									//case "SELECTEDACCT":
									//	AccountList.SelectedItem = settingValue;
									//	break;


								case "WEBWOWSVFILE":
									webWoWSvFile.Text = settingValue;
									break;

								case "AUTODETECTWOW":
									AutoInstallDirDetect.Checked = settingValueBool;
									break;

								case "EXELOC":
									if (Directory.Exists(settingValue))
										wowExeLoc = settingValue;
									populateAccountList();
									populateSvList();
									setupWatchers();
									break;

								case "USERAGENT":
									//userAgent.Text = settingValue;
									break;

									

								case "WOWARGS":
									launchWoWargs.Text = settingValue;
									break;



								case "PRIMARYURL":
									URL.Text = settingValue;
									break;

								case "USELAUNCHER":
									chUseLauncher.Checked = settingValueBool;
									break;

								case "DOWNLOADAFTERUPLOAD":
									chWtoWOWafterUpload.Checked = settingValueBool;
									break;

								case "DOWNLOADBEFOREUPLOAD":
									chWtoWOWbeforeUpload.Checked = settingValueBool;
									break;

								case "DOWNLOADBEFOREWOWL":
									chWtoWOWbeforeWOWLaunch.Checked = settingValueBool;
									break;

								case "SENDPWSECURE":
									sendPwSecurely.Checked = settingValueBool;
									break;

								case "CHECKEDSVLIST":
									checkedSVsFromSettings = settingValue.Split('|');
									break;

								case "CHECKEDADDONS":
									string[] cas = settingValue.Split('|');
									foreach(string ca in cas)
									{
										checkedAddons.Add(ca);
									}
									break;

								
								case "EXEUULAUNCH":
									exeOnUuStart.Checked = settingValueBool;
									break;
								case "EXEWOWLAUNCH":
									exeOnWowLaunch.Checked = settingValueBool;
									break;
								case "EXE1":
									exe1.Checked = settingValueBool;
									break;
								case "EXE2":
									exe2.Checked = settingValueBool;
									break;
								case "EXE3":
									exe3.Checked = settingValueBool;
									break;
								case "EXE1LOCATION":
									exe1Location.Text = settingValue;
									break;
								case "EXE2LOCATION":
									exe2Location.Text = settingValue;
									break;
								case "EXE3LOCATION":
									exe3Location.Text = settingValue;
									break;
								

								case "FILELOCATION":
									if (!PathFound)
									{
										mainSvLocation = settingValue;
										populateAccountList();
										populateSvList();
										setupWatchers();
										if (!File.Exists(mainSvLocation))
										{
											if (ProgramMode == "Basic")
											{
												//this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {this.browse});
												//DebugLine("Please click Browse to select the SV file.");

											}

										}
										else
										{
											PathFound = true;
										}
									
									}
									break;
								case "PROGRAMMODE":
									if (settingValue == "Advanced")
									{
										SwitchMode();
									}
									break;

								case "WINDOWMODE":
									windowmode.Checked = settingValueBool;
									break;
								case "OPENGL":
									OpenGl.Checked = settingValueBool;
									break;

								case "RETRDATAURL":
									retrDataUrl.Text = settingValue;
									break;							
								case "ADDONAUTOUPDATE":
									addonAutoUpdate.Checked = settingValueBool;
									break;
								case "UUSETTINGSUPDATER":
									uuSettingsUpdater.Checked = settingValueBool;
									break;
								case "UUUPDATERCHECK":
									UUUpdaterCheck.Checked = settingValueBool;
									break;
								case "SYNCHROURL":
									AutoAddonURL.Text = settingValue;
									break;
								case "LANGUAGE":
									try 
									{
										Language = settingValue;
										langselect.SelectedItem = settingValue;
									}
									catch (Exception e)
									{
										DebugLine(e.Message);
									}
									break;

								case "SYSTRAY":
									checkBox1.Checked = settingValueBool;
									break;
								case "ALWAYSONTOP":
									checkBox6.Checked = settingValueBool;
									break;
								case "AUTOUPLOADONFILECHANGES":
									autoUploader.Checked = settingValueBool;
									break;
								case "ADDVAR1CH":
									arg1check.Checked = settingValueBool;
									break;
								case "ADDVAR2CH":
									arg2check.Checked = settingValueBool;
									break;
								case "ADDVAR3CH":
									arg3check.Checked = settingValueBool;
									break;
								case "ADDVAR4CH":
									arg4check.Checked = settingValueBool;
									break;
								case "ADDURL1CH":
									chaddurl1.Checked = settingValueBool;
									break;
								case "ADDURL2CH":
									chaddurl2.Checked = settingValueBool;
									break;
								case "ADDURL3CH":
									chaddurl3.Checked = settingValueBool;
									break;
								case "ADDURL4CH":
									chaddurl4.Checked = settingValueBool;
									break;
								case "ADDVARNAME1":
									arrg1.Text = settingValue;
									break;
								case "ADDVARNAME2":
									arrg2.Text = settingValue;
									break;
								case "ADDVARNAME3":
									arrg3.Text = settingValue;
									break;
								case "ADDVARNAME4":
									arrg4.Text = settingValue;
									break;
								case "ADDVARVAL1":
									valu1.Text = settingValue;
									break;
								case "ADDVARVAL2":
									valu2.Text = settingValue;
									break;
								case "ADDVARVAL3":
									valu3.Text = settingValue;
									break;
								case "ADDVARVAL4":
									valu4.Text = settingValue;
									break;
								case "ADDURL1":
									addurl1.Text = settingValue;
									break;
								case "ADDURL2":
									addurl2.Text = settingValue;
									break;
								case "ADDURL3":
									addurl3.Text = settingValue;
									break;
								case "ADDURL4":
									addurl4.Text = settingValue;
									break;

								case "GZIP":
									GZcompress.Checked = settingValueBool;
									break;
								case "RETRDATAFROMSITE":
									retrDataUrl.Enabled = settingValueBool;
									retrdatafromsite.Checked = settingValueBool;
									break;

								case "STARTWITHWINDOWS":
									stboot.Checked = settingValueBool;
									if (settingValueBool)
										DebugLine(InstallStartupKey());
									else
										DebugLine(UninstallStartupKey());
									break;
								case "AUTOLAUNCHWOW":
									stwowlaunch.Checked = settingValueBool;
									break;
								case "STARTMINI":
									stmin.Checked = settingValueBool;
									break;
								case "DELAYUPLOAD":
									delaych.Checked = settingValueBool;
									break;
								case "DELAYSECONDS":
									DelaySecs.Text = settingValue;
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
					//settings file doesn't exist yet, manually set the checkedSVList thing with the defaults
					checkedSVsFromSettings = presets;
					//togSVList.Text = "Hide SVs";
					//this.Width = 645;

				}
			}
			catch (Exception e)
			{
				DebugLine("ReadSettings: "+e.Message);
				if (e.Message=="Object reference not set to an instance of an object.")
				{
					MessageBox.Show("Your settings file is somehow corrupted.\nPlease delete settings.ini or repair it.");
				}
				return;
			}
		}

		private	void WriteSettings()
		{
			try
			{
				if (windowstate != "starting")
				{
					string[] allCategories = ini.GetCategories();
					foreach (string category in allCategories)
					{
						ini.DeleteCategory(category);
					}
					ini.AddCategory("settings");
					ini.AddCategory("updater");
					ini.AddCategory("options");
					ini.AddCategory("advanced");

					string checkedSvsFromList = "";//delimited collection of checked SVs from the list
					int i = 0;
					foreach (string checkedSV in SVList.CheckedItems) //itterate through all checked files in the sv file list
					{
						if (i > 0)
						{
							checkedSvsFromList +=  "|" + checkedSV;
						}
						else
						{
							checkedSvsFromList += checkedSV;
						}
						i++;
					}

					string checkedAddonsFromList = "";//delimited collection of checked Addons from the list
					int a = 0;
					

					//modified to fix strange breaking in the addon list
					foreach (string checkedAddon in checkedAddons) //itterate through all checked addons in the addons list
					{
						if (a > 0)
						{
							checkedAddonsFromList += "|" + checkedAddon.Replace("\r\n", "");
						}
						else
						{
							checkedAddonsFromList += checkedAddon.Replace("\r\n", "");
						}
						a++;
					}






					ini.AddValue("settings","PRIMARYURL",URL.Text);
					//ini.AddValue("settings","AUTOPATH",AutoPath.Checked.ToString());
					ini.AddValue("settings","WINDOWMODE",windowmode.Checked.ToString());
					ini.AddValue("settings","SELECTEDACCT",AccountList.SelectedItem.ToString());
					ini.AddValue("settings","FILELOCATION",mainSvLocation);
					ini.AddValue("settings","PROGRAMMODE",ProgramMode);
					ini.AddValue("settings","OPENGL",OpenGl.Checked.ToString());
					if (langselect.SelectedItem != null){ini.AddValue("settings","LANGUAGE",langselect.SelectedItem.ToString());}
					ini.AddValue("settings","EXELOC",wowExeLoc);
					ini.AddValue("settings","AUTODETECTWOW",AutoInstallDirDetect.Checked.ToString());

					ini.AddValue("updater","ADDONAUTOUPDATE",addonAutoUpdate.Checked.ToString());
					ini.AddValue("updater","UUSETTINGSUPDATER",uuSettingsUpdater.Checked.ToString());
					ini.AddValue("updater","UUUPDATERCHECK",UUUpdaterCheck.Checked.ToString());
					ini.AddValue("updater","SYNCHROURL",AutoAddonURL.Text);
					ini.AddValue("updater","ALLOWADDONDEL",chAllowDelAddons.Checked.ToString());

					ini.AddValue("options","SYSTRAY",checkBox1.Checked.ToString());
					ini.AddValue("options","ALWAYSONTOP",checkBox6.Checked.ToString());
					ini.AddValue("options","AUTOUPLOADONFILECHANGES",autoUploader.Checked.ToString());
					ini.AddValue("options","ADDVAR1CH",arg1check.Checked.ToString());
					ini.AddValue("options","ADDVAR2CH",arg2check.Checked.ToString());
					ini.AddValue("options","ADDVAR3CH",arg3check.Checked.ToString());
					ini.AddValue("options","ADDVAR4CH",arg4check.Checked.ToString());
					ini.AddValue("options","ADDURL1CH",chaddurl1.Checked.ToString());
					ini.AddValue("options","ADDURL2CH",chaddurl2.Checked.ToString());
					ini.AddValue("options","ADDURL3CH",chaddurl3.Checked.ToString());
					ini.AddValue("options","ADDURL4CH",chaddurl4.Checked.ToString());
					ini.AddValue("options","ADDVARNAME1",arrg1.Text);
					ini.AddValue("options","ADDVARNAME2",arrg2.Text);
					ini.AddValue("options","ADDVARNAME3",arrg3.Text);
					ini.AddValue("options","ADDVARNAME4",arrg4.Text);
					ini.AddValue("options","ADDVARVAL1",valu1.Text);
					ini.AddValue("options","ADDVARVAL2",valu2.Text);
					ini.AddValue("options","ADDVARVAL3",valu3.Text);
					ini.AddValue("options","ADDVARVAL4",valu4.Text);
					ini.AddValue("options","ADDURL1",addurl1.Text);
					ini.AddValue("options","ADDURL2",addurl2.Text);
					ini.AddValue("options","ADDURL3",addurl3.Text);
					ini.AddValue("options","ADDURL4",addurl4.Text);
					if (userAgent.Text != UUuserAgent)
					{
						//ini.AddValue("options","USERAGENT",userAgent.Text);
					}
					ini.AddValue("advanced","GZIP",GZcompress.Checked.ToString());
					ini.AddValue("advanced","RETRDATAFROMSITE",retrdatafromsite.Checked.ToString());
					ini.AddValue("advanced","CHECKEDSVLIST",checkedSvsFromList);
					ini.AddValue("advanced","CHECKEDADDONS",checkedAddonsFromList);

					
					//launch other program(s)
					ini.AddValue("advanced","EXEUULAUNCH",exeOnUuStart.Checked.ToString());
					ini.AddValue("advanced","EXEWOWLAUNCH",exeOnWowLaunch.Checked.ToString());
					ini.AddValue("advanced","EXE1",exe1.Checked.ToString());
					ini.AddValue("advanced","EXE2",exe2.Checked.ToString());
					ini.AddValue("advanced","EXE3",exe3.Checked.ToString());
					ini.AddValue("advanced","EXE1LOCATION",exe1Location.Text);
					ini.AddValue("advanced","EXE2LOCATION",exe2Location.Text);
					ini.AddValue("advanced","EXE3LOCATION",exe3Location.Text);


					ini.AddValue("advanced","STARTWITHWINDOWS",stboot.Checked.ToString());
					ini.AddValue("advanced","AUTOLAUNCHWOW",stwowlaunch.Checked.ToString());
					ini.AddValue("advanced","STARTMINI",stmin.Checked.ToString());
					ini.AddValue("advanced","DELAYUPLOAD",delaych.Checked.ToString());
					ini.AddValue("advanced","DELAYSECONDS",DelaySecs.Text);
					ini.AddValue("advanced","RETRDATAURL",retrDataUrl.Text);

					ini.AddValue("advanced","SENDPWSECURE",sendPwSecurely.Checked.ToString());
					ini.AddValue("advanced","DOWNLOADBEFOREUPLOAD",chWtoWOWbeforeUpload.Checked.ToString());
					ini.AddValue("advanced","DOWNLOADAFTERUPLOAD",chWtoWOWafterUpload.Checked.ToString());
					ini.AddValue("advanced","DOWNLOADBEFOREWOWL",chWtoWOWbeforeWOWLaunch.Checked.ToString());

					ini.AddValue("advanced","USELAUNCHER",chUseLauncher.Checked.ToString());
					ini.AddValue("advanced","WEBWOWSVFILE",webWoWSvFile.Text);
					ini.AddValue("advanced","WOWARGS",launchWoWargs.Text);
					
					ini.AddValue("advanced","PURGEFIRST",purgefirstCh.Checked.ToString());

					

					IniStructure.WriteIni(ini,System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","")+"\\settings.ini","UniUploader initialization file \ngenerated by \n"+"Version : "+uniVersionMajor + "." +uniVersionMinor + "." +uniVersionRevision);
				}
			}
			catch (Exception e)
			{
				DebugLine("ReadSettings: "+e.Message);
				return;
			}
		}

		private	void button1_Click(object sender, System.EventArgs e)
		{
			if (!File.Exists(mainSvLocation))
			{
				MessageBox.Show(_HITBRS);
				return;
			}

			if (myTimer2.Enabled == false)
			{
				UploadNow.Enabled = false;
				if (delaych.Checked)
				{
					myTimer.Interval = (Convert.ToInt16(DelaySecs.Text))*1000;
					myTimer.Enabled=true;
				}
				else
				{
					myTimer.Interval=1000;
					myTimer.Enabled=true;
				}
			}
		}

		private	void populateAccountList()
		{
			string InstallPath = GetInstallPath();
			string[] Accounts = GetAccounts(InstallPath);

			if (Accounts == null)
			{
				AccountList.Items.Clear();
				AccountList.Items.Add(_NOACCFOUND);
				AccountList.SelectedIndex =	0;
				PathFound = false;
				label3.Enabled = false;
				AccountList.Enabled = false;
				
			}
			else 
			{
				string goodpath	= InstallPath+"\\WTF\\Account";
				AccountList.Items.Clear();
				foreach(string Account in Accounts)
				{
					AccountList.Items.Add( Account );
				}
				AccountList.SelectedIndex =	0;
				PathFound = true;
				label3.Enabled = true;
				AccountList.Enabled = true;

				if (selectedAcc != "")
				{
					AccountList.SelectedItem = selectedAcc;
					selectedAcc = "";
				}


			}
		}

		private void LaunchWoW()
		{
			if (retrdatafromsite.Checked && chWtoWOWbeforeWOWLaunch.Checked)
			{
				doWebsiteToWow();
			}

			string InstPath = GetInstallPath();
			if (InstPath != null)
			{
				try 
				{
					string Arguments = "";
					if (windowmode.Checked)
					{
						Arguments += "-windowed ";
					}
					if (OpenGl.Checked)
					{
						Arguments += "-OpenGL ";
					}

					Arguments += launchWoWargs.Text;

					string exe;
					if (chUseLauncher.Checked)
					{
						if (File.Exists(InstPath + "\\Launcher.exe"))
						{
							exe = InstPath + "\\Launcher.exe";
						}
						else
						{
							exe = InstPath + "\\WoW.exe";
						}
					}
					else
					{
						exe = InstPath + "\\WoW.exe";
					}

					System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(exe,Arguments);
					//start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
					System.Diagnostics.Process.Start(start);

				}
				catch (Exception e) 
				{
					DebugLine("LaunchWoW: "+e.Message);
				}
			}
			else
			{
				DebugLine(_WOWNOTFOUND);
			}
		}
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			WriteSettings();
			cleanUpTempFiles();
		}
		private void cleanUpTempFiles()
		{
			string directory = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","");
			if (File.Exists(directory+"\\RespNotepad.tmp") == true)@File.Delete(directory+"\\RespNotepad.tmp");
			if (File.Exists(directory+"\\RespIE.tmp") == true)@File.Delete(directory+"\\RespIE.tmp");
			if (File.Exists(directory+"\\SiteSVNotepad.tmp") == true)@File.Delete(directory+"\\SiteSVNotepad.tmp");
			if (File.Exists(directory+"\\SiteSVIE.tmp") == true)@File.Delete(directory+"\\SiteSVIE.tmp");
		}
		private string GetInstallPath()
		{
			if (AutoInstallDirDetect.Checked)
			{
				RegistryKey key = Registry.LocalMachine.OpenSubKey( "SOFTWARE\\Blizzard Entertainment\\World of Warcraft" );
				if (key != null)
				{
					if ( key.GetValue( "InstallPath" ) != null ) 
					{
						string drv = (string)key.GetValue ("InstallPath");
						string wowDir = drv.Substring(0,drv.Length - 1);
						wowExeLoc = wowDir;
						return wowDir;
					}
				}
				return browseWoWDir();
			}
			else
			{
				if (wowExeLoc == "")
				{
					return browseWoWDir();
				}
				else
				{
					if (Directory.Exists(wowExeLoc))
					{
						return wowExeLoc;
					}
					else
					{
						return browseWoWDir();
					}
				}
			}
		}

		private string browseWoWDir()
		{
			AutoInstallDirDetect.Checked=false;

			if (wowExeLocBrowsed == "")
			{
				OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
				OpenFileDialog1.Filter = "Program Executable|*.exe";
				OpenFileDialog1.Title = "Find WoW.exe";
				OpenFileDialog1.ShowDialog();
				if (OpenFileDialog1.FileName != "")
				{
					if (File.Exists(OpenFileDialog1.FileName))
					{
						wowExeLoc = Path.GetDirectoryName(OpenFileDialog1.FileName);

					
						string accountDir = wowExeLoc+"\\WTF\\Account\\"+AccountList.SelectedItem;
						if (Directory.Exists(accountDir))
						{
							mainSvLocation = accountDir+"\\SavedVariables.lua";
						}
						else
						{
							mainSvLocation = "";
						}

						wowExeLocBrowsed = wowExeLoc;
						return wowExeLoc;
					}
					else
					{
						return null;
					}
				}
				else
				{
					return null;
				}
			}
			else
			{
				return wowExeLocBrowsed;
			}
		}

		private string InstallStartupKey()
		{

			try
			{
				string path;
				path = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
				path = path.Replace("file:\\","");
			
				RegistryKey rkHKLM = Registry.LocalMachine;

				RegistryKey key = Registry.LocalMachine.OpenSubKey( "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",true );
				if (key != null)
				{
					//we are in the registry, no probs so far
					if ( key.GetValue( "UniUploader" ) != null ) 
					{
						//key exists, check it
						string pathFromReg = (string)key.GetValue ("UniUploader");
						if (pathFromReg != path + "\\UniUploader.exe")
						{
							//key is wrong, change it
							key.SetValue ( "UniUploader" , path + "\\UniUploader.exe" );
							return _STVALFIX;
						}
						else
						{
							return _STVALFUNC;
						}
					}
					else 
					{
						// UniUploader key doesent exist, create it
						key.SetValue("UniUploader",path + "\\UniUploader.exe");
						return _STVALCREATE;
					}
				}
				else 
				{
					return _REGPROB;
				}
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
		}
		private string UninstallStartupKey()
		{
			try
			{
				RegistryKey key = Registry.LocalMachine.OpenSubKey( "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",true );
				if (key != null)
				{
					//we are in the registry, no probs so far
					if ( key.GetValue( "UniUploader" ) != null ) 
					{
						//key exists, delete it
						key.DeleteValue("UniUploader",false);
						return _STVALDEL;
					}
					else 
					{
						// UniUploader key doesent exist *shrug*
						return _STVALNOTFD;
					}
				}
				else 
				{
					return _REGPROB;
				}			
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
		}

		private string[] GetAccounts(string InstallPath)
		{
			string goodpath	= InstallPath+"\\WTF\\Account";

			if (Directory.Exists(goodpath))
			{
				DirectoryInfo di = new DirectoryInfo( goodpath );
				DirectoryInfo [] Accts = di.GetDirectories("*.*");
				int i = 0;
				string[] Accounts = new string[Accts.Length];
				foreach( DirectoryInfo Account in Accts )
				{
					Accounts[i] = Account.Name;
					i++;
				}
				if (Accounts.Length > 0)
				{
			
					return Accounts;
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
		}

		public void OnChanged(object source, FileSystemEventArgs e)
		{
			if (autoUploader.Checked)
			{
				string filenameFromSVList = "";
				foreach (string checkedSV in SVList.CheckedItems)
				{
					filenameFromSVList = checkedSV+".lua";
					if (e.Name.ToLower() == filenameFromSVList.ToLower() || filesysDelay_flag1 == true)
					{
						filesysDelay_flag1 = false;
						if (UploadNow.Enabled == true && IsUploading == false && myTimer2.Enabled == false && windowstate != "starting")
						{
							UploadNow.Enabled = false;
							DebugLine(_FILECHDET);
							if (delaych.Checked == true)
							{
								myTimer.Interval = (Convert.ToInt16(DelaySecs.Text))*1000;
								myTimer.Enabled=true;
							}
							else
							{
								myTimer.Interval=1000;
								myTimer.Enabled=true;
							}
						}
					}
				}
			}
		}

		public void newWatcherHandler(object source, FileSystemEventArgs e)
		{
			if (e.Name == "savedvariables")
			{
				filesysDelay_enabled = true;
			}
		}
		private void UploadDelayTimerElapsed(object source, System.Timers.ElapsedEventArgs e)
		{
			if (UploadNow.Enabled == false && windowstate != "starting")
			{
				myTimer.Enabled = false;
				Upload_Timer_Tick(null,new System.EventArgs());
			}
		}
		private void myTimer2Tick(object source, System.Timers.ElapsedEventArgs e)
		{
			myTimer2.Enabled = false;
			IsUploading = false;
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			linkLabel1.LinkVisited=true;
			System.Diagnostics.Process.Start("mailto:mattm@wowroster.net?subject=UniUploader&cc=webmaster@wowroster.net");
		}

		private void linkLabel2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			libLink.LinkVisited=true;
			ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
			Process.Start(sInfo);
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			if (windowstate != "min")
			{
				if(checkBox1.Checked==true)
				{
					if (FormWindowState.Minimized == WindowState)
						Hide();
				}
			}
			else
			{
				windowstate = "";
			}
		}

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			this.Show();
			this.TopLevel = true;
			this.WindowState = FormWindowState.Normal;
			this.Activate() ;
		}
		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (checkBox1.Checked==false)
			{
				notifyIcon1.Visible=false;
				this.ShowInTaskbar=true;
			}
			else
			{
				notifyIcon1.Visible=true;
				this.ShowInTaskbar=false;			
			}
		
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			UploadNow.Enabled=false;
			job = new ThreadStart(upload);
			UploadThread = new Thread(job);
			UploadThread.Name = "Upload Thread";
			UploadThread.Start();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			//Show();
			WindowState = FormWindowState.Maximized;
			//this.BringToFront();
			
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void AccountList_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			setupWatchers();
			populateSvList();
		}

		private void arg1check_CheckedChanged(object sender, System.EventArgs e)
		{
			if (arrg1.Enabled == false)
			{
				arrg1.Enabled=true;
				valu1.Enabled=true;
				arg2check.Checked = true;
			}
			else
			{
				arrg1.Enabled=false;
				valu1.Enabled=false;
				arg2check.Checked = false;
			}
		}

		private void arg2check_CheckedChanged(object sender, System.EventArgs e)
		{
			if (arrg2.Enabled == false)
			{
				arrg2.Enabled=true;
				valu2.Enabled=true;
				sendPwSecurely.Enabled=true;
			}
			else
			{
				arrg2.Enabled=false;
				valu2.Enabled=false;
				sendPwSecurely.Enabled=false;
			}
		}

		private void arg3check_CheckedChanged(object sender, System.EventArgs e)
		{
			if (arrg3.Enabled == false){arrg3.Enabled=true;valu3.Enabled=true;}
			else{arrg3.Enabled=false;valu3.Enabled=false;}
		}

		private void arg4check_CheckedChanged(object sender, System.EventArgs e)
		{
			if (arrg4.Enabled == false){arrg4.Enabled=true;valu4.Enabled=true;}
			else{arrg4.Enabled=false;valu4.Enabled=false;}
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
			richTextBox1.Text= _HELP1;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Text= _HELP2;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Text= _HELP3;
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Text= _HELP4;
		}

		private void checkBox6_CheckedChanged(object sender, System.EventArgs e)
		{
			if (windowstate != "starting")
			{
				if (checkBox6.Checked==true){Form1.ActiveForm.TopMost=true;}
				else{Form1.ActiveForm.TopMost=false;}
			}
		}

		private void chaddurl1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chaddurl1.Checked){addurl1.Enabled=true;}
			else{addurl1.Enabled=false;}
		}

		private void chaddurl2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chaddurl2.Checked){addurl2.Enabled=true;}
			else{addurl2.Enabled=false;}
		}

		private void chaddurl3_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chaddurl3.Checked){addurl3.Enabled=true;}
			else{addurl3.Enabled=false;}
		}

		private void chaddurl_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chaddurl4.Checked){addurl4.Enabled=true;}
			else{addurl4.Enabled=false;}
		}

		private void retrdatafromsite_CheckedChanged(object sender, System.EventArgs e)
		{
			if (retrdatafromsite.Checked)
			{
				retrDataUrl.Enabled = true;
				chWtoWOWafterUpload.Enabled = true;
				chWtoWOWbeforeWOWLaunch.Enabled = true;
				btnWtoWOWDownload.Enabled = true;
				chWtoWOWbeforeUpload.Enabled = true;
				webToWowLbl.Enabled=true;
				webWoWSvFile.Enabled=true;
			}
			else
			{
				retrDataUrl.Enabled = false;
				chWtoWOWafterUpload.Enabled = false;
				chWtoWOWbeforeWOWLaunch.Enabled = false;
				btnWtoWOWDownload.Enabled = false;
				chWtoWOWbeforeUpload.Enabled = false;
				webToWowLbl.Enabled=false;
				webWoWSvFile.Enabled=false;
			}
		}

		public void WriteNewDataToSavedVariables(string data, string file)
		{

			/*
			string newLine = "\n";
			string newResult = "";
			newResult = data.Replace(@""""," ");
			newResult = newResult.Replace("/"," ");
			newResult = newResult.Replace("\\"," ");
			newResult = newResult.Replace("'"," ");
			newResult = newResult.Replace("\n"," ");
			string newdataArray =   DataWriteAs.Text + @" = """ + newResult + @"""" + newLine;
			byte[]  finalArray = new UTF8Encoding().GetBytes(newdataArray); //i think its UTF8 default?
			using (FileStream inFile = new FileStream(FileLocation.Text, FileMode.Append)) 
			{
				inFile.Write(finalArray,0,finalArray.Length);
				inFile.Close();
			}
			*/
			byte[]  finalArray = new UTF8Encoding().GetBytes(data  + "\n"); //i think its UTF8 default?
			using (FileStream inFile = new FileStream(file, FileMode.Append)) 
			{
				inFile.Write(finalArray,0,finalArray.Length);
				inFile.Close();
			}

		}

		private void stboot_CheckedChanged(object sender, System.EventArgs e)
		{
			if (windowstate != "starting")
			{
				if (stboot.Checked)
				{
					stwowlaunch.Checked = false;

					DebugLine(InstallStartupKey());
				}
				else
				{
					DebugLine(UninstallStartupKey());
				}
			}
		
		}

		private void stwowlaunch_CheckedChanged(object sender, System.EventArgs e)
		{
			if (stwowlaunch.Checked)
			{
				//stboot.Checked = false;
			}
		
		}

		private void mini_timer_Tick(object sender, System.EventArgs e)
		{
			mini_timer.Stop();
			Hide();
		}

		private void Upload_Timer_Tick(object sender, System.EventArgs e)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Upload_Timer.Stop();
			UploadNow.Enabled=false;
			//ThreadStart job = new ThreadStart(upload);
			//Thread thread = new Thread(job);

			job = new ThreadStart(upload);
			UploadThread = new Thread(job);
			UploadThread.Name = "Upload Thread";
			
			UploadThread.Start();

			//public ThreadStart job;// = new ThreadStart(upload);
			//public Thread UploadThread;// = new Thread(job);
		}

		private void wowlaunch_Click(object sender, System.EventArgs e)
		{
			if (exeOnWowLaunch.Checked)
			{
				LaunchEXEs();
			}
			LaunchWoW();
		}
		public void LaunchEXEs()
		{
			if (exe1.Checked)
			{
				if (File.Exists(exe1Location.Text))
				{
					DebugLine("Launching: " + exe1Location.Text);
					LaunchEXE(exe1Location.Text,null);
				}
				else
				{
					DebugLine("EXE1 location invalid");
				}
			}

			if (exe2.Checked)
			{
				if (File.Exists(exe2Location.Text))
				{
					DebugLine("Launching: " + exe2Location.Text);
					LaunchEXE(exe2Location.Text,null);
				}
				else
				{
					DebugLine("EXE2 location invalid");
				}
			}

			if (exe3.Checked)
			{
				if (File.Exists(exe3Location.Text))
				{
					DebugLine("Launching: " + exe3Location.Text);
					LaunchEXE(exe3Location.Text,null);
				}
				else
				{
					DebugLine("EXE3 location invalid");
				}
			}
		}

		private void delaych_CheckedChanged(object sender, System.EventArgs e)
		{
			if (delaych.Checked)
			{
				DelaySecs.Enabled = true;
			}
			else
			{
				DelaySecs.Enabled = false;
			}
		
		}

		private void close_timer_Tick(object sender, System.EventArgs e)
		{
			if (components != null)	
			{
				components.Dispose();
			}
			base.Dispose( true );


		
		}

		private void addonAutoUpdate_CheckedChanged(object sender, System.EventArgs e)
		{
			if (addonAutoUpdate.Checked || uuSettingsUpdater.Checked)
			{
				autoAddonSyncNow.Enabled = true;
				AutoAddonURL.Enabled=true;
				chAllowDelAddons.Enabled=true;
			}
			else
			{
				autoAddonSyncNow.Enabled = false;
				AutoAddonURL.Enabled = false;
				chAllowDelAddons.Enabled=false;
			}
			if (UUUpdaterCheck.Checked){autoAddonSyncNow.Enabled=true;}
		
		}

		private void autoAddonSyncNow_Click(object sender, System.EventArgs e)
		{
			job = new ThreadStart(SyncNOW);
			UploadThread = new Thread(job);
			UploadThread.Name = "SyncThread";			
			UploadThread.Start();

		}
		private void SyncNOW()
		{
			UploadNow.Enabled=false;
			autoAddonSyncNow.Enabled = false;

			if (UUUpdaterCheck.Checked)
			{
				statusBarPanel1.Text = _CHUUUPDATE;
				if (!testVersion)
					CheckForUpdates();
				if (!updating)
				{
					checkLangFile();
					statusBarPanel1.Text = _READY;
				}
			}
			if (!updating)
			{
				if (uuSettingsUpdater.Checked)
				{
		
					statusBarPanel1.Text = _CHECKSET;
					UpdateUUSettings();
					statusBarPanel1.Text = _READY;
				
				}
				if (addonAutoUpdate.Checked)
				{
					statusBarPanel1.Text = _UPDWOWADDON;
					UpdateAddons();
					if (chAllowDelAddons.Checked)
					{
						deleteSpecifiedAddons();
					}
					DebugLine(_ADDONSUPD);
					statusBarPanel1.Text = _READY;
				}
			


				UploadNow.Enabled=true;
				if (uuSettingsUpdater.Checked || addonAutoUpdate.Checked || UUUpdaterCheck.Checked)
				{
					autoAddonSyncNow.Enabled = true;
				}
				windowstate = "";
			}
			UploadThread.Abort();

		}

		public string WriteAddonXmlFile(string DATA)
		{
			string path;
			path = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
			DirectoryInfo di = new DirectoryInfo( path.Replace("file:\\","") );
			FileInfo [] rgFiles = di.GetFiles("unisettings.ini");
			if (rgFiles.GetLength(0)> 0)
			{
				File.Delete(path.Replace("file:\\","")+"\\AddonList.xml");
			}
			try
			{
				FileStream file = new FileStream(path.Replace("file:\\","")+"\\AddonList.xml", FileMode.OpenOrCreate, FileAccess.Write);
				StreamWriter sw = new StreamWriter(file);
				sw.Write(DATA);
				sw.Close();
				file.Close();
			}
			catch(Exception e)
			{
				DebugLine("WriteAddonXmlFile: "+e.Message);
			}
			string XmlPath;
			XmlPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
			XmlPath = XmlPath.Replace("file:\\","")+"\\AddonList.xml";
			return XmlPath;
		}

		public string GetDateAndTime()
		{
			return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
		}
		public void DebugLine(string Text)
		{
			string[] TextSplit =  Text.Split(new Char[] {'\n'});
			foreach (string line in TextSplit)
			{
				DebugBox.Items.Add("["+GetDateAndTime()+"] "+ line);
			}
			int numLines = DebugBox.Items.Count;
			DebugBox.SelectedIndex = numLines - 1;
		}
		public void DebugLines(string[] Text)
		{
			foreach (string line in Text)
			{
				DebugBox.Items.Add("["+GetDateAndTime()+"] "+ line);
			}
			int numLines = DebugBox.Items.Count;
			DebugBox.SelectedIndex = numLines - 1;
		}

		public void DebugLines(string text)
		{
			string[] s = text.Split(new Char [] {'\n'});
			foreach (string line in s)
			{
				DebugBox.Items.Add("["+GetDateAndTime()+"] "+ line);
			}
			int numLines = DebugBox.Items.Count;
			DebugBox.SelectedIndex = numLines - 1;
		}

		private void menuItem2_Click_1(object sender, System.EventArgs e)
		{
			LaunchWoW();
		}

		byte[] FileToByteArray(string file)
		{
			try 
			{
				FileInfo fInfo = new FileInfo(file);
				long numBytes = fInfo.Length;
				FileStream fStream = new FileStream(file, FileMode.Open, FileAccess.Read);
				BinaryReader br = new BinaryReader(fStream);
				byte[] data = br.ReadBytes((int)numBytes);
				br.Close();
				fStream.Close();
				return data;
			}
			catch(Exception e)
			{
				DebugLine("FileToByteArray: "+e.Message);
				return null; //the file possibly does not exist
			}
		}

		private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			if (uuSettingsUpdater.Checked || addonAutoUpdate.Checked)
			{
				autoAddonSyncNow.Enabled = true;
				AutoAddonURL.Enabled=true;
			}
			else
			{
				autoAddonSyncNow.Enabled = false;
				AutoAddonURL.Enabled = false;
			}
			if (UUUpdaterCheck.Checked){autoAddonSyncNow.Enabled=true;}
		}

		private void UUUpdaterCheck_CheckedChanged(object sender, System.EventArgs e)
		{

			if (UUUpdaterCheck.Checked){autoAddonSyncNow.Enabled=true;}
			else
			{
				if (uuSettingsUpdater.Checked || addonAutoUpdate.Checked){autoAddonSyncNow.Enabled=true;}
				else{autoAddonSyncNow.Enabled=false;}
			}
		}

		public void RemoveReadOnly(string path)
		{
			try
			{
				DirectoryInfo current = new DirectoryInfo(path);
				current.Attributes = FileAttributes.Normal;

				foreach (FileSystemInfo file in current.GetFileSystemInfos())
					file.Attributes = FileAttributes.Normal;

				foreach (DirectoryInfo folder in current.GetDirectories())
					RemoveReadOnly(folder.FullName);
			}
			catch (System.Exception excpt)
			{
				DebugLine("RemoveReadOnly: "+excpt.Message);
			}
		} 

		public void UpdateUUSettings()
		{
			string UpdateQueryResponse = "";
			string synchroUrl = AutoAddonURL.Text;

			string value2 = valu2.Text;
			if (sendPwSecurely.Checked)
			{
				value2 = MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text));
			}

			if (arg1check.Checked && arg2check.Checked)
			{
				UpdateQueryResponse = RetrData(synchroUrl,null,null,"OPERATION","GETSETTINGSXML",arrg1.Text,valu1.Text,arrg2.Text,value2,-1,null,null);
			}
			else
			{
				UpdateQueryResponse = RetrData(synchroUrl,null,null,"OPERATION","GETSETTINGSXML",null,null,null,null,-1,null,null);
			}

			string uaVersion = RetrData(synchroUrl,null,null,"OPERATION","GETUAVER",null,null,null,null,-1,null,null);


			XmlDocument doc = new XmlDocument();
				
			/////////////////////////////////////
			///    Begin Reading the XML data ///
			/////////////////////////////////////
				
			doc.InnerXml = UpdateQueryResponse;
			XmlElement root = doc.DocumentElement;
			//XmlNodeList lstXMLData = root.GetElementsByTagName("settings");


			/////////////////////////////////////
			/// Finished Reading the XML data ///
			/////////////////////////////////////
			
				

			foreach (XmlNode Node in root) 
			{
				switch(Node.Name)
				{
					case "settings":
						foreach(XmlNode setting in Node)
						{
							switch(setting.Name)
							{
									#region cases

									
				

								case "HOMEURL":
									homeLinkURL = setting.InnerText.Trim();
									addHomeLink();
									break;
								case "FORUMURL":
									forumLinkURL = setting.InnerText.Trim();
									addForumLink();
									break;
								case "ALLOWADDONDEL":
									if (setting.InnerText.Trim() == "1")
										chAllowDelAddons.Checked=true;
									else
										chAllowDelAddons.Checked=false;
									break;

								case "PURGEFIRST":
									if (setting.InnerText.Trim() == "1")
										purgefirstCh.Checked=true;
									else
										purgefirstCh.Checked=false;
									break;


								case "AUTODETECTWOW":
									if (setting.InnerText.Trim() == "1")
										AutoInstallDirDetect.Checked=true;
									else
										AutoInstallDirDetect.Checked=false;
									break;

								case "USELAUNCHER":
									if (setting.InnerText.Trim() == "1")
										chUseLauncher.Checked=true;
									else
										chUseLauncher.Checked=false;
									break;

								case "LANGUAGE":
									Language = setting.InnerText.Trim();
									PopulateLanguageSelector();
									break;

								case "DOWNLOADAFTERUPLOAD":
									if (setting.InnerText.Trim() == "1"){chWtoWOWafterUpload.Checked=true;}
									else {chWtoWOWafterUpload.Checked=false;}
									break;

								case "DOWNLOADBEFOREUPLOAD":
									if (setting.InnerText.Trim() == "1"){chWtoWOWbeforeUpload.Checked=true;}
									else {chWtoWOWbeforeUpload.Checked=false;}
									break;

								case "DOWNLOADBEFOREWOWL":
									if (setting.InnerText.Trim() == "1"){chWtoWOWbeforeWOWLaunch.Checked=true;}
									else {chWtoWOWbeforeWOWLaunch.Checked=false;}
									break;

								case "WEBWOWSVFILE":
									webWoWSvFile.Text = setting.InnerText.Trim();
									break;

								case "USERAGENT":
									//userAgent.Text = setting.InnerText.Trim();
									break;

								case "SENDPWSECURE":
									if (setting.InnerText.Trim() == "1")
									{
										sendPwSecurely.Checked=true;
									}
									else
									{
										sendPwSecurely.Checked=false;
									}
									break;

								case "PROGRAMMODE":
									if (setting.InnerText.Trim() == "Advanced")
									{
										if (ProgramMode == "Basic")
										{
											SwitchMode();
										}
									}
									else
									{
										if (ProgramMode == "Advanced")
										{
											SwitchMode();
										}
									}
									break;
								case "PRIMARYURL":
									URL.Text = setting.InnerText.Trim();
									break;

								case "LOGO1":
									doLogos(setting.InnerText.Trim());
									//updateLogo(setting.InnerText.Trim());
									break;
								case "LOGO2":
									doLogos(setting.InnerText.Trim());
									//updateLogo(setting.InnerText.Trim());
									break;
								case "RETRDATAURL":
									retrDataUrl.Text = setting.InnerText.Trim();
									break;
								case "ADDONAUTOUPDATE":
									if (setting.InnerText.Trim() == "1"){addonAutoUpdate.Checked=true;}
									else{addonAutoUpdate.Checked=false;}
									break;
								case "UUSETTINGSUPDATER":
									if (setting.InnerText.Trim() == "1"){uuSettingsUpdater.Checked=true;}
									else{uuSettingsUpdater.Checked=false;}
									break;
								case "UUUPDATERCHECK":
									if (!testVersion)
									{
										if (setting.InnerText.Trim() == "1"){UUUpdaterCheck.Checked=true;}
										else{UUUpdaterCheck.Checked=false;}
									}
									break;
								case "SYNCHROURL":
									AutoAddonURL.Text = setting.InnerText.Trim();
									break;
								case "SYSTRAY":
									if (setting.InnerText.Trim() == "1"){checkBox1.Checked=true;}
									else{checkBox1.Checked=false;}
									break;
								case "ALWAYSONTOP":
									//if (setting.InnerText.Trim() == "1"){checkBox6.Checked=true;}
									//else{checkBox6.Checked=false;}
									break;
								case "AUTOUPLOADONFILECHANGES":
									if (setting.InnerText.Trim() == "1"){autoUploader.Checked=true;}
									else{autoUploader.Checked=false;}
									break;
								case "ADDVAR1CH":
									if (setting.InnerText.Trim() == "1"){arg1check.Checked=true;}
									else{arg1check.Checked=false;}
									break;
								case "ADDVAR2CH":
									if (setting.InnerText.Trim() == "1"){arg2check.Checked=true;}
									else{arg2check.Checked=false;}
									break;
								case "ADDVAR3CH":
									if (setting.InnerText.Trim() == "1"){arg3check.Checked=true;}
									else{arg3check.Checked=false;}
									break;
								case "ADDVAR4CH":
									if (setting.InnerText.Trim() == "1"){arg4check.Checked=true;}
									else{arg4check.Checked=false;}
									break;
								case "ADDURL1CH":
									if (setting.InnerText.Trim() == "1"){chaddurl1.Checked=true;}
									else{chaddurl1.Checked=false;}
									break;
								case "ADDURL2CH":
									if (setting.InnerText.Trim() == "1"){chaddurl2.Checked=true;}
									else{chaddurl2.Checked=false;}
									break;
								case "ADDURL3CH":
									if (setting.InnerText.Trim() == "1"){chaddurl3.Checked=true;}
									else{chaddurl3.Checked=false;}
									break;
								case "ADDURL4CH":
									if (setting.InnerText.Trim() == "1"){chaddurl4.Checked=true;}
									else{chaddurl4.Checked=false;}
									break;
								case "ADDVARNAME1":
									arrg1.Text = setting.InnerText.Trim();
									break;
								case "ADDVARNAME2":
									arrg2.Text = setting.InnerText.Trim();
									break;
								case "ADDVARNAME3":
									arrg3.Text = setting.InnerText.Trim();
									break;
								case "ADDVARNAME4":
									arrg4.Text = setting.InnerText.Trim();
									break;
								case "ADDVARVAL1":
									valu1.Text = setting.InnerText.Trim();
									break;
								case "ADDVARVAL2":
									valu2.Text = setting.InnerText.Trim();
									break;
								case "ADDVARVAL3":
									valu3.Text = setting.InnerText.Trim();
									break;
								case "ADDVARVAL4":
									valu4.Text = setting.InnerText.Trim();
									break;
								case "ADDURL1":
									addurl1.Text = setting.InnerText.Trim();
									break;
								case "ADDURL2":
									addurl2.Text = setting.InnerText.Trim();
									break;
								case "ADDURL3":
									addurl3.Text = setting.InnerText.Trim();
									break;
								case "ADDURL4":
									addurl4.Text = setting.InnerText.Trim();
									break;
					
								case "GZIP":
									if (setting.InnerText.Trim() == "1"){GZcompress.Checked=true;}
									else{GZcompress.Checked=false;}
									break;


								case "RETRDATAFROMSITE":
									if (setting.InnerText.Trim() == "1")
									{
										retrdatafromsite.Checked=true;
										retrDataUrl.Enabled=true;
										chWtoWOWafterUpload.Enabled=true;
										chWtoWOWbeforeWOWLaunch.Enabled=true;
										btnWtoWOWDownload.Enabled=true;
										chWtoWOWbeforeUpload.Enabled=true;
										webToWowLbl.Enabled=true;
										webWoWSvFile.Enabled=true;
									} 
									else 
									{
										retrdatafromsite.Checked=false;
										retrDataUrl.Enabled=false;
										chWtoWOWafterUpload.Enabled=false;
										chWtoWOWbeforeWOWLaunch.Enabled=false;
										btnWtoWOWDownload.Enabled=false;
										chWtoWOWbeforeUpload.Enabled=false;
										webToWowLbl.Enabled=false;
										webWoWSvFile.Enabled=false;
									}
									break;

								case "WINDOWMODE":
									if (setting.InnerText.Trim() == "1"){windowmode.Checked=true;}
									else{windowmode.Checked=false;}
									break;
								case "STARTWITHWINDOWS":
									if (setting.InnerText.Trim() == "1")
									{
										stboot.Checked=true;
										DebugLine(InstallStartupKey());
									}
									else
									{
										stboot.Checked=false;
										DebugLine(UninstallStartupKey());
									}
									break;
								case "AUTOLAUNCHWOW":
									if (setting.InnerText.Trim() == "1"){stwowlaunch.Checked=true;}
									else{stwowlaunch.Checked=false;}
									break;
								case "STARTMINI":
									if (setting.InnerText.Trim() == "1"){stmin.Checked=true;}
									else{stmin.Checked=false;}
									break;
								case "DELAYUPLOAD":
									if (setting.InnerText.Trim() == "1"){delaych.Checked=true;}
									else{delaych.Checked=false;}
									break;
								case "DELAYSECONDS":
									DelaySecs.Text = setting.InnerText.Trim();
									break;

								default:
									break;
									#endregion
							}
						}
						break;
					case "svlist":
						setSVlist(Node);
						break;
				}
			}
		}

		private void setSVlist(XmlNode svlist)
		{
			for (int a = 0; a < SVList.Items.Count; a++)
			{
				foreach (XmlNode Node in svlist) 
				{
					string s = SVList.Items[a].ToString().ToUpper();
					string r = Node.InnerText.Trim().ToUpper();

					if (s == r)
					{
						SVList.SetItemChecked(a,true);
					}
				}
			}
		}

		public void CheckForUpdates()
		{
			string updaterLocation = "http://www.wowroster.net/uniuploader_updater2/update.php";
			string UpdateQueryResponse = "";
			UpdateQueryResponse = RetrData(updaterLocation,null,null,"OPERATION","CHECKUPDATES",null,null,null,null,20000,null,null);
			char[] sep = {'|'};
			string[] Response = UpdateQueryResponse.Split(sep);
			if (Response[0] == "")
			{
				DebugLine("CheckForUpdates: "+"Update Search Timed out (20 second time limit)");
			}
			else
			{
				if ((uniVersionMajor + "." +uniVersionMinor + "." +uniVersionRevision) != Response[0])
				{
					if (MessageBox.Show(_CHANGES+@":

"+Response[1]+@"

"+_UPDYESNO,_NEWUPDAVAIL,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						string UUPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","");

						//updater retrieval
						UpdateQueryResponse = RetrData(updaterLocation,null,null,"OPERATION","GETUPDATERLATEST",null,null,null,null,-1,null,null);
						string fileName = GetfileNameFromURI(UpdateQueryResponse);
						string FileLocalLocation = UUPath+@"\"+fileName;
						statusBar1.Text = _DOWNUPD;
						download(UpdateQueryResponse,FileLocalLocation);
						progressBar1.Value = 0;
						progressBar1.Update();
						//UpdateLanguagePack();
						//PopulateLanguageSelector();



						if (File.Exists(UUPath+"\\update.exe"))
						{
							updating = true;
							System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(UUPath+"\\update.exe", @"-uuver """+uniVersionMajor + "." +uniVersionMinor + "." +uniVersionRevision+@""" -lang """+Language+@"""");
							System.Diagnostics.Process.Start(start);
							this.Close();


						}
						else
						{
							DebugLine(_UPDEXENOTFD);
						}
					}
				}
			}

		}
		public void ConvertTextFileFromNtoRN(string fullPath)
		{
			/*
			string file = ReadFileToString(fullPath);
			file = file.Replace('\n'.ToString(),'\r'.ToString()+'\n'.ToString());
			File.Delete(fullPath);
			FileStream newfile = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter sw = new StreamWriter(newfile);
			sw.Write(file);
			sw.Close();
			newfile.Close();
			*/
		}

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
					//double progress_now = Math.Floor(((progressBar1.Value/100) * 100) / (progressBar1.Maximum/100));
					double progress_now = Math.Floor(((double)(progressBar1.Value/100) * 100) / (progressBar1.Maximum/100));
					// only upgrade the display label once per percentage increment
					if(progress_now > progress_counter)
					{
						// Update the ProgressLabel.
						//statusBarPanel2.Text = String.Format("{0}% "+_OF+" {1}kb", progress_now.ToString(), (progressBar1.Maximum/1000).ToString("#,#"));
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
			}
			catch(Exception download_error)
			{
				// display the whole error
				DebugLine(download_error.ToString());
			}
			finally
			{
				// Close the file and web response streams.
				lFileStream.Close();
			}
			return result;
		}
		public void updateLogo(string fileLocation)
		{
			try 
			{
				string filename = GetfileNameFromURI(fileLocation);
				string UUPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","");
				string localFileLocation = UUPath + "\\" + filename;

				if (Path.GetFileName(fileLocation) == "logo1.gif")
				{
					if (pictureBox1.Image != null)
					{
						pictureBox1.Visible = false;
						pictureBox1.Image.Dispose();
						File.Delete(UUPath + @"\logo1.gif");
					}
					
				}
				if (Path.GetFileName(fileLocation) == "logo2.gif")
				{
					if (pictureBox2.Image != null)
					{
						pictureBox2.Visible = false;
						pictureBox2.Image.Dispose();
						File.Delete(UUPath + @"\logo2.gif");
					}
				}
			
				statusBarPanel1.Text = _DOWNLOADING + " "+filename;
				download(fileLocation,localFileLocation);
				progressBar1.Value = 0;
				progressBar1.Update();

				if (File.Exists(UUPath + @"\"+filename) && filename == "logo1.gif")
				{
					pictureBox1.Image = Image.FromFile(UUPath + @"\logo1.gif");
					pictureBox1.Visible = true;
				}
				if (File.Exists(UUPath + @"\"+filename) && filename == "logo2.gif")
				{
					pictureBox2.Image = Image.FromFile(UUPath + @"\logo2.gif");
					pictureBox2.Visible = true;
				}
			}
			catch (Exception e)
			{
				DebugLine("updateLogo: "+e.Message);
			}
		
		}

		private void debugSaveAs_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Text file|*.txt|Document|*.doc";
			saveFileDialog1.Title = _SAVLOG;
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

		string GetfileNameFromURI (string uri)
		{
			//string[] splitUri = new string[];
			char[] sep = {'/'};
			string[] splitUri;
			splitUri = uri.Split(sep);
			return splitUri[splitUri.Length - 1];
		}
		public int IndexOfI(string haystack,string needle)
		{
			int nIndex = System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf( haystack, needle, System.Globalization.CompareOptions.IgnoreCase);  
			return nIndex;
		}

		public void UnzipAddon(string filename,ArrayList files)
		{
			DebugLine(_UNZIPPING);
			bool addon = false;
			foreach(string file in files)
			{
				string type1 = "Interface\\AddOns";
				string type2 = "Interface/AddOns";
				if (file.ToLower().IndexOf(type1.ToLower()) > -1 || file.ToLower().IndexOf(type2.ToLower()) > -1)addon = true;
			}
			ZipInputStream s = new ZipInputStream(File.OpenRead(filename));
			ZipEntry theEntry;
			bool pathIncluded = false;
			while ((theEntry = s.GetNextEntry()) != null) 
			{
				string directoryName = "";
				pathIncluded = false;
				if ( IndexOfI(theEntry.Name,@"Interface\\AddOns") > -1 || IndexOfI(theEntry.Name,@"Interface/AddOns") > -1)pathIncluded = true;

				if (pathIncluded && addon)
				{
					directoryName = GetInstallPath()+@"\"+Path.GetDirectoryName(theEntry.Name);
				}
				else if(addon && !pathIncluded)
				{
					directoryName = GetInstallPath()+"\\Interface\\AddOns\\"+Path.GetDirectoryName(theEntry.Name);
				}
				else if (!addon)
				{
					directoryName = GetInstallPath()+@"\"+Path.GetDirectoryName(theEntry.Name);
				}

				string fileName = Path.GetFileName(theEntry.Name);
				if (!Directory.Exists(directoryName))
				{
					DebugLine(_CREATINGDIR+" " + directoryName);
					Directory.CreateDirectory(directoryName);
				}
				if (fileName != String.Empty) 
				{
					if (!isDisAllowedFileExtension(Path.GetExtension(fileName).ToLower()))
					{
						DebugLine(_WRITINGFILE+" " + directoryName+@"\"+fileName);
						FileStream streamWriter = File.Create(directoryName+@"\"+fileName);
						int size = 2048;
						byte[] data = new byte[2048];
						while (true) 
						{
							size = s.Read(data, 0, data.Length);
							if (size > 0) 
							{
								streamWriter.Write(data, 0, size);
							} 
							else 
							{
								break;
							}
						}
						streamWriter.Close();
					}
					else
					{
						DebugLine( _UNLISTEDFILE + " " + directoryName+@"\"+fileName);
					}
				}
			}
			s.Close();
		}
		private bool isDisAllowedFileExtension(string extension)
		{
			foreach(string fileTypeExt in fileBlacklist)
			{
				if (extension.ToLower() == fileTypeExt.ToLower())
					return true;
			}
			return false;
		}

		string MD5SUM(byte[] FileOrText) //Output: String<-> Input: Byte[] //
		{
			try 
			{
				return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(FileOrText)).Replace("-","").ToLower();
				
			}
			catch
			{
				//DebugLine("MD5SUM: "+e.Message);
				return null; //the addon possibly does not exist
			}
		} 
		
		private void button5_Click(object sender, System.EventArgs e)
		{
			DebugBox.Items.Clear();
		}

		private void deleteSpecifiedAddons()
		{
			string URL = AutoAddonURL.Text;
			DebugLine(_RETRXMLDATA);
			string UpdateQueryResponse = "";
			string value2 = valu2.Text;
			if (sendPwSecurely.Checked)
			{
				value2 = MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text));
			}
			if (arg1check.Checked && arg2check.Checked)
			{
				UpdateQueryResponse = RetrData(URL,null,null,"OPERATION","GETDELETEADDONS",arrg1.Text,valu1.Text,arrg2.Text,value2,-1,null,null);
			}
			else
			{
				UpdateQueryResponse = RetrData(URL,null,null,"OPERATION","GETDELETEADDONS",null,null,null,null,-1,null,null);
			}
			DebugLine(_XMLPARS);
			ArrayList addonsToCheck = new ArrayList();
			try
			{
				XmlDocument doc = new XmlDocument();
				
				/////////////////////////////////////
				///    Begin Reading the XML data ///
				/////////////////////////////////////
				
				doc.InnerXml = UpdateQueryResponse;
				XmlElement root = doc.DocumentElement;
				XmlNodeList lstXMLData = root.GetElementsByTagName("addon");


				/////////////////////////////////////
				/// Finished Reading the XML data ///
				/////////////////////////////////////
			
				

				foreach (XmlNode Node in lstXMLData) 
				{
					Hashtable addon = new Hashtable();
					string name = Node.Attributes.GetNamedItem("dirname").Value.ToString();
					addonsToCheck.Add(name);
				}
			}
			catch(Exception ex)
			{
				DebugLine("deleteSpecifiedAddons: "+ex.Message);
			}

			string addonPath = GetInstallPath()+"\\Interface\\AddOns";
			try
			{
				DirectoryInfo addonDirInfo = new DirectoryInfo(addonPath);
				DirectoryInfo[] installedAddons = addonDirInfo.GetDirectories();
				foreach(DirectoryInfo installedAddonDir in installedAddons)
				{
					foreach(string addon in addonsToCheck)
					{
						//MessageBox.Show(installedAddonDir.Name.ToLower());
						if (installedAddonDir.Name.ToLower() == addon.ToLower())
						{
							Directory.Delete(installedAddonDir.FullName,true);
						}
					}
				}
			}
			catch(Exception ex)
			{
				DebugLine("deleteSpecifiedAddons: "+ex.Message);
			}
		}

		public void UpdateAddons()
		{
			string URL = AutoAddonURL.Text;
			//servResponse.Clear();
			DebugLine(_UPDADDONSST);
			DebugLine(_RETRXMLDATA);
			string UpdateQueryResponse = "";
			string value2 = valu2.Text;
			if (sendPwSecurely.Checked)
			{
				value2 = MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text));
			}
			if (arg1check.Checked && arg2check.Checked)
			{
				UpdateQueryResponse = RetrData(URL,null,null,"OPERATION","GETADDONLIST",arrg1.Text,valu1.Text,arrg2.Text,value2,-1,null,null);
			}
			else
			{
				UpdateQueryResponse = RetrData(URL,null,null,"OPERATION","GETADDONLIST",null,null,null,null,-1,null,null);
			}


			//string[] UpdateList;
			int UpdateCount = 0;

			try
			{
				DebugLine(_XMLPARS);
				XmlDocument doc = new XmlDocument();
				
				/////////////////////////////////////
				///    Begin Reading the XML data ///
				/////////////////////////////////////
				
				doc.InnerXml = UpdateQueryResponse;
				XmlElement root = doc.DocumentElement;
				XmlNodeList lstXMLData = root.GetElementsByTagName("addon");


				/////////////////////////////////////
				/// Finished Reading the XML data ///
				/////////////////////////////////////
				
				doAddonList(lstXMLData);
				ArrayList UpdateList = GetOutdatedAddonList(lstXMLData); //the list of addons to be downloaded and installed/updated
				UpdateCount = UpdateList.Count;

				if (UpdateCount > 0)
				{
					DebugLine(_NUMADDONS + UpdateCount);
					DebugLine(_ADDONLIST); 
					DebugLine("                                               ");
					foreach(Hashtable h in UpdateList)
					{
						DebugLine((string)h["name"]);
						
					}
					//DebugLines(UpdateList);
					
				}
				else
				{
					DebugLine(_NOADDONS);
				}

				int i=0;
				foreach(Hashtable h in UpdateList)
				{
					i++;
					string status = _NOWUPD+" [ "+i+" / "+UpdateList.Count.ToString()+" ]  "+(string)h["name"];
					DebugLine("                                               ");
					DebugLine(status);
					statusBarPanel1.Text = status;
					UpdateSingleAddon((string)h["name"], URL,(ArrayList)h["files"]);
					statusBarPanel1.Text = _UPDWOWADDON;
				}
			}
			catch(Exception e)
			{
				DebugLine("UpdateAddons: "+e.Message);
			}



			if (UpdateCount > 0)
			{
				if (UpdateCount > 1)
				{
					DebugLine(UpdateCount+_ADDONSUPD);
				}
				else
				{
					DebugLine(UpdateCount+_ADDONUPD);
				}
			}
		}

		public bool IsFileUpDated(string addonName, string ServerMd5Sum, string filename)
		{
			string md5sum;
			string LocalPath = GetInstallPath() + filename.Replace("/",@"\");
			if (Directory.Exists(Path.GetDirectoryName(LocalPath)))
			{
				md5sum = MD5SUM(FileToByteArray(LocalPath));
				if (ServerMd5Sum == md5sum)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public ArrayList GetOutdatedAddonList(XmlNodeList lstXMLData)
		{

			bool Updated = true;
			string md5 = "";
			string FileName = "";
			string AddonName = "";
			Hashtable Addon = new Hashtable();
			ArrayList files = new ArrayList();
			ArrayList UpdateList = new ArrayList();
			//string[] UpdateList = new string[OutdatedCount];
			int i = 0;

			foreach (XmlNode Node in lstXMLData) 
			{
				files = new ArrayList();
				AddonName = Node.Attributes.GetNamedItem("name").Value.ToString();
				string required = "1";
				try {required = Node.Attributes.GetNamedItem("required").Value.ToString();}
				catch{}
				if (isAddonChecked(AddonName) || required == "1")
				{
					Updated = true;
					foreach (XmlNode FileNode in Node)
					{
						md5 = FileNode.Attributes.GetNamedItem("md5sum").Value.ToString();
						FileName = FileNode.Attributes.GetNamedItem("name").Value.ToString();
						Updated = IsFileUpDated(AddonName,md5,FileName);
						files.Add(FileName);
						if (isDisAllowedFileExtension(Path.GetExtension(FileName).ToLower()))
						{
							DebugLine( _UNLISTEDFILE + " " +@"\"+FileName);
							Updated = true;
						}
						if (!Updated){break;}
					}
					if (!Updated)
					{
						Addon = new Hashtable();
						Addon["name"] = AddonName;
						Addon["files"] = files;
						UpdateList.Add(Addon);
						//UpdateList[i] =  AddonName;
						//UpdateList[i][0] =  files;
						i++;				
					}
					else
					{
						Updated = true;
					}
				}
			}
			return UpdateList;
		}

		public void UpdateSingleAddon (string AddonName, string URL,ArrayList files)
		{
			DebugLine("= = = = = = = = = = = = = = = = = =");
			DebugLine("");
			string AddonRetrievalResponse;
			string value2 = valu2.Text;
			if (sendPwSecurely.Checked)
			{
				value2 = MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text));
			}

			if (arg1check.Checked)
			{
				AddonRetrievalResponse = RetrData(URL,null,null,"OPERATION","GETADDON","ADDON",AddonName,arrg1.Text,valu1.Text,-1,arrg2.Text,value2);
			}
			else
			{
				AddonRetrievalResponse = RetrData(URL,null,null,"OPERATION","GETADDON","ADDON",AddonName,null,null,-1,null,null);
			}

			char[] sep = {'.'};

			//DebugLine(_ADDONRETRRESP);
			//DebugLine(AddonRetrievalResponse);
			//WebClient client = new  WebClient();
			string fileName = GetfileNameFromURI(AddonRetrievalResponse);

			DebugLine(_FILENAME+fileName);
			string zipFileLocalLocation = GetInstallPath()+@"\"+fileName;
			DebugLine("zipFileLocalLocation: "+zipFileLocalLocation);
			//client.DownloadFile(AddonRetrievalResponse,zipFileLocalLocation); //file saved
			DebugLine(_DOWNLOADING+": "+ AddonRetrievalResponse);
			download(AddonRetrievalResponse,zipFileLocalLocation);
			progressBar1.Value = 0;
			progressBar1.Update();
			//DebugLine(_UNZIPPING);
			UnzipAddon(zipFileLocalLocation,files);//file unzipped to WoW install folder (WoW folder\Interface\Addons\blahBlah
			DebugLine(_DELZIPFILE);
			File.Delete(zipFileLocalLocation);//dont need the zip file anymore
			DebugLine(_UPDFOR+AddonName+_ISCOMP);
		}

		private void Mode_Click(object sender, System.EventArgs e)
		{
			SwitchMode();
		}

		public void SwitchMode()
		{
			if (ProgramMode == "Advanced")
			{
				Mode.Text = _ADVMODE;
				tabControl1.Visible = false;
				tabControl2.Visible = true;
				this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.Mode,
																					  
																					   this.configGroup,
																					   this.wowlaunch,
																					   // this.label2,
																					   this.UploadNow,
																					   this.showAddonsBtn,
																					   //this.URL,
																					   // this.AccountList,
																					   //this.label3,
																					  
																					   this.togSVList
																				   });
				if (!PathFound)
				{
					//this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {this.browse});
				}
				this.groupBox15.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.stwowlaunch,
																						 this.stmin,
																						 this.stboot});
				this.groupBox14.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.arg1check,
																						 this.valu1,
																						 this.valu2
																					 });
				this.tabPage8.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.copyrightInfoLabel,
																					   this.groupBox2});


				valu1.Location = new System.Drawing.Point(4, 35);
				valu2.Location = new System.Drawing.Point(4, 57);
				ProgramMode = "Basic";
			}
			else
			{
				Mode.Text = _SIMPMODE;
				tabControl1.Visible = true;
				tabControl2.Visible = false;
				this.Settings.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.Mode,
																					   this.progressBar1,
																					   this.configGroup,
																					   this.pictureBox1,
																					   this.wowlaunch,
																					   this.showAddonsBtn,
																					   //this.label2,
																					   this.UploadNow,
																					   // this.URL,
																					   //this.AccountList,
																					   //this.label3,
																					   
																					   this.togSVList
																				   });
				this.groupBox9.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.stwowlaunch,
																						this.stmin,
																						this.stboot});
				this.vargrp.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.valu2,
																					 this.valu1,
																					 this.arg1check});
				this.About.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.copyrightInfoLabel,
																					this.groupBox2});
				arrg1.Location = new System.Drawing.Point(24,16);
				valu1.Location = new System.Drawing.Point(64,16);
				arrg2.Location = new System.Drawing.Point(24,40);
				valu2.Location = new System.Drawing.Point(64,40);

				ProgramMode = "Advanced";
			}
		}

		public void PopulateLanguageSelector()
		{
			try
			{
				string file = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","")+"\\languages.ini";
				if (File.Exists(file))
				{
					LanguageIni = IniStructure.ReadIni(file);
					string[] allCategories = LanguageIni.GetCategories();
					if (allCategories.Length > 0)
					{
						langselect.Enabled = true;
						langselect.SelectedItem=Language;
						ResetLangVars(Language);
					}
					else
					{
						langselect.Enabled = false;
						langselect.SelectedItem="English";
					}
				}
				else
				{
					langselect.Enabled = false;
				}
			}
			catch (Exception e)
			{
				DebugLines("PopulateLanguageSelector: "+e.Message);
				langselect.Enabled = false;
			}
		}

		private void langselect_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string file = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","")+"\\languages.ini";
			if (File.Exists(file) == true)
			{
				ResetLangVars(langselect.SelectedItem.ToString());
				Language = langselect.SelectedItem.ToString();
			}
			else
			{
				DebugLine(_LANGNTFD);
			}
		}
		public void ResetLangVars(string Lang)
		{

			string file = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","")+"\\languages.ini";
			LanguageIni = IniStructure.ReadIni(file);
			string[] allCategories = LanguageIni.GetCategories();
			string[] keys;
			foreach (string category in allCategories)
			{
				if (category == Lang)
				{
					keys = LanguageIni.GetKeys(category);
					foreach (string key in keys)
					{
						string settingValue = LanguageIni.GetValue(category,key).Replace("<br>",'\n'.ToString());
						switch (key)
						{
								#region cases
							case "_UPDATERHELP":
								_UPDATERHELP = @settingValue;
								break;
							case "_PURGEFIRST":
								_PURGEFIRST = @settingValue;
								break;
							case "_INSTALL":
								_INSTALL = @settingValue;
								break;
							case "_ADDONAME":
								_ADDONAME = @settingValue;
								break;
							case "_ADDOVERS":
								_ADDOVERS = @settingValue;
								break;
							case "_ADDOTOC":
								_ADDOTOC = @settingValue;
								break;
							case "_ADDODESCRIP":
								_ADDODESCRIP = @settingValue;
								break;
							case "_UNLISTEDFILE":
								_UNLISTEDFILE = @settingValue;
								break;
							case "_CREATINGDIR":
								_CREATINGDIR = @settingValue;
								break;
							case "_WRITINGFILE":
								_WRITINGFILE = @settingValue;
								break;
							case "_ALLOWUAADDONDEL":
								_ALLOWUAADDONDEL = @settingValue;
								break;
							case "_DELETINGADDON":
								_DELETINGADDON = @settingValue;
								break;
							case "_CONFIGG":
								_CONFIGG = @settingValue;
								break;
							case "_SVBLS":
								_SVBLS = @settingValue;
								break;
							case "_ARRGS":
								_ARRGS = @settingValue;
								break;

							case "_CLEARTHESVS":
								_CLEARTHESVS = @settingValue;
								break;
							case "_SHOWSVSBUT":
								_SHOWSVSBUT = @settingValue;
								break;
							case "_HIDESVSBUT":
								_HIDESVSBUT = @settingValue;
								break;
							case "_SHOWADDONSBUT":
								_SHOWADDONSBUT = @settingValue;
								break;
							case "_HIDEADDONSBUT":
								_HIDEADDONSBUT = @settingValue;
								break;
							case "_AUTODETECTWOWCH":
								_AUTODETECTWOWCH = @settingValue;
								break;
							case "_FINDWOWEXEBUT":
								_FINDWOWEXEBUT = @settingValue;
								break;
							case "_SENDPWSECURELE":
								_SENDPWSECURELE = @settingValue;
								break;
							case "_DELAYTHEUPLOAD":
								_DELAYTHEUPLOAD = @settingValue;
								break;
							case "_BEFOREWOWLAUNCH":
								_BEFOREWOWLAUNCH = @settingValue;
								break;
							case "_BEFOREUPLOADING":
								_BEFOREUPLOADING = @settingValue;
								break;
							case "_AFTERUPLOADING":
								_AFTERUPLOADING = @settingValue;
								break;
							case "_SVFILETOWRITETO":
								_SVFILETOWRITETO = @settingValue;
								break;
							case "_DOWNLOADIT":
								_DOWNLOADIT = @settingValue;
								break;
							case "_USETHELAUNCHER":
								_USETHELAUNCHER = @settingValue;
								break;
							case "_THEDEBUGINFO":
								_THEDEBUGINFO = @settingValue;
								break;
							case "_CANTFINDLICENSE":
								_CANTFINDLICENSE = @settingValue;
								break;
							case "_THELICENSE":
								_THELICENSE = @settingValue;
								break;
							case "_EXPANDALL":
								_EXPANDALL = @settingValue;
								break;
							case "_COLLAPSEALL":
								_COLLAPSEALL = @settingValue;
								break;
							case "_THESEAREADDONS":
								_THESEAREADDONS = @settingValue;
								break;

								
							case "_TRANSLATIONS":
								_TRANSLATIONS = @settingValue;
								break;
							case "_LOGINONCE":
								_LOGINONCE = @settingValue;
								break;
							case "_WARNING":
								_WARNING = @settingValue;
								break;
							case "_WARNINGWILLCLEAR":
								_WARNINGWILLCLEAR = @settingValue;
								break;
							case "_UPDSRCHTIMEOUT":
								_UPDSRCHTIMEOUT = @settingValue;
								break;
							case "_LAUNCHOTHERPROGRAMS":
								_LAUNCHOTHERPROGRAMS = @settingValue;
								break;
							case "_ONUULAUNCH":
								_ONUULAUNCH = @settingValue;
								break;
							case "_ONWOWLAUNCH":
								_ONWOWLAUNCH = @settingValue;
								break;
							case "_MD5ID":
								_MD5ID = @settingValue;
								break;
							case "_STING":
								_STING = @settingValue;
								break;
							case "_FILECHDET":
								_FILECHDET = @settingValue;
								break;
							case "_UPLDING":
								_UPLDING = @settingValue;
								break;
							case "_PARSING":
								_PARSING = @settingValue;
								break;
							case "_COMPING":
								_COMPING = @settingValue;
								break;
							case "_UPDLANGPACK":
								_UPDLANGPACK = @settingValue;
								break;
							case "_UPLOAD":
								_UPLOAD = @settingValue;
								break;
							case "_STOPT":
								_STOPT = @settingValue;
								break;
							case "_UPLACC":
								_UPLACC = @settingValue;
								break;
							case "_UPLOADING_PRIMARY":
								_UPLOADING_PRIMARY = @settingValue;
								break;
							case "_USEUP":
								_USEUP = @settingValue;
								break;
							case "_UPLOADING_ADDURL1":
								_UPLOADING_ADDURL1 = @settingValue;
								break;
							case "_UPLOADING_ADDURL2":
								_UPLOADING_ADDURL2 = @settingValue;
								break;
							case "_UPLOADING_ADDURL3":
								_UPLOADING_ADDURL3 = @settingValue;
								break;
							case "_UPLOADING_ADDURL4":
								_UPLOADING_ADDURL4 = @settingValue;
								break;
							case "_RETRDATA":
								_RETRDATA = @settingValue;
								break;
							case "_WRITINGSV":
								_WRITINGSV = @settingValue;
								break;
							case "_READY":
								_READY = @settingValue;
								break;
							case "_CANTREADFILE":
								_CANTREADFILE = @settingValue;
								break;
							case "_WOWACCSEARCH":
								_WOWACCSEARCH = @settingValue;
								break;
							case "_NOTFOUND":
								_NOTFOUND = @settingValue;
								break;
							case "_NOACCFOUND":
								_NOACCFOUND = @settingValue;
								break;
							case "_INIT":
								_INIT = @settingValue;
								break;
							case "_WOWNOTFOUND":
								_WOWNOTFOUND = @settingValue;
								break;
							case "_STVALCREATE":
								_STVALCREATE = @settingValue;
								break;
							case "_STVALFIX":
								_STVALFIX = @settingValue;
								break;
							case "_STVALFUNC":
								_STVALFUNC = @settingValue;
								break;
							case "_REGPROB":
								_REGPROB = @settingValue;
								break;
							case "_STVALDEL":
								_STVALDEL = @settingValue;
								break;
							case "_STVALNOTFD":
								_STVALNOTFD = @settingValue;
								break;
							case "_HITBROWSE":
								_HITBROWSE = @settingValue;
								break;
							case "_HELP1":
								_HELP1 = @settingValue;
								break;
							case "_HELP2":
								_HELP2 = @settingValue;
								break;
							case "_HELP3":
								_HELP3 = @settingValue;
								break;
							case "_HELP4":
								_HELP4 = @settingValue;
								break;
							case "_GZIPPING":
								_GZIPPING = @settingValue;
								break;
							case "_NOCOMP":
								_NOCOMP = @settingValue;
								break;
							case "_COMPSIZE":
								_COMPSIZE = @settingValue;
								break;
							case "_UPLERR":
								_UPLERR = @settingValue;
								break;
							case "_DATARETRERR":
								_DATARETRERR = @settingValue;
								break;
							case "_CHECKSET":
								_CHECKSET = @settingValue;
								break;
							case "_UPDWOWADDON":
								_UPDWOWADDON = @settingValue;
								break;
							case "_CHUUUPDATE":
								_CHUUUPDATE = @settingValue;
								break;
							case "_WINDOWMODE":
								_WINDOWMODE = @settingValue;
								break;
							case "_CHANGES":
								_CHANGES = @settingValue;
								break;
							case "_UPDYESNO":
								_UPDYESNO = @settingValue;
								break;
							case "_NEWUPDAVAIL":
								_NEWUPDAVAIL = @settingValue;
								break;
							case "_UPDEXENOTFD":
								_UPDEXENOTFD = @settingValue;
								break;
							case "_DOWNUPD":
								_DOWNUPD = @settingValue;
								break;
							case "_OF":
								_OF = @settingValue;
								break;
							case "_DOWNLOADING":
								_DOWNLOADING = @settingValue;
								break;
							case "_SAVLOG":
								_SAVLOG = @settingValue;
								break;
							case "_UPDADDONSST":
								_UPDADDONSST = @settingValue;
								break;
							case "_RETRXMLDATA":
								_RETRXMLDATA = @settingValue;
								break;
							case "_XMLDATA":
								_XMLDATA = @settingValue;
								break;
							case "_XMLPARS":
								_XMLPARS = @settingValue;
								break;
							case "_NUMADDONS":
								_NUMADDONS = @settingValue;
								break;
							case "_ADDONLIST":
								_ADDONLIST = @settingValue;
								break;
							case "_NOADDONS":
								_NOADDONS = @settingValue;
								break;
							case "_NOWUPD":
								_NOWUPD = @settingValue;
								break;
							case "_ADDONSUPD":
								_ADDONSUPD = @settingValue;
								break;
							case "_ADDONUPD":
								_ADDONUPD = @settingValue;
								break;
							case "_MD5NOMATCH":
								_MD5NOMATCH = @settingValue;
								break;
							case "_UNZIPPING":
								_UNZIPPING = @settingValue;
								break;
							case "_DELZIPFILE":
								_DELZIPFILE = @settingValue;
								break;
							case "_UPDFOR":
								_UPDFOR = @settingValue;
								break;
							case "_ISCOMP":
								_ISCOMP = @settingValue;
								break;
							case "_FILENAME":
								_FILENAME = @settingValue;
								break;
							case "_ADDONRETRRESP":
								_ADDONRETRRESP = @settingValue;
								break;
							case "_ADVMODE":
								_ADVMODE = @settingValue;
								break;
							case "_SIMPMODE":
								_SIMPMODE = @settingValue;
								break;
							case "_URLLABEL":
								_URLLABEL = @settingValue;
								break;
							case "_SELACC":
								_SELACC = @settingValue;
								break;
							case "_FILELOC":
								_FILELOC = @settingValue;
								break;
							case "_BROWSE":
								_BROWSE = @settingValue;
								break;
							case "_AUTOPATH":
								_AUTOPATH = @settingValue;
								break;
							case "_WINMODE":
								_WINMODE = @settingValue;
								break;
							case "_LAUNCHWOW":
								_LAUNCHWOW = @settingValue;
								break;
							case "_SETTINGS":
								_SETTINGS = @settingValue;
								break;
							case "_SERVRESP":
								_SERVRESP = @settingValue;
								break;
							case "_UPLLABEL":
								_UPLLABEL = @settingValue;
								break;
							case "_DATARESP1":
								_DATARESP1 = @settingValue;
								break;
							case "_DATARESP2":
								_DATARESP2 = @settingValue;
								break;
							case "_DATARESP3":
								_DATARESP3 = @settingValue;
								break;
							case "_OPTIONS":
								_OPTIONS = @settingValue;
								break;
							case "_SECURITY":
								_SECURITY = @settingValue;
								break;
							case "_HTTPCRED":
								_HTTPCRED = @settingValue;
								break;
							case "_DOMAIN":
								_DOMAIN = @settingValue;
								break;
							case "_USER":
								_USER = @settingValue;
								break;
							case "_MISC":
								_MISC = @settingValue;
								break;
							case "_FFNAME":
								_FFNAME = @settingValue;
								break;
							case "_SIST":
								_SIST = @settingValue;
								break;
							case "_AOT":
								_AOT = @settingValue;
								break;
							case "_AUOFC":
								_AUOFC = @settingValue;
								break;
							case "_ADDVARS":
								_ADDVARS = @settingValue;
								break;
							case "_ADDURLS":
								_ADDURLS = @settingValue;
								break;
							case "_UPDATER":
								_UPDATER = @settingValue;
								break;
							case "_AUTOUPD":
								_AUTOUPD = @settingValue;
								break;
							case "_KMAU":
								_KMAU = @settingValue;
								break;
							case "_KMCUSU":
								_KMCUSU = @settingValue;
								break;
							case "_CFUTU":
								_CFUTU = @settingValue;
								break;
							case "_SYNCHURL":
								_SYNCHURL = @settingValue;
								break;
							case "_SAPU":
								_SAPU = @settingValue;
								break;
							case "_SYNCHNOW":
								_SYNCHNOW = @settingValue;
								break;
							case "_WARN":
								_WARN = @settingValue;
								break;
							case "_WARNMSG":
								_WARNMSG = @settingValue;
								break;
							case "_DEBUGGER":
								_DEBUGGER = @settingValue;
								break;
							case "_CLEARDB":
								_CLEARDB = @settingValue;
								break;
							case "_SAVEASDB":
								_SAVEASDB = @settingValue;
								break;
							case "_ADVANCED":
								_ADVANCED = @settingValue;
								break;
							case "_ADVANCEDSETTINGS":
								_ADVANCEDSETTINGS = @settingValue;
								break;
							case "_EFF":
								_EFF = @settingValue;
								break;
							case "_GZIPLAB":
								_GZIPLAB = @settingValue;
								break;
							case "_PP":
								_PP = @settingValue;
								break;
							case "_VARKEEP":
								_VARKEEP = @settingValue;
								break;
							case "_SITEWOW":
								_SITEWOW = @settingValue;
								break;
							case "_RETRDATA2":
								_RETRDATA2 = @settingValue;
								break;
							case "_WRITEAS":
								_WRITEAS = @settingValue;
								break;
							case "_OTHEROPT":
								_OTHEROPT = @settingValue;
								break;
							case "_DELAYUP":
								_DELAYUP = @settingValue;
								break;
							case "_SECONDS":
								_SECONDS = @settingValue;
								break;
							case "_STOPTIONS":
								_STOPTIONS = @settingValue;
								break;
							case "_STWITHWIN":
								_STWITHWIN = @settingValue;
								break;
							case "_AUTOLCHWOW":
								_AUTOLCHWOW = @settingValue;
								break;
							case "_STMINI":
								_STMINI = @settingValue;
								break;
							case "_HELP":
								_HELP = @settingValue;
								break;
							case "_SETT":
								_SETT = @settingValue;
								break;
							case "_OPTI":
								_OPTI = @settingValue;
								break;
							case "_ADV":
								_ADV = @settingValue;
								break;
							case "_INFOZ":
								_INFOZ = @settingValue;
								break;
							case "_ABT":
								_ABT = @settingValue;
								break;
							case "_CPY":
								_CPY = @settingValue;
								break;
							case "_LANG":
								_LANG = @settingValue;
								break;
							case "_LANGNTFD":
								_LANGNTFD = @settingValue;
								break;
							default:
								break;
								#endregion
						}
					}
				}
			}
			InitLanguageChange();
		}

		public void InitLanguageChange()
		{
			populateContextMenu2();

			label2.Text = _URLLABEL;
			label3.Text = _SELACC;
			windowmode.Text = _WINMODE;
			wowlaunch.Text = _LAUNCHWOW;
			langLabel.Text = _LANG;
			Settings.Text = _SETTINGS;
			response.Text = _SERVRESP;
			label7.Text = _UPLLABEL;
			servResponse.Text = _DATARESP1;
			retrdatawindow.Text = _DATARESP2;
			label6.Text = _DATARESP3;
			Options.Text = _OPTIONS;
			groupBox1.Text = _MISC;
			checkBox1.Text = _SIST;
			checkBox6.Text = _AOT;
			autoUploader.Text = _AUOFC;
			vargrp.Text = _ADDVARS;
			groupBox4.Text = _ADDURLS;
			wowAddons.Text = _UPDATER;
			groupBox11.Text = _AUTOUPD;
			addonAutoUpdate.Text = _KMAU;
			uuSettingsUpdater.Text = _KMCUSU;
			UUUpdaterCheck.Text = _CFUTU;
			label12.Text = _SYNCHURL;
			autoAddonSyncNow.Text = _SYNCHNOW;
			addonSyncBtn.Text = _SYNCHNOW;
			groupBox12.Text = _WARN;
			label14.Text = _WARNMSG;
			Debugger.Text = _DEBUGGER;
			Advanced.Text = _ADVANCED;
			groupBox5.Text = _ADVANCEDSETTINGS;
			GZcompress.Text = _GZIPLAB;
			groupBox10.Text = _SITEWOW;
			retrdatafromsite.Text = _RETRDATA2;
			groupBox6.Text = _OTHEROPT;
			label11.Text = _SECONDS;
			groupBox9.Text = _STOPTIONS;
			stboot.Text = _STWITHWIN;
			stwowlaunch.Text = _AUTOLCHWOW;
			stmin.Text = _STMINI;
			Help.Text = _HELP;
			button1.Text = _SETT;
			button2.Text = _OPTI;
			button3.Text = _ADV;
			button4.Text = _INFOZ;
			About.Text = _ABT;
			copyrightInfoLabel.Text = _CPY;
			UploadNow.Text = _UPLOAD;
			groupBox14.Text = _UPLACC;
			groupBox15.Text = _STOPT;
			arg1check.Text = _USEUP;
			if (ProgramMode == "Basic")
			{
				Mode.Text = _ADVMODE;
			}
			else
			{
				Mode.Text = _SIMPMODE;
			}
			groupBox2.Text = _ABT;
			btnTranslations.Text = _TRANSLATIONS;

			tabPage8.Text = _ABT;
			tabPage1.Text = _SETTINGS;
			exe1Browse.Text = _BROWSE;
			exe2Browse.Text = _BROWSE;
			exe3Browse.Text = _BROWSE;
			otherexes.Text = _LAUNCHOTHERPROGRAMS;
			exeOnUuStart.Text = _ONUULAUNCH;
			exeOnWowLaunch.Text = _ONWOWLAUNCH;
			

			AutoInstallDirDetect.Text = _AUTODETECTWOWCH;
			findInstallBtn.Text = _FINDWOWEXEBUT;
			sendPwSecurely.Text = _SENDPWSECURELE;
			delaych.Text = _DELAYTHEUPLOAD;
			chWtoWOWbeforeWOWLaunch.Text = _BEFOREWOWLAUNCH;
			chWtoWOWbeforeUpload.Text = _BEFOREUPLOADING;
			chWtoWOWafterUpload.Text = _AFTERUPLOADING;
			webToWowLbl.Text = _SVFILETOWRITETO;
			btnWtoWOWDownload.Text = _DOWNLOADIT;
			chUseLauncher.Text = _USETHELAUNCHER;
			label5.Text = _THEDEBUGINFO;
			
			btnLegal.Text = _THELICENSE;
			button6.Text = _EXPANDALL;
			button7.Text = _COLLAPSEALL;
			label8.Text = _THESEAREADDONS;


			
			if (this.ClientSize.Width < 640)
			{
				togSVList.Text = _SHOWSVSBUT;
			}
			else
			{
				togSVList.Text = _HIDESVSBUT;
			}
			
			if (this.ClientSize.Height < 450)
			{
				showAddonsBtn.Text = _SHOWADDONSBUT;
			}
			else
			{
				showAddonsBtn.Text = _HIDEADDONSBUT;
			}

			clearSVFiles.Text = _CLEARTHESVS;

			label15.Text= _ARRGS;
			configGroup.Text = _CONFIGG;
			groupBox3.Text = _SVBLS;

			chAllowDelAddons.Text=_ALLOWUAADDONDEL;
			label16.Text=_ADDONAME;
			label13.Text=_ADDOVERS;
			label10.Text=_ADDOTOC;
			label9.Text=_ADDODESCRIP;
			purgefirstCh.Text = _PURGEFIRST;





		}

		public void UpdateLanguagePack()
		{
			string updaterLocation = "http://www.wowroster.net/uniuploader_updater2/update.php";
			string UUPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","");
			//lang file retrieval
			string UpdateQueryResponse = RetrData(updaterLocation,null,null,"OPERATION","GETLANGLATEST",null,null,null,null,-1,null,null);
			string fileName = GetfileNameFromURI(UpdateQueryResponse);
			string FileLocalLocation = UUPath+@"\"+fileName;
			statusBarPanel1.Text = _DOWNLOADING+" languages.ini";
			download(UpdateQueryResponse,FileLocalLocation);
			progressBar1.Value = 0;
			progressBar1.Update();
			ConvertTextFileFromNtoRN(FileLocalLocation);

		}

		public static byte[] StrToByteArray(string str)
		{
			System.Text.ASCIIEncoding  encoding=new System.Text.ASCIIEncoding();
			return encoding.GetBytes(str);
		}

		private void siteToWowSaveas_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Text file|*.txt";
			//saveFileDialog1.Title = _SAVLOG;
			saveFileDialog1.ShowDialog(); 
			if(saveFileDialog1.FileName != "")
			{
				// Saves the Image via a FileStream created by the OpenFile method.
				System.IO.FileStream fs = 
					(System.IO.FileStream)saveFileDialog1.OpenFile();
				System.Text.ASCIIEncoding  encoding = new System.Text.ASCIIEncoding();
				byte[] BodyByteArray = encoding.GetBytes(retrdatawindow.Text);
				fs.Write(BodyByteArray,0,BodyByteArray.Length);
				fs.Close();
			}
		}

		private void servResponseSaveas_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Text file|*.txt";
			//saveFileDialog1.Title = _SAVLOG;
			saveFileDialog1.ShowDialog(); 
			if(saveFileDialog1.FileName != "")
			{
				// Saves the Image via a FileStream created by the OpenFile method.
				System.IO.FileStream fs = 
					(System.IO.FileStream)saveFileDialog1.OpenFile();
				System.Text.ASCIIEncoding  encoding = new System.Text.ASCIIEncoding();
				byte[] BodyByteArray = encoding.GetBytes(servResponse.Text);
				fs.Write(BodyByteArray,0,BodyByteArray.Length);
				fs.Close();
			}
		
		}

		private void ClearSiteWoW_Click(object sender, System.EventArgs e)
		{
			retrdatawindow.Clear();
		}

		private void ClearServResp_Click(object sender, System.EventArgs e)
		{
			servResponse.Clear();
		}

		private void exe1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (exe1.Checked)
			{
				exe1Browse.Enabled = true;
				exe1Location.Enabled = true;
			}
			else
			{
				exe1Browse.Enabled = false;
				exe1Location.Enabled = false;
			}
		}

		private void exe2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (exe2.Checked)
			{
				exe2Browse.Enabled = true;
				exe2Location.Enabled = true;
			}
			else
			{
				exe2Browse.Enabled = false;
				exe2Location.Enabled = false;
			}
		}

		private void exe3_CheckedChanged(object sender, System.EventArgs e)
		{
			if (exe3.Checked)
			{
				exe3Browse.Enabled = true;
				exe3Location.Enabled = true;
			}
			else
			{
				exe3Browse.Enabled = false;
				exe3Location.Enabled = false;
			}
		}

		private void exeOnSrtart_CheckedChanged(object sender, System.EventArgs e)
		{
			exe1.Enabled = true;
			exe2.Enabled = true;
			exe3.Enabled = true;
		}

		private void exeOnWowLaunch_CheckedChanged(object sender, System.EventArgs e)
		{
			exe1.Enabled = true;
			exe2.Enabled = true;
			exe3.Enabled = true;
		}

		private void LaunchEXE(string EXELocation, string Arguments)
		{
			System.Diagnostics.ProcessStartInfo start = null;
			if (Arguments == null)
			{
				start = new System.Diagnostics.ProcessStartInfo(EXELocation);
			}
			else
			{
				start = new System.Diagnostics.ProcessStartInfo(EXELocation,Arguments);
			}
			start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
			System.Diagnostics.Process.Start(start);
		}

		private void exe1Browse_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
			OpenFileDialog1.Filter = "Program Executable (*.exe)|*.exe|Batch File (*.bat)|*.bat";
			OpenFileDialog1.Title = "Select Program";
			OpenFileDialog1.ShowDialog();
			if (OpenFileDialog1.FileName != "")
			{
				exe1Location.Text = OpenFileDialog1.FileName;
			}
		}

		private void exe2Browse_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
			OpenFileDialog1.Filter = "Program Executable (*.exe)|*.exe|Batch File (*.bat)|*.bat";
			OpenFileDialog1.Title = "Select Program";
			OpenFileDialog1.ShowDialog();
			if (OpenFileDialog1.FileName != "")
			{
				exe2Location.Text = OpenFileDialog1.FileName;
			}
		}

		private void exe3Browse_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
			OpenFileDialog1.Filter = "Program Executable (*.exe)|*.exe|Batch File (*.bat)|*.bat";
			OpenFileDialog1.Title = "Select Program";
			OpenFileDialog1.ShowDialog();
			if (OpenFileDialog1.FileName != "")
			{
				exe3Location.Text = OpenFileDialog1.FileName;
			}
		}

		private void respOpenNP_Click(object sender, System.EventArgs e)
		{
			string exe = getOpenWithApp(".txt");
			if (exe == "")
			{
				exe = "NOTEPAD.EXE";
			}
			runApp(servResponse.Text,exe,"RespNotepad.htm");
		}

		private void respOpenIE_Click(object sender, System.EventArgs e)
		{
			runApp(servResponse.Text,"IEXPLORE.EXE","RespNotepad.htm");
		}

		private void respOpenNP2_Click(object sender, System.EventArgs e)
		{
			string exe = getOpenWithApp(".txt");
			if (exe == "")
			{
				exe = "NOTEPAD.EXE";
			}
			runApp(retrdatawindow.Text,exe,"SiteSVNotepad.htm");
		}

		private void respOpenIE2_Click(object sender, System.EventArgs e)
		{
			runApp(retrdatawindow.Text,"IEXPLORE.EXE","SiteSVIE.htm");
		}

		private void populateSvList()
		{
			bool checkThem = false; //unchecked by default
			if (checkedSVsFromSettings != null)checkThem = false;
			SVList.Items.Clear();
			if (Directory.Exists(mainSvLocation.Replace(".lua","")))
			{
				string[] svFiles = Directory.GetFiles(mainSvLocation.Replace(".lua",""),"*.lua");

				for (int a = 0; a < svFiles.Length; a++)
				{
					if (a == 0)SVList.Items.Add("SavedVariables",false);
					SVList.Items.Add(Path.GetFileName(svFiles[a]).Replace(".lua",""),checkThem);
				}

				if (checkedSVsFromSettings != null)
				{
					bool checkIt = false;

					for( int i=0 ; i < SVList.Items.Count; i++ )
					{
						foreach (string settingSV in checkedSVsFromSettings)
						{
							if (settingSV == (string)SVList.Items[i])checkIt = true;
						}
						if (checkIt)SVList.SetItemChecked(i, true);
						checkIt = false;
					}
				}
				else
				{
					checkDefaultSVs();
				}
				sortSVList();
			}
			else
			{
				//the SavedVariables folder isn't there, tell the user to log into wow
				//MessageBox.Show(_LOGINONCE);
			}

			

		}

		private void SVList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int a = 0;
			string delimited = "";
			foreach (string checkedItem in SVList.CheckedItems)
			{
				if (a > 0)
					delimited += "|"+checkedItem;
				else
					delimited = checkedItem;
				a++;
			}
			checkedSVsFromSettings = delimited.Split('|');
		}

		private void togSVList_Click(object sender, System.EventArgs e)
		{
			if (Form1.ActiveForm.Size.Width < 640)
			{
				togSVList.Text = _HIDESVSBUT;
				this.Width = 645;
			}
			else
			{
				togSVList.Text = _SHOWSVSBUT;
				//Form1.ActiveForm.Size.Width = 504;

				this.Width = 496;
			}
		
		}

		private void btnTranslations_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(@"French - Gryndel, shan_aya
Deutsch - Nightreaver, SethDeBlade
Nederlands - TheAvenger@Al'Akir
Russian - NSentinel
Swedish - KaThogh","",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
		}

		private void clearSVFiles_Click(object sender, System.EventArgs e)
		{

			if (MessageBox.Show(_WARNINGWILLCLEAR,_WARNING,MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{


				string path = "";
				foreach (string checkedSV in SVList.CheckedItems)
				{
					if (checkedSV != "SavedVariables")
					{
						path = mainSvLocation.Replace(".lua","") + @"\" + checkedSV + ".lua";
					}
					else
					{
						path = mainSvLocation;
					}

					try
					{
						File.Delete(path);
						using (FileStream fs = File.Create(path)) 
						{
							byte[] info = new UTF8Encoding(true).GetBytes("");
							fs.Write(info, 0, info.Length);
						}
					}
					catch (Exception ex)
					{
						DebugLine("clearSVFiles_Click: " + ex.Message);
					}
				}
			}
		}

		private void checkLangFile()
		{
			string updaterLocation = "http://www.wowroster.net/uniuploader_updater2/update.php";
			string serverMD5 = "";
			serverMD5 = RetrData(updaterLocation,null,null,"OPERATION","GETLANGMD5",null,null,null,null,20000,null,null);
			if (serverMD5 != "")
			{
				string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\","") + "\\languages.ini";
				string md5sum = "";
				if (File.Exists(path))
				{
					md5sum = MD5SUM(FileToByteArray(path));
					DebugLine("MD5SUM of local languages.ini: " + md5sum);
				}

				if (md5sum != serverMD5)
				{
					UpdateLanguagePack();	
					PopulateLanguageSelector();
				}
			}
		}

		private void checkDefaultSVs()
		{


			for (int z = 0;z < SVList.Items.Count; z++)
			{
				foreach (string preset in presets)
				{
					if (preset == SVList.Items[z].ToString())
					{
						SVList.SetItemChecked(z,true);
					}
				}
			}
			//populate the checked sv list
			this.checkedSVsFromSettings = new string[SVList.CheckedItems.Count];

			for(int z = 0;z < SVList.CheckedItems.Count; z++) 
			{
				this.checkedSVsFromSettings[z] = SVList.CheckedItems[z].ToString();
			}


		}

		private void sortSVList()
		{
			string[,] svList = new string[SVList.Items.Count,2];
			for (int i=0; i < SVList.Items.Count;i++)
			{
				svList[i,0] = SVList.Items[i].ToString();
				
				foreach(string checkedSV in SVList.CheckedItems)
				{
					if (checkedSV == svList[i,0])
					{
						svList[i,1] = "checked";
						break;
					}
					else
					{
						svList[i,1] = "";
					}
				}
			}
			string buff = "";
			for (int index = 0; index < svList.Length / 2; index++)
			{
				for (int i = 0; i < svList.Length / 2; i++)
				{
					if (svList[index,1] != "checked" && svList[i,1] == "checked")
					{
						buff = svList[index,0];
						svList[index,0] = svList[i,0];
						svList[index,1] = "checked";
						svList[i,0] = buff;
						svList[i,1] = "";
					}
				}
			}
			if (svList.Length > 0)
			{
				SVList.Items.Clear();
				for (int i=svList.Length / 2 - 1; i >= 0; i--)
				{
					if (svList[i,0] != "checked" && svList[i,0] != ""  )
					{
						if (svList[i,1] == "checked")
						{
							SVList.Items.Add(svList[i,0],true);
						}
						else
						{
							SVList.Items.Add(svList[i,0],false);
						}
					}
				}
			}	
		}

		private void dbNPbtn_Click(object sender, System.EventArgs e)
		{
			string exe = getOpenWithApp(".txt");
			if (exe == "")
			{
				exe = "NOTEPAD.EXE";
			}

			string contents = "";

			foreach (string item in DebugBox.Items)
			{
				contents += item + "\r\n";
			}
			runApp(contents,exe,"debug_notepad.txt");

		}

		private void dbIEbtn_Click(object sender, System.EventArgs e)
		{
			

			string contents = "";
			foreach (string item in DebugBox.Items)
			{
				contents += item + "\r\n";
			}
			runApp(contents,"IEXPLORE.EXE","debug_ie.txt");
		}

		private void runApp(string contents, string program, string filename)
		{
			string file = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ).Replace("file:\\","")+"\\"+filename;
			if (File.Exists(file) == true)@File.Delete(file);
			using (FileStream fs = File.Create(file)) 
			{
				byte[] info = new UTF8Encoding(true).GetBytes(contents);
				fs.Write(info, 0, info.Length);
			}
			System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(program,file);
			start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
			System.Diagnostics.Process.Start(start);
		
		
		}

		private void filesysDelay_Tick(object sender, System.EventArgs e)
		{
			//filesysDelay.Enabled = false;

			if (filesysDelay_enabled)
			{
				filesysDelay_enabled = false;
				setupWatchers();
				populateSvList();
				filesysDelay_flag1 = true;
				OnChanged(this, new System.IO.FileSystemEventArgs(WatcherChangeTypes.Created,"",""));
			}
		
		}

		private void btnLegal_Click(object sender, System.EventArgs e)
		{
			showLicense(false);
		}
		private bool showLicense(bool buttons)
		{
			string txtFilePath = Path.GetDirectoryName(Application.ExecutablePath)+"\\LICENSE.TXT";
			if (!File.Exists(txtFilePath))
			{
				MessageBox.Show(_CANTFINDLICENSE);
				return true;
			}
			/*
			Form licenseForm = new Form();
			TextBox license = new System.Windows.Forms.TextBox();
			license.AcceptsReturn = true;
			license.AcceptsTab = true;
			license.Location = new System.Drawing.Point(1, 1);
			license.Multiline = true;
			license.Name = "license";
			license.ReadOnly = true;
			license.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			license.Size = new System.Drawing.Size(490, 365);
			license.TabIndex = 1;
			license.WordWrap = true;
			licenseForm.Controls.Add(license);
			licenseForm.Size = new System.Drawing.Size(500, 400);
			licenseForm.MaximumSize = new System.Drawing.Size(500, 400);
			licenseForm.MinimumSize = new System.Drawing.Size(500, 400);
			licenseForm.TopMost = true;
			licenseForm.AutoScale = false;
			licenseForm.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			licenseForm.ClientSize = new System.Drawing.Size(494, 280);
			licenseForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			licenseForm.HelpButton = false;
			//licenseForm.Icon = ((System.Drawing.Icon)(resources.GetObject("$licenseForm.Icon")));
			licenseForm.MaximizeBox = false;
			licenseForm.MinimizeBox = false;
			licenseForm.Name = "uuLicense";
			licenseForm.ShowInTaskbar = false;
			
			licenseForm.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			licenseForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			licenseForm.Text = "UniUploader License";
			licenseForm.Show();
			license.WordWrap = false;
			license.Text = ReadFileToString(txtFilePath).Replace("\n",Environment.NewLine);
			//runApp(contents,exe,"debug_notepad.txt");
			*/

			string exe = getOpenWithApp(".txt");
			if (exe == "")
			{
				exe = "NOTEPAD.EXE";
			}
			LaunchEXE(exe,txtFilePath);
			//runApp(servResponse.Text,exe,txtFilePath);


			return true;

		}

		private string getOpenWithApp(string ext)
		{
			
			string keyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\"+ext+@"\OpenWithList";
			RegistryKey key = Registry.CurrentUser.OpenSubKey( keyPath );

			
			if (key != null)
			{
				if ( key.GetValue( "a" ) != null ) 
				{
					return (string)key.GetValue ("a");
				}
			}
			
			return "";
		}

		private void btnWtoWOWDownload_Click(object sender, System.EventArgs e)
		{
			doWebsiteToWow();
		}

		private void AutoInstallDirDetect_CheckedChanged(object sender, System.EventArgs e)
		{
			if (AutoInstallDirDetect.Checked)
			{
				findInstallBtn.Enabled = false;
				GetInstallPath();
				populateAccountList();
				populateSvList();
				setupWatchers();
			}
			else
			{
				findInstallBtn.Enabled = true;
			}
		}

		private void findInstallBtn_Click(object sender, System.EventArgs e)
		{
			wowExeLocBrowsed = "";
			browseWoWDir();
			populateAccountList();
			populateSvList();
			setupWatchers();
		}

		private string getUserAgent()
		{
			string agent = buildUserAgent();
			if (userAgent.Text != agent)
				agent = userAgent.Text;
			return agent;
		}
		private string buildUserAgent()
		{
			return "UniUploader "+uniVersionMajor + ".0 (UU " + uniVersionMajor+ "." +uniVersionMinor + "." +uniVersionRevision+"; "+Language+")";
		}

		public string Upload(string fileName, string url,string fieldname, CookieContainer cookies, CredentialCache credentials, string param1, string param2, string param3, string param4, string val1, string val2, string val3, string val4) 
		{
			System.Net.ServicePointManager.Expect100Continue= false;

			string path = mainSvLocation.Replace(".lua","");
			string fullFilePath = "";
			string FileNameOnlyName = "";
			byte[] fileContents;

			// Initialize the request object
			HttpWebRequest req = (WebRequest.Create(url) as HttpWebRequest);
			//if (cookies != null) req.CookieContainer = cookies;
			req.CookieContainer = cookieJar;
			if (credentials != null) req.Credentials = credentials;
			req.UserAgent = getUserAgent();

			string boundary = Guid.NewGuid().ToString().Replace("-", "");
			req.ContentType = "multipart/form-data; boundary=" + boundary;
			req.Method = "POST";
			req.Accept = "application/x-shockwave-flash,text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
			//req.Headers.Add("Accept-Language","en-us,en;q=0.5");
			//req.Headers.Add("Accept-Encoding","gzip,deflate");
			//req.Headers.Add("Accept-Charset","ISO-8859-1,utf-8;q=0.7,*;q=0.7");

			MemoryStream postData = new MemoryStream();
			string newLine = "\r\n";
			StreamWriter sw = new StreamWriter(postData);
      

			if (param1 != null)
			{
				sw = addVar(sw,boundary,param1,val1);
			}
			if (param2 != null)
			{
				sw = addVar(sw,boundary,param2,val2);
			}
			if (param3 != null)
			{
				sw = addVar(sw,boundary,param3,val3);
			}
			if (param4 != null)
			{
				sw = addVar(sw,boundary,param4,val4);
			}

			//include the query string key-value pairs eg. http://somewhere.com&foo=bar
			Hashtable queryStringParams = getQueryStringParams(url);
			IDictionaryEnumerator en = queryStringParams.GetEnumerator();
			while (en.MoveNext())
			{
				sw = addVar(sw,boundary,en.Key.ToString(),en.Value.ToString());
			}

			foreach (string checkedSV in SVList.CheckedItems) //itterate through all checked files in the sv file list
			{
				if (checkedSV != "SavedVariables")
				{
					fullFilePath = path + @"\" + checkedSV + ".lua";
				}
				else
				{
					string delimStr = @"\";
					char [] delimiter = delimStr.ToCharArray();
					string[] splitPath = path.Split(delimiter);
					string shortPath = "";

					foreach (string pathPart in splitPath)
					{
						if (pathPart != "SavedVariables")
							shortPath += pathPart + @"\";
					}

					fullFilePath = shortPath + "SavedVariables.lua";
				}	
				fileContents = FileToByteArray(fullFilePath);
				if (fileContents == null){DebugLine("Upload: couldnt read \""+fullFilePath+"\""); return "Error: see debug log.";} //couldnt read the file
				int uSize = fileContents.Length;
				FileNameOnlyName = Path.GetFileName(fullFilePath);

				if (GZcompress.Checked)
				{
					MemoryStream ContentsGzippedStream = new MemoryStream();	//create the memory stream to hold the compressed file
					Stream s = new GZipOutputStream(ContentsGzippedStream);		//create the gzip filter
					s.Write(fileContents,0,fileContents.Length);				//write the file contents to the filter
					s.Flush();													//make sure everythings ready
					s.Close();													//close and write the compressed data to the memory stream
					byte[] ContentsGzippedA	= ContentsGzippedStream.ToArray();	//make new byte array to hold the compressed data
					decimal ratio = Math.Round(decimal.Subtract(100,decimal.Multiply(100,(decimal.Divide(ContentsGzippedA.Length,(fileContents.Length + 1))))));	// get the compression ratio
					if (ratio < 0){ratio = 0;} //in case Contents.lengh = 0
					double cLen = ContentsGzippedA.Length;
					double compressedSize = Math.Round((cLen / 1000),2);							//get the compressed size
					fileContents = ContentsGzippedA;								//write the byte array to the final array
					DebugLine(FileNameOnlyName + " - " + Convert.ToString(ratio) + "% "+_COMPSIZE+": " + compressedSize.ToString("F") + " KB");
					FileNameOnlyName += ".gz";				//change the filename to reflect the gzip compression
					sw = addVar(sw,boundary,"usize_"+checkedSV,uSize.ToString());

				}
				else 
				{
					decimal uncompressedSize = Math.Round(decimal.Divide(fileContents.Length,1000));
					DebugLine(FileNameOnlyName + " - " + _NOCOMP+": " + Convert.ToString(uncompressedSize) + " KB");
				}

				sw.Write("--" + boundary + newLine);
				sw.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}" , checkedSV , FileNameOnlyName , newLine);
				sw.Write("Content-Type: application/octet-stream" + newLine + newLine);
				sw.Flush();
				postData.Write(fileContents, 0, fileContents.Length);
				sw.Write(newLine);

			}


			DateTime _datetime = DateTime.Now;
			string dateTimeNow = _datetime.ToString("s", DateTimeFormatInfo.InvariantInfo) + "Z";
			string dateTimeNowUTC = _datetime.ToUniversalTime().ToString("s", DateTimeFormatInfo.InvariantInfo) + "Z";

			//Client time variable - normal time
			sw = addVar(sw,boundary,"clientTime",dateTimeNow);

			//Client time variable - UTC time
			sw = addVar(sw,boundary,"clientTimeUTC",dateTimeNowUTC);


			sw.Write("--{0}--{1}", boundary, newLine);
			sw.Flush();

			req.Timeout = 120000; //2 minutes
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
				DebugLine("Upload Error: "+e.Message);
			}

			string responseString = "";

			try 
			{
				WebResponse resp = req.GetResponse();
				StreamReader reader = new StreamReader(resp.GetResponseStream() );
				responseString = reader.ReadToEnd();
				reader.Close();
			}
			catch (Exception e) 
			{
				DebugLine(_UPLERR+e.Message);
			}

			
			return (responseString);
		}
		private Hashtable getQueryStringParams(string url)
		{
			int queryStringStart = url.IndexOf("?");
			if (queryStringStart == -1)return new Hashtable();
			string queryString = url.Substring(queryStringStart + 1);
			Hashtable h = new Hashtable();

			string[] pairs = queryString.Split('&');
			foreach(string pair in pairs)
			{
				try
				{
					string[] splitPair = pair.Split('=');
					h[splitPair[0]] = splitPair[1];
				}
				catch
				{
				}
			}
			return h;
		}

		public string RetrData(string url, CookieContainer cookies, CredentialCache credentials, string param1, string val1, string param2, string val2, string param3, string val3, int Timeout, string param4, string val4) 
		{
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
				DebugLine("RetrData: val2: (hidden)");
			}
			if (param3 != null)
			{
				DebugLine("RetrData: param3: " + param3);
				DebugLine("RetrData: val3: (hidden)");
			}
			DebugLine("RetrData: Timeout: " + Timeout);

			DebugLine("RetrData: ------------------------------------------------------------------------");

			System.Net.ServicePointManager.Expect100Continue= false;
			retrdatawindow.Text = "";

			// Initialize the request object
			HttpWebRequest req = (WebRequest.Create(url) as HttpWebRequest);
			//if (cookies != null) req.CookieContainer = cookies;
			req.CookieContainer = cookieJar;
			if (credentials != null) req.Credentials = credentials;
      

			req.UserAgent = getUserAgent();
			string boundary = Guid.NewGuid().ToString().Replace("-", "");
			req.ContentType = "multipart/form-data; boundary=" + boundary;
			req.Method = "POST";
			req.Accept = "application/x-shockwave-flash,text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
			//req.Headers.Add("Accept-Language","en-us,en;q=0.5");
			//req.Headers.Add("Accept-Encoding","gzip,deflate");
			//req.Headers.Add("Accept-Charset","ISO-8859-1,utf-8;q=0.7,*;q=0.7");



			if (Timeout > 0)
			{
				req.Timeout = Timeout;
			}
			MemoryStream postData = new MemoryStream();
			string newLine = "\r\n";
			StreamWriter sw = new StreamWriter(postData);
      

			//include the query string key-value pairs eg. http://somewhere.com&foo=bar
			Hashtable queryStringParams = getQueryStringParams(url);
			IDictionaryEnumerator en = queryStringParams.GetEnumerator();
			while (en.MoveNext())
			{
				sw = addVar(sw,boundary,en.Key.ToString(),en.Value.ToString());
			}


			if (param1 != null)
			{
				sw = addVar(sw,boundary,param1,val1);
			}
			if (param2 != null)
			{
				sw = addVar(sw,boundary,param2,val2);
			}
			if (param3 != null)
			{
				sw = addVar(sw,boundary,param3,val3);
			}
			if (param4 != null)
			{
				sw = addVar(sw,boundary,param4,val4);
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
				DebugLine(_DATARETRERR+e.Message);
			}
			sw.Close();
			postData.Close();


			DebugLines(responseString.Split(new Char[] {'\n'}));
			DebugLine("RetrData: ------------------------------------------------------------------------");
			DebugLine("");
			
			return (responseString);
		}

		private StreamWriter addVar(StreamWriter sw, string boundary, string varName, string varValue)
		{
			string newLine = "\r\n";

			sw.Write("--" + boundary + newLine);
			//sw.Write("Content-Disposition: form-data; name=\""+varName+"\";" , newLine);
			sw.Write("Content-Disposition: form-data; name=\""+varName+"\"");
			sw.Write(newLine);
			sw.Write(newLine);
			//sw.Write("Content-Type: text/html" + newLine + newLine);
			sw.Flush();
			sw.Write(varValue);
			sw.Write(newLine);
			sw.Flush();

			return sw;
		}

		private void showAddonsBtn_Click(object sender, System.EventArgs e)
		{
			if (Form1.ActiveForm.Size.Height < 450)
			{
				showAddonsBtn.Text = _HIDEADDONSBUT;
				this.Height = 472;
			}
			else
			{
				showAddonsBtn.Text = _SHOWADDONSBUT;
				this.Height = 296;
			}
		}

		private void debugcheckedaddons()
		{
			foreach(string s in checkedAddons)
			{
				servResponse.Text += s+"\r\n";
			}
			servResponse.Text += "\r\n\r\n";
		}
		public void doAddonList(XmlNodeList lstXMLData)
		{
			availableAddons = new ArrayList();
			foreach (XmlNode Node in lstXMLData) 
			{
				Hashtable addon = new Hashtable();
				string name = Node.Attributes.GetNamedItem("name").Value.ToString();
				string required = "1";
				try { required = Node.Attributes.GetNamedItem("required").Value.ToString();} 
				catch {}
				string toc = "?????";
				try {toc = Node.Attributes.GetNamedItem("toc").Value.ToString();}
				catch{}
				string version = Node.Attributes.GetNamedItem("version").Value.ToString();
				string notes = "";
				try {notes = Node.Attributes.GetNamedItem("notes").Value.ToString();}
				catch{}
				//MessageBox.Show(version);
				//				addonsList.Items.Add(AddonName+" "+required+" "+toc+" "+version);

				addon["name"] = name;
				addon["required"] = required;
				addon["toc"] = toc;
				addon["version"] = version;
				addon["notes"] = notes;
				availableAddons.Add(addon);
			}


			treeView1.Nodes.Clear();

			foreach(Hashtable addon in availableAddons)
			{
				string name = (string)addon["name"];
				string required = (string)addon["required"];
				string toc = (string)addon["toc"];
				string version = (string)addon["version"];
				string notes = (string)addon["notes"];



				bool isChecked = false;
				foreach (string checkedAddon in checkedAddons)
				{
					if (checkedAddon == (string)addon["name"])isChecked = true;
				}
				if (required == "1")isChecked = true;
				addAddontoAddonList(name,version,toc,isChecked,notes);
				showAddonsBtn.Enabled = true;
			}

			//UploadThread.
			//debugcheckedaddons();
/*
			checkedAddons = new ArrayList();

			foreach(TreeNode node in treeView1.Nodes)
			{
				//if (node.Parent == null)
				//{
					if (node.Checked)
						checkedAddons.Add(node.Text);
				//}
			}
*/			
			return;

		}

		private void addAddontoAddonList(string name, string version, string toc, bool isChecked,string notes)
		{
			TreeNode myNode = new TreeNode();
			myNode.Text=name;
			myNode.Nodes.Add(new TreeNode(version,1,1));
			myNode.Nodes.Add(new TreeNode(toc,2,2));
			myNode.Nodes.Add(new TreeNode(notes,3,3));
			myNode.Checked = isChecked;
			myNode.ImageIndex = 0;

			foreach (Hashtable addon in availableAddons)
			{
				string thisName = (string)addon["name"];
				string isRequired = (string)addon["required"];

				if (thisName == name && isRequired == "1")
				{
					myNode.ForeColor = Color.Red;
				}
			}

			// Check if we need to call BeginInvoke.
			if (this.InvokeRequired)
			{
				// Pass the same function to BeginInvoke,
				// but the call would come on the correct
				// thread and InvokeRequired will be false.
				this.BeginInvoke(new AddAddonNodeDelegate(AddAddonNode), 
					new object[] {myNode});

				return;
			}
			treeView1.Nodes.Add(myNode);
		}
		private delegate void AddAddonNodeDelegate(TreeNode myNode);
		private void AddAddonNode(TreeNode myNode)
		{
			treeView1.Nodes.Add(myNode);
			if (myNode.Checked)
				CheckAllChildNodes(myNode,true);
		}

		// Updates all child tree nodes recursively.
		private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
		{
			foreach(TreeNode node in treeNode.Nodes)
			{
				node.Checked = nodeChecked;
				if(node.Nodes.Count > 0)
				{
					// If the current node has child nodes, call the CheckAllChildsNodes method recursively.
					this.CheckAllChildNodes(node, nodeChecked);
				}
			}
		}

		// NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
		// After a tree node's Checked property is changed, all its child nodes are updated to the same value.
		private void node_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if(e.Node.Nodes.Count > 0)
			{
				this.CheckAllChildNodes(e.Node, e.Node.Checked);
				if (e.Node.Checked)
				{
					checkedAddons.Add(e.Node.Text);
				}
				else
				{
					checkedAddons.Remove(e.Node.Text);
				}
			}
		}

		private bool isAddonChecked(string addonToCheck)
		{
			foreach (string s in checkedAddons)
			{
				if (s == addonToCheck)return true;
			}
			return false;
		}

		private void treeView1_BeforeCheck(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown)
			{
				if (e.Node.Parent != null)
				{
					e.Cancel = true;
				}
				else
				{
					bool required = false;
					foreach(Hashtable addon in availableAddons)
					{
						string name			= (string)addon["name"];
						string isRequired	= (string)addon["required"];
						string toc			= (string)addon["toc"];
						string version		= (string)addon["version"];
						if (name == e.Node.Text)
						{
							if (isRequired == "1")required = true;
						}
					}
					if (required)
					{
						if (e.Node.Checked)
						{
							e.Cancel = true;
						}
					}
				}
			}
		}

		private void treeView1_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
		
			if (e.Action != TreeViewAction.Unknown)
			{
				if (e.Node.Parent != null)
				{
					treeView1.SelectedNode = e.Node.Parent;
					e.Cancel = true;
				}
			}
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			treeView1.ExpandAll();
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			treeView1.CollapseAll();
		}

		private void chAllowDelAddons_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void linkLabel2_LinkClicked_1(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			linkLabel2.LinkVisited=true;
			System.Diagnostics.Process.Start("http://wowroster.net/Your_Account/profile=MattM.html");
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Text= _UPDATERHELP;
		}

		private void addonSyncBtn_Click(object sender, System.EventArgs e)
		{
			job = new ThreadStart(doAddons);
			UploadThread = new Thread(job);
			UploadThread.Name = "SyncThread";			
			UploadThread.Start();
		}

		private void doAddons()
		{
			statusBarPanel1.Text = _UPDWOWADDON;
			addonSyncBtn.Enabled = false;
			autoAddonSyncNow.Enabled = false;
			UpdateAddons();
			if (chAllowDelAddons.Checked)
			{
				deleteSpecifiedAddons();
			}
			DebugLine(_ADDONSUPD);
			addonSyncBtn.Enabled = true;
			autoAddonSyncNow.Enabled = true;
			statusBarPanel1.Text = _READY;
		}


		private void treeView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				//if (e.Node.Parent != null)
				//{
				//	treeView1.SelectedNode = e.Node.Parent;
				//	e.Cancel = true;
				//}

				TreeNode t = treeView1.GetNodeAt (e.X ,e.Y );
				
				if (t.Parent != null)
				{
					treeView1.SelectedNode = t.Parent;
				}
				else
				{
					treeView1.SelectedNode = t;
				}

				//treeView1.SelectedNode = treeView1.GetNodeAt (e.X ,e.Y );
				Point clickPoint = new Point( e.X,e.Y );
				TreeNode clickNode = treeView1.GetNodeAt( clickPoint );
				if ( clickNode == null ) return;

				// Convert from Tree coordinates to Screen coordinates
				Point screenPoint = treeView1.PointToScreen( clickPoint );

				// Convert from Screen coordinates to Form coordinates
				Point formPoint = PointToClient( screenPoint );

				// Show context menu

				if (autoAddonSyncNow.Enabled)
				{
					contextMenu2.Show( this, formPoint );
				}
				//MessageBox.Show("asdf");

			} 



		}

		private void populateContextMenu2()
		{
			contextMenu2 = new ContextMenu();
			contextMenu2.MenuItems.Clear();
			//contextMenu2.MenuItems.Add(_DOWNLOADIT);

			downloadItem = new MenuItem(_DOWNLOADIT);
			installItem = new MenuItem(_INSTALL);

			downloadItem.Click += new System.EventHandler(this.downloadItem_Click);
			installItem.Click += new System.EventHandler(this.installItem_Click);


			contextMenu2.MenuItems.Add(downloadItem);
			contextMenu2.MenuItems.Add(installItem);

				this.UploadNow.Click += new System.EventHandler(this.button1_Click);


		}

		private void addHomeLink()
		{
			if (contextMenu1.MenuItems.IndexOf(homeLink) < 0)
			{
				homeLink.Click += new System.EventHandler(this.homeLink_Click);
				contextMenu1.MenuItems.Add(homeLink);
			}
		}
		private void homeLink_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start(homeLinkURL);
		}
		private void addForumLink()
		{
			
			if (contextMenu1.MenuItems.IndexOf(forumLink) < 0)
			{
				forumLink.Click += new System.EventHandler(this.forumLink_Click);
				contextMenu1.MenuItems.Add(forumLink);
			}
		}
		private void forumLink_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start(forumLinkURL);
		}
		private void downloadItem_Click(object sender, System.EventArgs e)
		{
			TreeNode t = treeView1.SelectedNode;
			if (t.Parent != null)
				treeView1.SelectedNode = t.Parent;
			else
				treeView1.SelectedNode = t;
			t = treeView1.SelectedNode;

			singleUpdateTmp = t.Text;

			job = new ThreadStart(downloadAddonNow);
			UploadThread = new Thread(job);
			UploadThread.Name = "SyncThread";			
			UploadThread.Start();
		}

		private void installItem_Click(object sender, System.EventArgs e)
		{
			TreeNode t = treeView1.SelectedNode;
			if (t.Parent != null)
				treeView1.SelectedNode = t.Parent;
			else
				treeView1.SelectedNode = t;
			t = treeView1.SelectedNode;

			singleUpdateTmp = t.Text;

			job = new ThreadStart(updateAddon);
			UploadThread = new Thread(job);
			UploadThread.Name = "SyncThread";			
			UploadThread.Start();

		}

		private void updateAddon()
		{
			addonSyncBtn.Enabled = false;
			autoAddonSyncNow.Enabled = false;

			string status = _NOWUPD+" [ 1 / 1 ]  "+singleUpdateTmp;
			DebugLine("                                               ");
			DebugLine(status);
			statusBarPanel1.Text = status;

			ArrayList a = new ArrayList();
			a.Add("Interface/AddOns");
			progressBar1.Value = 0;
			UpdateSingleAddon(singleUpdateTmp, AutoAddonURL.Text,a);


			addonSyncBtn.Enabled = true;
			autoAddonSyncNow.Enabled = true;
			statusBarPanel1.Text = _READY;
		}

		private void downloadAddonNow()
		{

			string AddonRetrievalResponse;
			string value2 = valu2.Text;
			string URL = AutoAddonURL.Text;
			if (sendPwSecurely.Checked)
			{
				value2 = MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text));
			}

			if (arg1check.Checked)
			{
				AddonRetrievalResponse = RetrData(URL,null,null,"OPERATION","GETADDON","ADDON",singleUpdateTmp,arrg1.Text,valu1.Text,-1,arrg2.Text,value2);
			}
			else
			{
				AddonRetrievalResponse = RetrData(URL,null,null,"OPERATION","GETADDON","ADDON",singleUpdateTmp,null,null,-1,null,null);
			}

			string filename = GetfileNameFromURI(AddonRetrievalResponse);


			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Zip file|*.zip";
			saveFileDialog1.FileName = filename;
			//saveFileDialog1.Title = _SAVLOG;
			DialogResult ok = saveFileDialog1.ShowDialog(); 
			if(ok == DialogResult.OK || ok == DialogResult.Yes)
			{

				string status = _DOWNLOADING+" [ 1 / 1 ]  "+singleUpdateTmp;
				DebugLine("                                               ");
				DebugLine(status);
				statusBarPanel1.Text = status;
				progressBar1.Value = 0;
				download(AddonRetrievalResponse,saveFileDialog1.FileName);
				statusBarPanel1.Text = _READY;
			}

		}

		private void aceGrpbox_VisibleChanged(object sender, System.EventArgs e)
		{
			//MemoryStream memStream = aceXMLdownload("http://files.wowace.com/latest.xml");

			;

			acejob = new ThreadStart(aceUpdateList);
			aceUploadThread = new Thread(acejob);
			aceUploadThread.Name = "aceThread";		
			aceUploadThread.Start();

			//aceUpdateList();
		
		}
		public void aceUpdateList()
		{
			string xml = "";
			MemoryStream memStream = aceDownload("http://files.wowace.com/latest.xml");
			memStream.Position = 0;
			xml = Encoding.UTF8.GetString(memStream.ToArray());
			XmlDocument x = new XmlDocument();
			x.InnerXml = xml;
			foreach(XmlNode node in x)
			{
				if (node.Name == "rss")
				{
					foreach(XmlNode channel in node)
					{
						foreach(XmlNode item in channel)
						{
							if (item.Name == "item")
							{
								foreach(XmlNode itemInfo in item)
								{
									MessageBox.Show(itemInfo.Name);

								}
							}
						}
					}
				}

			}

		}

		public string getStringFromStream(MemoryStream stream)
		{
			using (StreamReader reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}
		public string getStringFromStream2(MemoryStream stream)
		{
			string a = "";
			for (int i = 0;i<stream.Length;i++)
			{
				//a += asc(stream.ReadByte());
			}
			return a;
		}

		

//ace
		private MemoryStream aceDownload(string path_download)
		{
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
			//FileStream lFileStream = new FileStream(path_local, FileMode.Create);
			// Declare a variable of type Byte Array named byteBuffer.
			byte[] byteBuffer = new byte[999];
			// Declare a variable of type Integer named bytesRead.
			int bytesRead;
			MemoryStream memStream = new MemoryStream();
			try
			{
				// Instantiate the HttpWebRequest object.
				lHttpWebRequest = (HttpWebRequest)WebRequest.Create(path_download);
				// Instantiate the HttpWebRespose object.
				lHttpWebResponse = (HttpWebResponse)lHttpWebRequest.GetResponse();
				// Instantiate the ResponseStream object.
				lHttpWebResponseStream = lHttpWebRequest.GetResponse().GetResponseStream();
				// Set the ProgressBars Maximum property equal to the length of the file
				// to be downloaded.
				aceProgress.Maximum = Convert.ToInt32(lHttpWebResponse.ContentLength);
				// progress counter to control when
				// the form label is updated
				memStream.SetLength(lHttpWebResponse.ContentLength);
				double progress_counter = 0;
				do
				{
					// Read up to 1000 bytes into the bytesRead array.
					bytesRead = lHttpWebResponseStream.Read(byteBuffer, 0, 999);
					// Write the bytes read to the file stream.
					//lFileStream.Write(byteBuffer, 0, bytesRead);
					memStream.Write(byteBuffer, 0, bytesRead);

					// If the ProgressBar's value plus bytesRead is less than the length of the file...
					if((aceProgress.Value + bytesRead) <= aceProgress.Maximum)
					{
						// Add bytesRead to the ProgressBar's Value property.
						aceProgress.Value += bytesRead;
					}
					else
					{
						// Else files download is done so set ProgressBar's Value to the length of the file.
						aceProgress.Value = aceProgress.Maximum;
					}
					// calculate the current percentage
					//double progress_now = Math.Floor(((aceProgress.Value/100) * 100) / (aceProgress.Maximum/100));
					double progress_now = Math.Floor(((double)(aceProgress.Value/100) * 100) / (aceProgress.Maximum/100));
					// only upgrade the display label once per percentage increment
					if(progress_now > progress_counter)
					{
						// Update the ProgressLabel.
						//statusBarPanel2.Text = String.Format("{0}% "+_OF+" {1}kb", progress_now.ToString(), (aceProgress.Maximum/1000).ToString("#,#"));
						// update the form
						Application.DoEvents(); 
						// increment the counter
						progress_counter++;
					}
				}while(bytesRead > 0);
				// Close the file and web response streams.
				lHttpWebResponseStream.Close();
				// Set result to True - download was successful.
			}
			catch(Exception download_error)
			{
				// display the whole error
				DebugLine(download_error.ToString());
			}
			finally
			{
				// Close the file and web response streams.
				//lFileStream.Close();
			}
			return memStream;
		}




	}

}
