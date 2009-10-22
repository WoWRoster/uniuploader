// ----------------------------------------------
/*
 * @version    SVN: $Id: MainForm.cs 1983 2009-05-17 22:01:05Z Calystos $
 * @link       http://www.wowroster.net
*/
// ----------------------------------------------

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

// ----------------------------------------------

namespace WindowsApplication3
{
	///	<summary>
	///	uploader for "World of Warcraft" SavedVariables.lua files and screenshots
	///	</summary>
	///
	public class MainForm : UniUploader.GUI_helper
	{
/*
		// Enable this if you do NOT want the X button to be used at all, it force disables it
		private const int CP_NOCLOSE_BUTTON = 0x200;
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams myCp = base.CreateParams;
				myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON ;
				return myCp;
			}
		}
*/

		private System.Windows.Forms.TextBox URL;
		private System.Windows.Forms.Label URLLbl;
		private System.Windows.Forms.Button UploadNowBtn;
		private System.Windows.Forms.Label AccountSelectLbl;
		private System.Windows.Forms.Label UULbl;
		private System.Windows.Forms.Label version;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.CheckBox autoUploader;
		private System.Windows.Forms.Label CreatedLbl;
		private System.Windows.Forms.Label UpdByLbl;
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
		private System.Windows.Forms.Button SettingsBtn;
		private System.Windows.Forms.Button OptionsBtn;
		private System.Windows.Forms.Button InfoBtn;
		private System.Windows.Forms.Button AdvancedBtn;
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
		private System.Windows.Forms.Label WebDataLbl;
		private System.Windows.Forms.Label FURfWLbl;
		private System.Windows.Forms.CheckBox GZcompress;
		private System.Windows.Forms.CheckBox retrdatafromsite;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Button wowlaunch;
		private System.Windows.Forms.TextBox retrdatawindow;
		FileSystemWatcher watcher = new FileSystemWatcher();
		public bool IsUploading = false;
		public string windowstate = "starting";
		private System.Windows.Forms.Timer mini_timer;
		private System.Windows.Forms.Timer Upload_Timer;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.CheckBox delaych;
		private System.Windows.Forms.Label SecondsLbl;
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
		private System.Windows.Forms.Label SynchURLLbl;
		private System.Windows.Forms.Button autoAddonSyncNow;
		private System.Windows.Forms.Label UpdURLLbl;
		private System.Windows.Forms.TextBox UpdatesURL;
		private System.Windows.Forms.Label WarnMsgLbl;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.CheckBox uuSettingsUpdater;
		private System.Windows.Forms.CheckBox UUUpdaterCheck;
		private System.Windows.Forms.CheckBox UUAutoUpdaterCheck;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TabPage Debugger;
		private System.Windows.Forms.ListBox DebugBox;
		private System.Windows.Forms.Button debugSaveAs;
		private System.Windows.Forms.Button button5;
		IniStructure ini = new cs_IniHandlerDevelop.IniStructure();
		IniStructure LanguageIni = new cs_IniHandlerDevelop.IniStructure();
		private bool updating = false;
		private string uniVersionMajor = "2";
		private string uniVersionMinor = "7";
		private string uniVersionBuild = "0";
		private string uniVersionRevision = "0";
		private bool TEST_VERSION = false;
		private string UUuserAgent;
		private string selectedAcc = "";
		private ArrayList allLangs = new ArrayList();
		private string wowExeLoc = "";
		private string wowExeLocBrowsed = "";
		private System.Windows.Forms.MenuItem downloadItem;
		//this.UploadNowBtn.Click += new System.EventHandler(this.UploadNowBtn_Click);
		private System.Windows.Forms.MenuItem installItem;
		private string mainSvLocation = ""; //location of SavedVariables.lua
		private string tmpmainSvLocation = ""; //location of SavedVariables.lua (used by ALL Accounts uploader)
		private System.Windows.Forms.Button Mode;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.ComboBox langselect;
		public string Language = "English";
		public string ProgramMode = "Advanced";
		private UniUploader.http http = new UniUploader.http();
		public ThreadStart job;// = new ThreadStart(upload);
		public Thread UploadThread;// = new Thread(job);
		public bool PathFound = false;
		private string[] checkedSVsFromSettings = null;
		private ArrayList checkedAddons = new ArrayList();
		private ArrayList availableAddons = new ArrayList();
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.CheckBox stmin;
		private System.Windows.Forms.CheckBox stboot;
		private System.Windows.Forms.CheckBox CloseToSysTray;
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
		private string _MINLBL = "Min.";
		private string _ASILBL = "Auto-Sync Interval (0=disable)";
		private string _CRTDBY = "Created By:";
		private string _UPTDBY = "Updated By:";
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
		private string _ADDONS = "Addons";
		private string _SVBLS = "Saved Variables";
		private string _ARRGS = "Args:";
		private string _CLEARTHESVS = "Clear SV Contents";
		private string _SHOWSVSBUT = "Show SVs";
		private string _HIDESVSBUT = "Hide SVs";
		private string _SHOWADDONSBUT = "Show Addons";
		private string _HIDEADDONSBUT = "Hide Addons";
		private string _AUTODETECTWOWCH = "auto-detect WoW";
		private string _FINDWOWEXEBUT = "Find WoW.exe";
		private string _UPALLACC = "Upload ALL Accounts";
		private string _UPSCRSHT = "Upload Screenshots";
		private string _UPSVS = "Upload SVs";
		private string _SENDPWSECURELE = "Send Password Securely";
		private string _STOREPWSECURE = "Store Password Securely";
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
		public string _HELP4 = @"If you need help setting up or troubleshooting UniUploader, or would like to make suggestions for UniUploader, requests for features, bug reports, or just chat, please visit http://wowroster.net or email me at mattm@wowroster.net (or Calystos at calystos@virgin.net)
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
		public string _UPDADDONSST = "UpdateAddons Debugging process started";
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
		public string _UPERRPU = "Upload Error Popup";
		public string _CLAFUP = "Close After Updates";
		public string _CLAFWL = "Close After WoW Launch";
		public string _SYSTICO = "SysTray Icon";
		public string _USERAGENT = "User Agent:";
		public string _ADDVARS = "Additional Variables";
		public string _ADDURLS = "Additional URL's";
		public string _UPDATER = "Updater";
		public string _AUTOUPD = "Auto-Updater";
		public string _KMAU = "Keep my addons updated";
		public string _KMCUSU = "Keep My critical UniUploader settings updated";
		public string _CFUTU = "Check for updates to UniUploader";
		public string _AUTLU = "Automatically update to latest UniUploader";
		public string _SYNCHURL = "Synchronization URL:";
		public string _UPDATESURL = "Updates URL:";
		public string _SAPU = "Same as Primary URL";
		public string _SYNCHNOW = "Synchronize";
		public string _UPDCHK = "Update Check";
		public string _WARN = "WARNING:";
		public string _WARNMSG = "This will ONLY synchronize the Addons on your computer with the same ones on the website.  DO NOT try to synchronize addons while WoW is running.";
		public string _DEBUGGER = "Debugger";
		public string _CLEARDB = "Clear";
		public string _SAVEASDB = "Save As...";
		public string _ADVANCED = "Advanced";
		public string _ADVANCEDSETTINGS = "Advanced Settings";
		public string _EFF = "Efficiency";
		public string _GZIPLAB = "GZip Compression";
		public string _USEAPPDATA = "Use %APPDATA%";
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
		public string _CSIST = "Close to SysTray";
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
		private string _WARNINGWILLCLEAR = "This will Remove/Clear all contents of the selected Files!" + "\n" + "\n" + "Proceed?";
		private string _WARNING = "Warning";
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button dbNPbtn;
		private System.Windows.Forms.Button dbIEbtn;
		private System.Windows.Forms.Label DebugInfoLbl;
		private System.Windows.Forms.Label langLabel;
		private System.Windows.Forms.GroupBox configGroup;
		private string _LOGINONCE = "You must log into World of Warcraft at least once more before running this program. please quit UniUploader and try again after you have logged into WoW";
		#endregion
		private System.Windows.Forms.Timer filesysDelay;
		private System.Windows.Forms.CheckBox sendPwSecurely;
		private System.Windows.Forms.CheckBox storePwSecurely;
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
		private System.Windows.Forms.Label AddonsListLbl;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.CheckBox OpenGl;
		private System.Windows.Forms.CheckBox windowmode;
		private System.Windows.Forms.TextBox launchWoWargs;
		private System.Windows.Forms.Label ArgsLbl;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.CheckBox chAllowDelAddons;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.Label AddonDescLbl;
		private System.Windows.Forms.Label AddonTOCLbl;
		private System.Windows.Forms.Label AddonVerLbl;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.Label AddonNameLbl;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.LinkLabel linkLabel4;
		private System.Windows.Forms.LinkLabel linkLabel5;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button addonSyncBtn;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.CheckBox purgefirstCh;
		private CheckBox cbAppData;
		private CheckBox cbCloseAfterUpdates;
		private Label ASILbl;
		private NumericUpDown nudAutoSyncInterval;
		private Label MinLbl;
		private CheckBox cbUpErrorPop;
		private CheckBox cbCloseAfterWowLaunch;
		private Button btnSysTrayIco;
		private CheckBox UploadALLAccounts;
		private CheckBox cbInclScreenShots;
		private CheckBox cbInclAddonData;
		private LinkLabel linkLabel3;
		private CheckBox stwowlaunch;
		private Button updateCheckBtn;
		private string GuildName = "";  // Set this to "" if you do not wish to customize for a guild build
		private bool EnableOfficerBuild = false;  // Set this to true if you wish to use a separate UU for Officer/Leader use only
		private bool IsOfficerBuild = false;  // Set this to true to make sure this is a Officer/Leader only build
		private string OfficerStr = "";  // Set this to "" if you do not wish to customize for a guild Officer build
		private string MemberUUVal = "";  // The default Guild Member access password for the roster
		private string OfficerUUVal = "";  // The default Guild Officer access password for the roster
		private int UUTimeOut = 20000;  // Default setting for UniUploader timeout (Used by doLogos, CheckForUpdates, checkLangFile functions)
		private int autoLaunchTimer = 30;  // Not used by UU, but is used by UU's Update.exe. Put here to make sure UU doesn't wipe the setting.
		FileSystemWatcher newWatcher = new FileSystemWatcher();

// ----------------------------------------------

		public MainForm()
		{
			//
			// Required	for	Windows	Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after	InitializeComponent	call
			//
		}

// ----------------------------------------------

		///	<summary>
		///	Clean up any resources being used.
		///	</summary>
		protected override void Dispose(bool disposing)
		{
			//WriteSettings();
			try
			{
				close_timer.Start();
			}
			catch (Exception ex)
			{
				this.DebugLine(ex.Message);
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

// ----------------------------------------------

		///	<summary>
		///	Required method	for	Designer support - do not modify
		///	the	contents of	this method	with the code editor.
		///	</summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.myTimer = new System.Timers.Timer();
            this.myTimer2 = new System.Timers.Timer();
            this.URL = new System.Windows.Forms.TextBox();
            this.URLLbl = new System.Windows.Forms.Label();
            this.UploadNowBtn = new System.Windows.Forms.Button();
            this.AccountSelectLbl = new System.Windows.Forms.Label();
            this.AccountList = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.autoUploader = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.version = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.libLink = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.CreatedLbl = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.UULbl = new System.Windows.Forms.Label();
            this.UpdByLbl = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
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
            this.UploadALLAccounts = new System.Windows.Forms.CheckBox();
            this.cbInclScreenShots = new System.Windows.Forms.CheckBox();
            this.cbInclAddonData = new System.Windows.Forms.CheckBox();
            this.langselect = new System.Windows.Forms.ComboBox();
            this.AutoInstallDirDetect = new System.Windows.Forms.CheckBox();
            this.langLabel = new System.Windows.Forms.Label();
            this.addonAutoUpdate = new System.Windows.Forms.CheckBox();
            this.findInstallBtn = new System.Windows.Forms.Button();
            this.togSVList = new System.Windows.Forms.Button();
            this.Mode = new System.Windows.Forms.Button();
            this.wowlaunch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.cbAppData = new System.Windows.Forms.CheckBox();
            this.GZcompress = new System.Windows.Forms.CheckBox();
            this.SecondsLbl = new System.Windows.Forms.Label();
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
            this.ArgsLbl = new System.Windows.Forms.Label();
            this.wowAddons = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.updateCheckBtn = new System.Windows.Forms.Button();
            this.MinLbl = new System.Windows.Forms.Label();
            this.ASILbl = new System.Windows.Forms.Label();
            this.nudAutoSyncInterval = new System.Windows.Forms.NumericUpDown();
            this.chAllowDelAddons = new System.Windows.Forms.CheckBox();
            this.UUAutoUpdaterCheck = new System.Windows.Forms.CheckBox();
            this.UUUpdaterCheck = new System.Windows.Forms.CheckBox();
            this.uuSettingsUpdater = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.WarnMsgLbl = new System.Windows.Forms.Label();
            this.autoAddonSyncNow = new System.Windows.Forms.Button();
            this.SynchURLLbl = new System.Windows.Forms.Label();
            this.AutoAddonURL = new System.Windows.Forms.TextBox();
            this.UpdURLLbl = new System.Windows.Forms.Label();
            this.UpdatesURL = new System.Windows.Forms.TextBox();
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
            this.storePwSecurely = new System.Windows.Forms.CheckBox();
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
            this.CloseToSysTray = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSysTrayIco = new System.Windows.Forms.Button();
            this.cbCloseAfterWowLaunch = new System.Windows.Forms.CheckBox();
            this.cbUpErrorPop = new System.Windows.Forms.CheckBox();
            this.cbCloseAfterUpdates = new System.Windows.Forms.CheckBox();
            this.userAlbl = new System.Windows.Forms.Label();
            this.userAgent = new System.Windows.Forms.TextBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
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
            this.FURfWLbl = new System.Windows.Forms.Label();
            this.WebDataLbl = new System.Windows.Forms.Label();
            this.servResponse = new System.Windows.Forms.TextBox();
            this.Debugger = new System.Windows.Forms.TabPage();
            this.DebugInfoLbl = new System.Windows.Forms.Label();
            this.dbIEbtn = new System.Windows.Forms.Button();
            this.dbNPbtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.debugSaveAs = new System.Windows.Forms.Button();
            this.DebugBox = new System.Windows.Forms.ListBox();
            this.Help = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.AdvancedBtn = new System.Windows.Forms.Button();
            this.InfoBtn = new System.Windows.Forms.Button();
            this.OptionsBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.About = new System.Windows.Forms.TabPage();
            this.copyrightInfoLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
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
            this.AddonNameLbl = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.AddonVerLbl = new System.Windows.Forms.Label();
            this.AddonTOCLbl = new System.Windows.Forms.Label();
            this.AddonDescLbl = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.AddonsListLbl = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            ((System.ComponentModel.ISupportInitialize)(this.myTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTimer2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Settings.SuspendLayout();
            this.configGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Advanced.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.otherexes.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.wowAddons.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoSyncInterval)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.Options.SuspendLayout();
            this.vargrp.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.response.SuspendLayout();
            this.Debugger.SuspendLayout();
            this.Help.SuspendLayout();
            this.About.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            this.URL.Location = new System.Drawing.Point(6, 41);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(238, 20);
            this.URL.TabIndex = 8;
            this.URL.Text = "http://yourdomain.com/yourinterface.php";
            // 
            // URLLbl
            // 
            this.URLLbl.Location = new System.Drawing.Point(3, 19);
            this.URLLbl.Margin = new System.Windows.Forms.Padding(3);
            this.URLLbl.Name = "URLLbl";
            this.URLLbl.Size = new System.Drawing.Size(214, 16);
            this.URLLbl.TabIndex = 9;
            this.URLLbl.Text = "URL: (interface file on the web)";
            // 
            // UploadNowBtn
            // 
            this.UploadNowBtn.Location = new System.Drawing.Point(398, 201);
            this.UploadNowBtn.Name = "UploadNowBtn";
            this.UploadNowBtn.Size = new System.Drawing.Size(80, 24);
            this.UploadNowBtn.TabIndex = 10;
            this.UploadNowBtn.Text = "Upload";
            this.UploadNowBtn.Click += new System.EventHandler(this.UploadNowBtn_Click);
            // 
            // AccountSelectLbl
            // 
            this.AccountSelectLbl.BackColor = System.Drawing.Color.Transparent;
            this.AccountSelectLbl.Location = new System.Drawing.Point(3, 67);
            this.AccountSelectLbl.Margin = new System.Windows.Forms.Padding(3);
            this.AccountSelectLbl.Name = "AccountSelectLbl";
            this.AccountSelectLbl.Size = new System.Drawing.Size(216, 16);
            this.AccountSelectLbl.TabIndex = 12;
            this.AccountSelectLbl.Text = "Select WOW Account:";
            // 
            // AccountList
            // 
            this.AccountList.Cursor = System.Windows.Forms.Cursors.Default;
            this.AccountList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountList.Location = new System.Drawing.Point(6, 84);
            this.AccountList.Name = "AccountList";
            this.AccountList.Size = new System.Drawing.Size(106, 21);
            this.AccountList.Sorted = true;
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
            this.autoUploader.Text = "Auto-Upload";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.version);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.libLink);
            this.groupBox2.Controls.Add(this.linkLabel3);
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Controls.Add(this.CreatedLbl);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.UULbl);
            this.groupBox2.Controls.Add(this.UpdByLbl);
            this.groupBox2.Controls.Add(this.linkLabel4);
            this.groupBox2.Controls.Add(this.linkLabel5);
            this.groupBox2.Controls.Add(this.btnTranslations);
            this.groupBox2.Controls.Add(this.btnLegal);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 200);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "About";
            // 
            // version
            // 
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.ForeColor = System.Drawing.Color.Red;
            this.version.Location = new System.Drawing.Point(72, 16);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(92, 16);
            this.version.TabIndex = 17;
            this.version.Text = "2.7.0.0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(136, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 176);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // libLink
            // 
            this.libLink.LinkColor = System.Drawing.Color.Blue;
            this.libLink.Location = new System.Drawing.Point(8, 117);
            this.libLink.Name = "libLink";
            this.libLink.Size = new System.Drawing.Size(120, 16);
            this.libLink.TabIndex = 20;
            this.libLink.TabStop = true;
            this.libLink.Text = "http://WoWRoster.net";
            this.libLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.libLink_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel3.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel3.Location = new System.Drawing.Point(8, 64);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(131, 16);
            this.linkLabel3.TabIndex = 23;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "http://MatthewMiller.info";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(77, 32);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(56, 16);
            this.linkLabel2.TabIndex = 22;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Matt Miller";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // CreatedLbl
            // 
            this.CreatedLbl.ForeColor = System.Drawing.Color.Blue;
            this.CreatedLbl.Location = new System.Drawing.Point(8, 32);
            this.CreatedLbl.Name = "CreatedLbl";
            this.CreatedLbl.Size = new System.Drawing.Size(72, 16);
            this.CreatedLbl.TabIndex = 18;
            this.CreatedLbl.Text = "Created By:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.Location = new System.Drawing.Point(8, 48);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(131, 16);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Matt@MatthewMiller.info";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // UULbl
            // 
            this.UULbl.Location = new System.Drawing.Point(8, 16);
            this.UULbl.Name = "UULbl";
            this.UULbl.Size = new System.Drawing.Size(72, 16);
            this.UULbl.TabIndex = 16;
            this.UULbl.Text = "UniUploader";
            // 
            // UpdByLbl
            // 
            this.UpdByLbl.ForeColor = System.Drawing.Color.Blue;
            this.UpdByLbl.Location = new System.Drawing.Point(8, 84);
            this.UpdByLbl.Name = "UpdByLbl";
            this.UpdByLbl.Size = new System.Drawing.Size(72, 16);
            this.UpdByLbl.TabIndex = 18;
            this.UpdByLbl.Text = "Updated By:";
            // 
            // linkLabel4
            // 
            this.linkLabel4.Location = new System.Drawing.Point(77, 84);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(56, 16);
            this.linkLabel4.TabIndex = 22;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Calystos";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel5.Location = new System.Drawing.Point(8, 100);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(131, 16);
            this.linkLabel5.TabIndex = 19;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Calystos@virgin.net";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
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
            this.btnLegal.Size = new System.Drawing.Size(75, 23);
            this.btnLegal.TabIndex = 21;
            this.btnLegal.Text = "License";
            this.btnLegal.Click += new System.EventHandler(this.btnLegal_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenu = this.contextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "UniUploader";
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
            this.tabControl1.Controls.Add(this.Options);
            this.tabControl1.Controls.Add(this.response);
            this.tabControl1.Controls.Add(this.Debugger);
            this.tabControl1.Controls.Add(this.Help);
            this.tabControl1.Controls.Add(this.About);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 256);
            this.tabControl1.TabIndex = 18;
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.showAddonsBtn);
            this.Settings.Controls.Add(this.configGroup);
            this.Settings.Controls.Add(this.togSVList);
            this.Settings.Controls.Add(this.Mode);
            this.Settings.Controls.Add(this.wowlaunch);
            this.Settings.Controls.Add(this.UploadNowBtn);
            this.Settings.Controls.Add(this.pictureBox1);
            this.Settings.Location = new System.Drawing.Point(4, 22);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(488, 230);
            this.Settings.TabIndex = 0;
            this.Settings.Text = "Settings";
            // 
            // showAddonsBtn
            // 
            this.showAddonsBtn.Enabled = false;
            this.showAddonsBtn.Location = new System.Drawing.Point(188, 201);
            this.showAddonsBtn.Name = "showAddonsBtn";
            this.showAddonsBtn.Size = new System.Drawing.Size(88, 23);
            this.showAddonsBtn.TabIndex = 36;
            this.showAddonsBtn.Text = "Show Addons";
            this.showAddonsBtn.Click += new System.EventHandler(this.showAddonsBtn_Click);
            // 
            // configGroup
            // 
            this.configGroup.Controls.Add(this.UploadALLAccounts);
            this.configGroup.Controls.Add(this.cbInclScreenShots);
            this.configGroup.Controls.Add(this.cbInclAddonData);
            this.configGroup.Controls.Add(this.langselect);
            this.configGroup.Controls.Add(this.AccountList);
            this.configGroup.Controls.Add(this.AutoInstallDirDetect);
            this.configGroup.Controls.Add(this.URLLbl);
            this.configGroup.Controls.Add(this.langLabel);
            this.configGroup.Controls.Add(this.URL);
            this.configGroup.Controls.Add(this.addonAutoUpdate);
            this.configGroup.Controls.Add(this.findInstallBtn);
            this.configGroup.Controls.Add(this.AccountSelectLbl);
            this.configGroup.Location = new System.Drawing.Point(8, 8);
            this.configGroup.Name = "configGroup";
            this.configGroup.Size = new System.Drawing.Size(250, 187);
            this.configGroup.TabIndex = 35;
            this.configGroup.TabStop = false;
            this.configGroup.Text = "Config";
            // 
            // UploadALLAccounts
            // 
            this.UploadALLAccounts.AutoSize = true;
            this.UploadALLAccounts.Checked = true;
            this.UploadALLAccounts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UploadALLAccounts.Location = new System.Drawing.Point(6, 116);
            this.UploadALLAccounts.Name = "UploadALLAccounts";
            this.UploadALLAccounts.Size = new System.Drawing.Size(130, 17);
            this.UploadALLAccounts.TabIndex = 37;
            this.UploadALLAccounts.Text = "Upload ALL Accounts";
            this.UploadALLAccounts.UseVisualStyleBackColor = true;
            this.UploadALLAccounts.CheckedChanged += new System.EventHandler(this.UploadALLAccounts_CheckedChanged);
            // 
            // cbInclScreenShots
            // 
            this.cbInclScreenShots.AutoSize = true;
            this.cbInclScreenShots.Location = new System.Drawing.Point(6, 139);
            this.cbInclScreenShots.Name = "cbInclScreenShots";
            this.cbInclScreenShots.Size = new System.Drawing.Size(122, 17);
            this.cbInclScreenShots.TabIndex = 37;
            this.cbInclScreenShots.Text = "Upload Screenshots";
            this.cbInclScreenShots.UseVisualStyleBackColor = true;
            // 
            // cbInclAddonData
            // 
            this.cbInclAddonData.AutoSize = true;
            this.cbInclAddonData.Checked = true;
            this.cbInclAddonData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInclAddonData.Location = new System.Drawing.Point(162, 162);
            this.cbInclAddonData.Name = "cbInclAddonData";
            this.cbInclAddonData.Size = new System.Drawing.Size(82, 17);
            this.cbInclAddonData.TabIndex = 38;
            this.cbInclAddonData.Text = "Upload SVs";
            this.cbInclAddonData.UseVisualStyleBackColor = true;
            // 
            // langselect
            // 
            this.langselect.Cursor = System.Windows.Forms.Cursors.Default;
            this.langselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langselect.Items.AddRange(new object[] {
            "Chinese_Simplified",
            "Deutsch",
            "English",
            "French",
            "Nederlands",
            "Russian",
            "Svenska"});
            this.langselect.Location = new System.Drawing.Point(140, 84);
            this.langselect.Name = "langselect";
            this.langselect.Size = new System.Drawing.Size(104, 21);
            this.langselect.Sorted = true;
            this.langselect.TabIndex = 30;
            this.langselect.SelectedIndexChanged += new System.EventHandler(this.langselect_SelectedIndexChanged);
            // 
            // AutoInstallDirDetect
            // 
            this.AutoInstallDirDetect.AutoSize = true;
            this.AutoInstallDirDetect.Checked = true;
            this.AutoInstallDirDetect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoInstallDirDetect.Location = new System.Drawing.Point(134, 139);
            this.AutoInstallDirDetect.Name = "AutoInstallDirDetect";
            this.AutoInstallDirDetect.Size = new System.Drawing.Size(114, 17);
            this.AutoInstallDirDetect.TabIndex = 35;
            this.AutoInstallDirDetect.Text = "Auto-Detect WoW";
            this.AutoInstallDirDetect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoInstallDirDetect.CheckedChanged += new System.EventHandler(this.AutoInstallDirDetect_CheckedChanged);
            // 
            // langLabel
            // 
            this.langLabel.Location = new System.Drawing.Point(137, 67);
            this.langLabel.Margin = new System.Windows.Forms.Padding(3);
            this.langLabel.Name = "langLabel";
            this.langLabel.Size = new System.Drawing.Size(100, 16);
            this.langLabel.TabIndex = 34;
            this.langLabel.Text = "Language:";
            // 
            // addonAutoUpdate
            // 
            this.addonAutoUpdate.AutoSize = true;
            this.addonAutoUpdate.Location = new System.Drawing.Point(6, 162);
            this.addonAutoUpdate.Name = "addonAutoUpdate";
            this.addonAutoUpdate.Size = new System.Drawing.Size(134, 17);
            this.addonAutoUpdate.TabIndex = 0;
            this.addonAutoUpdate.Text = "Keep Addons Updated";
            this.addonAutoUpdate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.addonAutoUpdate.CheckedChanged += new System.EventHandler(this.addonAutoUpdate_CheckedChanged);
            // 
            // findInstallBtn
            // 
            this.findInstallBtn.Enabled = false;
            this.findInstallBtn.Location = new System.Drawing.Point(156, 110);
            this.findInstallBtn.Name = "findInstallBtn";
            this.findInstallBtn.Size = new System.Drawing.Size(88, 23);
            this.findInstallBtn.TabIndex = 36;
            this.findInstallBtn.Text = "Find WoW.exe";
            this.findInstallBtn.Click += new System.EventHandler(this.findInstallBtn_Click);
            // 
            // togSVList
            // 
            this.togSVList.Location = new System.Drawing.Point(118, 201);
            this.togSVList.Name = "togSVList";
            this.togSVList.Size = new System.Drawing.Size(64, 24);
            this.togSVList.TabIndex = 33;
            this.togSVList.Text = "Show SVs";
            this.togSVList.Click += new System.EventHandler(this.togSVList_Click);
            // 
            // Mode
            // 
            this.Mode.Location = new System.Drawing.Point(8, 201);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(104, 24);
            this.Mode.TabIndex = 28;
            this.Mode.Text = "Simple Mode";
            this.Mode.Click += new System.EventHandler(this.Mode_Click);
            // 
            // wowlaunch
            // 
            this.wowlaunch.Location = new System.Drawing.Point(304, 201);
            this.wowlaunch.Name = "wowlaunch";
            this.wowlaunch.Size = new System.Drawing.Size(88, 24);
            this.wowlaunch.TabIndex = 24;
            this.wowlaunch.Text = "Launch WoW";
            this.wowlaunch.Click += new System.EventHandler(this.wowlaunch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(264, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // Advanced
            // 
            this.Advanced.Controls.Add(this.groupBox5);
            this.Advanced.Location = new System.Drawing.Point(4, 22);
            this.Advanced.Name = "Advanced";
            this.Advanced.Size = new System.Drawing.Size(488, 230);
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
            this.groupBox6.Controls.Add(this.cbAppData);
            this.groupBox6.Controls.Add(this.GZcompress);
            this.groupBox6.Controls.Add(this.SecondsLbl);
            this.groupBox6.Controls.Add(this.DelaySecs);
            this.groupBox6.Controls.Add(this.delaych);
            this.groupBox6.Location = new System.Drawing.Point(216, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(136, 96);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Other Options";
            // 
            // cbAppData
            // 
            this.cbAppData.AutoSize = true;
            this.cbAppData.Location = new System.Drawing.Point(8, 73);
            this.cbAppData.Name = "cbAppData";
            this.cbAppData.Size = new System.Drawing.Size(114, 17);
            this.cbAppData.TabIndex = 3;
            this.cbAppData.Text = "Use %APPDATA%";
            this.cbAppData.UseVisualStyleBackColor = true;
            // 
            // GZcompress
            // 
            this.GZcompress.Checked = true;
            this.GZcompress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GZcompress.Location = new System.Drawing.Point(8, 56);
            this.GZcompress.Name = "GZcompress";
            this.GZcompress.Size = new System.Drawing.Size(120, 16);
            this.GZcompress.TabIndex = 2;
            this.GZcompress.Text = "GZip Compression";
            // 
            // SecondsLbl
            // 
            this.SecondsLbl.Location = new System.Drawing.Point(32, 35);
            this.SecondsLbl.Name = "SecondsLbl";
            this.SecondsLbl.Size = new System.Drawing.Size(96, 16);
            this.SecondsLbl.TabIndex = 1;
            this.SecondsLbl.Text = "Seconds:";
            // 
            // DelaySecs
            // 
            this.DelaySecs.Enabled = false;
            this.DelaySecs.Location = new System.Drawing.Point(8, 32);
            this.DelaySecs.Name = "DelaySecs";
            this.DelaySecs.Size = new System.Drawing.Size(24, 20);
            this.DelaySecs.TabIndex = 2;
            this.DelaySecs.Text = "5";
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
            this.purgefirstCh.Enabled = false;
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
            this.webWoWSvFile.Size = new System.Drawing.Size(100, 20);
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
            this.groupBox7.Controls.Add(this.ArgsLbl);
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
            // ArgsLbl
            // 
            this.ArgsLbl.Location = new System.Drawing.Point(8, 69);
            this.ArgsLbl.Name = "ArgsLbl";
            this.ArgsLbl.Size = new System.Drawing.Size(32, 16);
            this.ArgsLbl.TabIndex = 27;
            this.ArgsLbl.Text = "args:";
            // 
            // wowAddons
            // 
            this.wowAddons.Controls.Add(this.groupBox11);
            this.wowAddons.Location = new System.Drawing.Point(4, 22);
            this.wowAddons.Name = "wowAddons";
            this.wowAddons.Size = new System.Drawing.Size(488, 230);
            this.wowAddons.TabIndex = 6;
            this.wowAddons.Text = "Updater";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.updateCheckBtn);
            this.groupBox11.Controls.Add(this.MinLbl);
            this.groupBox11.Controls.Add(this.ASILbl);
            this.groupBox11.Controls.Add(this.nudAutoSyncInterval);
            this.groupBox11.Controls.Add(this.chAllowDelAddons);
            this.groupBox11.Controls.Add(this.UUAutoUpdaterCheck);
            this.groupBox11.Controls.Add(this.UUUpdaterCheck);
            this.groupBox11.Controls.Add(this.uuSettingsUpdater);
            this.groupBox11.Controls.Add(this.groupBox12);
            this.groupBox11.Controls.Add(this.autoAddonSyncNow);
            this.groupBox11.Controls.Add(this.SynchURLLbl);
            this.groupBox11.Controls.Add(this.AutoAddonURL);
            this.groupBox11.Controls.Add(this.UpdURLLbl);
            this.groupBox11.Controls.Add(this.UpdatesURL);
            this.groupBox11.Location = new System.Drawing.Point(8, 8);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(472, 216);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Auto-Updater";
            // 
            // updateCheckBtn
            // 
            this.updateCheckBtn.Location = new System.Drawing.Point(371, 100);
            this.updateCheckBtn.Name = "updateCheckBtn";
            this.updateCheckBtn.Size = new System.Drawing.Size(93, 23);
            this.updateCheckBtn.TabIndex = 14;
            this.updateCheckBtn.Text = "Update Check";
            this.updateCheckBtn.Click += new System.EventHandler(this.updateCheckBtn_Click);
            // 
            // MinLbl
            // 
            this.MinLbl.AutoSize = true;
            this.MinLbl.Location = new System.Drawing.Point(431, 35);
            this.MinLbl.Name = "MinLbl";
            this.MinLbl.Size = new System.Drawing.Size(27, 13);
            this.MinLbl.TabIndex = 13;
            this.MinLbl.Text = "Min.";
            // 
            // ASILbl
            // 
            this.ASILbl.AutoSize = true;
            this.ASILbl.Location = new System.Drawing.Point(310, 16);
            this.ASILbl.Name = "ASILbl";
            this.ASILbl.Size = new System.Drawing.Size(148, 13);
            this.ASILbl.TabIndex = 12;
            this.ASILbl.Text = "Auto-Sync Interval (0=disable)";
            // 
            // nudAutoSyncInterval
            // 
            this.nudAutoSyncInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudAutoSyncInterval.Location = new System.Drawing.Point(313, 33);
            this.nudAutoSyncInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAutoSyncInterval.Name = "nudAutoSyncInterval";
            this.nudAutoSyncInterval.Size = new System.Drawing.Size(111, 20);
            this.nudAutoSyncInterval.TabIndex = 11;
            this.nudAutoSyncInterval.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // chAllowDelAddons
            // 
            this.chAllowDelAddons.Location = new System.Drawing.Point(6, 18);
            this.chAllowDelAddons.Name = "chAllowDelAddons";
            this.chAllowDelAddons.Size = new System.Drawing.Size(448, 16);
            this.chAllowDelAddons.TabIndex = 10;
            this.chAllowDelAddons.Text = "Allow interface to DELETE addons";
            this.chAllowDelAddons.CheckedChanged += new System.EventHandler(this.chAllowDelAddons_CheckedChanged);
            // 
            // UUAutoUpdaterCheck
            // 
            this.UUAutoUpdaterCheck.Location = new System.Drawing.Point(6, 66);
            this.UUAutoUpdaterCheck.Name = "UUAutoUpdaterCheck";
            this.UUAutoUpdaterCheck.Size = new System.Drawing.Size(320, 16);
            this.UUAutoUpdaterCheck.TabIndex = 9;
            this.UUAutoUpdaterCheck.Text = "Automatically update to latest UniUploader";
            // 
            // UUUpdaterCheck
            // 
            this.UUUpdaterCheck.Checked = true;
            this.UUUpdaterCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UUUpdaterCheck.Location = new System.Drawing.Point(6, 50);
            this.UUUpdaterCheck.Name = "UUUpdaterCheck";
            this.UUUpdaterCheck.Size = new System.Drawing.Size(320, 16);
            this.UUUpdaterCheck.TabIndex = 9;
            this.UUUpdaterCheck.Text = "Check for updates to UniUploader";
            this.UUUpdaterCheck.CheckedChanged += new System.EventHandler(this.UUUpdaterCheck_CheckedChanged);
            // 
            // uuSettingsUpdater
            // 
            this.uuSettingsUpdater.Location = new System.Drawing.Point(6, 34);
            this.uuSettingsUpdater.Name = "uuSettingsUpdater";
            this.uuSettingsUpdater.Size = new System.Drawing.Size(344, 16);
            this.uuSettingsUpdater.TabIndex = 8;
            this.uuSettingsUpdater.Text = "Keep My critical UniUploader settings updated";
            this.uuSettingsUpdater.CheckedChanged += new System.EventHandler(this.uuSettingsUpdater_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.WarnMsgLbl);
            this.groupBox12.Location = new System.Drawing.Point(8, 158);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(456, 50);
            this.groupBox12.TabIndex = 7;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "WARNING:";
            // 
            // WarnMsgLbl
            // 
            this.WarnMsgLbl.ForeColor = System.Drawing.Color.Red;
            this.WarnMsgLbl.Location = new System.Drawing.Point(8, 16);
            this.WarnMsgLbl.Name = "WarnMsgLbl";
            this.WarnMsgLbl.Size = new System.Drawing.Size(440, 26);
            this.WarnMsgLbl.TabIndex = 6;
            this.WarnMsgLbl.Text = "This will ONLY synchronize the Addons on your computer with the same ones on the " +
                "website.  DO NOT try to synchronize addons while WoW is running.";
            // 
            // autoAddonSyncNow
            // 
            this.autoAddonSyncNow.Enabled = false;
            this.autoAddonSyncNow.Location = new System.Drawing.Point(378, 135);
            this.autoAddonSyncNow.Name = "autoAddonSyncNow";
            this.autoAddonSyncNow.Size = new System.Drawing.Size(80, 23);
            this.autoAddonSyncNow.TabIndex = 4;
            this.autoAddonSyncNow.Text = "Synchronize";
            this.autoAddonSyncNow.Click += new System.EventHandler(this.autoAddonSyncNow_Click);
            // 
            // SynchURLLbl
            // 
            this.SynchURLLbl.Enabled = false;
            this.SynchURLLbl.Location = new System.Drawing.Point(8, 122);
            this.SynchURLLbl.Name = "SynchURLLbl";
            this.SynchURLLbl.Size = new System.Drawing.Size(152, 16);
            this.SynchURLLbl.TabIndex = 3;
            this.SynchURLLbl.Text = "Synchronization URL:";
            // 
            // AutoAddonURL
            // 
            this.AutoAddonURL.Enabled = false;
            this.AutoAddonURL.Location = new System.Drawing.Point(8, 138);
            this.AutoAddonURL.Name = "AutoAddonURL";
            this.AutoAddonURL.Size = new System.Drawing.Size(280, 20);
            this.AutoAddonURL.TabIndex = 2;
            this.AutoAddonURL.Text = "http://yourdomain.com/uniadmin/interface.php";
            // 
            // UpdURLLbl
            // 
            this.UpdURLLbl.Location = new System.Drawing.Point(6, 83);
            this.UpdURLLbl.Name = "UpdURLLbl";
            this.UpdURLLbl.Size = new System.Drawing.Size(152, 16);
            this.UpdURLLbl.TabIndex = 3;
            this.UpdURLLbl.Text = "Updates URL:";
            // 
            // UpdatesURL
            // 
            this.UpdatesURL.Location = new System.Drawing.Point(8, 100);
            this.UpdatesURL.Name = "UpdatesURL";
            this.UpdatesURL.Size = new System.Drawing.Size(280, 20);
            this.UpdatesURL.TabIndex = 2;
            this.UpdatesURL.Text = "http://www.wowroster.net/uniuploader_updater2/update.php";
            // 
            // Options
            // 
            this.Options.Controls.Add(this.vargrp);
            this.Options.Controls.Add(this.groupBox4);
            this.Options.Controls.Add(this.groupBox9);
            this.Options.Controls.Add(this.groupBox1);
            this.Options.Location = new System.Drawing.Point(4, 22);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(488, 230);
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
            this.vargrp.Controls.Add(this.storePwSecurely);
            this.vargrp.Location = new System.Drawing.Point(8, 88);
            this.vargrp.Name = "vargrp";
            this.vargrp.Size = new System.Drawing.Size(184, 136);
            this.vargrp.TabIndex = 24;
            this.vargrp.TabStop = false;
            this.vargrp.Text = "Additional Variables";
            // 
            // valu4
            // 
            this.valu4.Enabled = false;
            this.valu4.Location = new System.Drawing.Point(64, 113);
            this.valu4.Name = "valu4";
            this.valu4.Size = new System.Drawing.Size(110, 20);
            this.valu4.TabIndex = 11;
            this.valu4.Text = "value4";
            // 
            // valu2
            // 
            this.valu2.Enabled = false;
            this.valu2.Location = new System.Drawing.Point(64, 35);
            this.valu2.Name = "valu2";
            this.valu2.PasswordChar = '*';
            this.valu2.Size = new System.Drawing.Size(110, 20);
            this.valu2.TabIndex = 10;
            this.valu2.Text = "value2";
            // 
            // valu3
            // 
            this.valu3.Enabled = false;
            this.valu3.Location = new System.Drawing.Point(64, 91);
            this.valu3.Name = "valu3";
            this.valu3.Size = new System.Drawing.Size(110, 20);
            this.valu3.TabIndex = 9;
            this.valu3.Text = "value3";
            // 
            // valu1
            // 
            this.valu1.Enabled = false;
            this.valu1.Location = new System.Drawing.Point(64, 14);
            this.valu1.Name = "valu1";
            this.valu1.Size = new System.Drawing.Size(110, 20);
            this.valu1.TabIndex = 8;
            this.valu1.Text = "UserName";
            // 
            // arrg2
            // 
            this.arrg2.Enabled = false;
            this.arrg2.Location = new System.Drawing.Point(24, 35);
            this.arrg2.Name = "arrg2";
            this.arrg2.Size = new System.Drawing.Size(40, 20);
            this.arrg2.TabIndex = 7;
            this.arrg2.Text = "password";
            // 
            // arrg3
            // 
            this.arrg3.Enabled = false;
            this.arrg3.Location = new System.Drawing.Point(24, 91);
            this.arrg3.Name = "arrg3";
            this.arrg3.Size = new System.Drawing.Size(40, 20);
            this.arrg3.TabIndex = 6;
            this.arrg3.Text = "arg3";
            // 
            // arrg4
            // 
            this.arrg4.Enabled = false;
            this.arrg4.Location = new System.Drawing.Point(24, 113);
            this.arrg4.Name = "arrg4";
            this.arrg4.Size = new System.Drawing.Size(40, 20);
            this.arrg4.TabIndex = 5;
            this.arrg4.Text = "arg4";
            // 
            // arrg1
            // 
            this.arrg1.Enabled = false;
            this.arrg1.Location = new System.Drawing.Point(24, 14);
            this.arrg1.Name = "arrg1";
            this.arrg1.Size = new System.Drawing.Size(40, 20);
            this.arrg1.TabIndex = 4;
            this.arrg1.Text = "username";
            // 
            // arg2check
            // 
            this.arg2check.Location = new System.Drawing.Point(7, 42);
            this.arg2check.Name = "arg2check";
            this.arg2check.Size = new System.Drawing.Size(16, 16);
            this.arg2check.TabIndex = 3;
            this.arg2check.CheckedChanged += new System.EventHandler(this.arg2check_CheckedChanged);
            // 
            // arg3check
            // 
            this.arg3check.Location = new System.Drawing.Point(7, 93);
            this.arg3check.Name = "arg3check";
            this.arg3check.Size = new System.Drawing.Size(16, 16);
            this.arg3check.TabIndex = 2;
            this.arg3check.CheckedChanged += new System.EventHandler(this.arg3check_CheckedChanged);
            // 
            // arg4check
            // 
            this.arg4check.Location = new System.Drawing.Point(7, 115);
            this.arg4check.Name = "arg4check";
            this.arg4check.Size = new System.Drawing.Size(16, 16);
            this.arg4check.TabIndex = 1;
            this.arg4check.CheckedChanged += new System.EventHandler(this.arg4check_CheckedChanged);
            // 
            // arg1check
            // 
            this.arg1check.Location = new System.Drawing.Point(7, 19);
            this.arg1check.Name = "arg1check";
            this.arg1check.Size = new System.Drawing.Size(148, 16);
            this.arg1check.TabIndex = 0;
            this.arg1check.Text = "Use User/Pass";
            this.arg1check.CheckedChanged += new System.EventHandler(this.arg1check_CheckedChanged);
            // 
            // sendPwSecurely
            // 
            this.sendPwSecurely.Checked = true;
            this.sendPwSecurely.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sendPwSecurely.Enabled = false;
            this.sendPwSecurely.Location = new System.Drawing.Point(24, 60);
            this.sendPwSecurely.Name = "sendPwSecurely";
            this.sendPwSecurely.Size = new System.Drawing.Size(150, 17);
            this.sendPwSecurely.TabIndex = 3;
            this.sendPwSecurely.Text = "Send Password Securely";
            // 
            // storePwSecurely
            // 
            this.storePwSecurely.Checked = true;
            this.storePwSecurely.CheckState = System.Windows.Forms.CheckState.Checked;
            this.storePwSecurely.Enabled = false;
            this.storePwSecurely.Location = new System.Drawing.Point(24, 76);
            this.storePwSecurely.Name = "storePwSecurely";
            this.storePwSecurely.Size = new System.Drawing.Size(150, 17);
            this.storePwSecurely.TabIndex = 3;
            this.storePwSecurely.Text = "Store Password Securely";
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
            this.groupBox4.Text = "URL\'s";
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
            this.groupBox9.Controls.Add(this.CloseToSysTray);
            this.groupBox9.Location = new System.Drawing.Point(8, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(184, 80);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Startup Options";
            // 
            // stwowlaunch
            // 
            this.stwowlaunch.Location = new System.Drawing.Point(8, 28);
            this.stwowlaunch.Name = "stwowlaunch";
            this.stwowlaunch.Size = new System.Drawing.Size(120, 16);
            this.stwowlaunch.TabIndex = 2;
            this.stwowlaunch.Text = "Auto-Launch WoW";
            this.stwowlaunch.CheckedChanged += new System.EventHandler(this.stwowlaunch_CheckedChanged);
            // 
            // stmin
            // 
            this.stmin.Location = new System.Drawing.Point(8, 43);
            this.stmin.Name = "stmin";
            this.stmin.Size = new System.Drawing.Size(104, 16);
            this.stmin.TabIndex = 1;
            this.stmin.Text = "Start Minimized";
            // 
            // stboot
            // 
            this.stboot.Location = new System.Drawing.Point(8, 13);
            this.stboot.Name = "stboot";
            this.stboot.Size = new System.Drawing.Size(136, 16);
            this.stboot.TabIndex = 0;
            this.stboot.Text = "Start with Windows";
            this.stboot.CheckedChanged += new System.EventHandler(this.stboot_CheckedChanged);
            // 
            // CloseToSysTray
            // 
            this.CloseToSysTray.Location = new System.Drawing.Point(8, 55);
            this.CloseToSysTray.Name = "CloseToSysTray";
            this.CloseToSysTray.Size = new System.Drawing.Size(120, 22);
            this.CloseToSysTray.TabIndex = 3;
            this.CloseToSysTray.Text = "Close To SysTray";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSysTrayIco);
            this.groupBox1.Controls.Add(this.cbCloseAfterWowLaunch);
            this.groupBox1.Controls.Add(this.cbUpErrorPop);
            this.groupBox1.Controls.Add(this.cbCloseAfterUpdates);
            this.groupBox1.Controls.Add(this.userAlbl);
            this.groupBox1.Controls.Add(this.userAgent);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.autoUploader);
            this.groupBox1.Location = new System.Drawing.Point(200, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 96);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Miscellaneous";
            // 
            // btnSysTrayIco
            // 
            this.btnSysTrayIco.Location = new System.Drawing.Point(6, 67);
            this.btnSysTrayIco.Name = "btnSysTrayIco";
            this.btnSysTrayIco.Size = new System.Drawing.Size(81, 23);
            this.btnSysTrayIco.TabIndex = 27;
            this.btnSysTrayIco.Text = "SysTray Icon";
            this.btnSysTrayIco.UseVisualStyleBackColor = true;
            this.btnSysTrayIco.Click += new System.EventHandler(this.btnSysTrayIco_Click);
            // 
            // cbCloseAfterWowLaunch
            // 
            this.cbCloseAfterWowLaunch.Location = new System.Drawing.Point(127, 49);
            this.cbCloseAfterWowLaunch.Name = "cbCloseAfterWowLaunch";
            this.cbCloseAfterWowLaunch.Size = new System.Drawing.Size(151, 16);
            this.cbCloseAfterWowLaunch.TabIndex = 4;
            this.cbCloseAfterWowLaunch.Text = "Close After Wow Launch";
            // 
            // cbUpErrorPop
            // 
            this.cbUpErrorPop.Location = new System.Drawing.Point(127, 16);
            this.cbUpErrorPop.Name = "cbUpErrorPop";
            this.cbUpErrorPop.Size = new System.Drawing.Size(123, 16);
            this.cbUpErrorPop.TabIndex = 26;
            this.cbUpErrorPop.Text = "Upload Error Popup";
            // 
            // cbCloseAfterUpdates
            // 
            this.cbCloseAfterUpdates.Location = new System.Drawing.Point(127, 32);
            this.cbCloseAfterUpdates.Name = "cbCloseAfterUpdates";
            this.cbCloseAfterUpdates.Size = new System.Drawing.Size(149, 16);
            this.cbCloseAfterUpdates.TabIndex = 3;
            this.cbCloseAfterUpdates.Text = "Close After Updates";
            // 
            // userAlbl
            // 
            this.userAlbl.Location = new System.Drawing.Point(93, 72);
            this.userAlbl.Name = "userAlbl";
            this.userAlbl.Size = new System.Drawing.Size(64, 16);
            this.userAlbl.TabIndex = 25;
            this.userAlbl.Text = "User Agent:";
            // 
            // userAgent
            // 
            this.userAgent.Location = new System.Drawing.Point(163, 69);
            this.userAgent.Name = "userAgent";
            this.userAgent.Size = new System.Drawing.Size(109, 20);
            this.userAgent.TabIndex = 24;
            this.userAgent.TextChanged += new System.EventHandler(this.userAgent_TextChanged);
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
            this.response.Controls.Add(this.FURfWLbl);
            this.response.Controls.Add(this.WebDataLbl);
            this.response.Controls.Add(this.servResponse);
            this.response.Location = new System.Drawing.Point(4, 22);
            this.response.Name = "response";
            this.response.Size = new System.Drawing.Size(488, 230);
            this.response.TabIndex = 2;
            this.response.Text = "Server Response";
            // 
            // respOpenIE2
            // 
            this.respOpenIE2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // FURfWLbl
            // 
            this.FURfWLbl.Location = new System.Drawing.Point(8, 16);
            this.FURfWLbl.Name = "FURfWLbl";
            this.FURfWLbl.Size = new System.Drawing.Size(240, 16);
            this.FURfWLbl.TabIndex = 21;
            this.FURfWLbl.Text = "File Upload Response from Website:";
            // 
            // WebDataLbl
            // 
            this.WebDataLbl.Location = new System.Drawing.Point(8, 144);
            this.WebDataLbl.Name = "WebDataLbl";
            this.WebDataLbl.Size = new System.Drawing.Size(248, 16);
            this.WebDataLbl.TabIndex = 20;
            this.WebDataLbl.Text = "Website ===> SavedVariables.lua Data:";
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
            this.servResponse.Size = new System.Drawing.Size(472, 98);
            this.servResponse.TabIndex = 19;
            this.servResponse.Text = "Any Data returned by primary URL will be displayed here.";
            this.servResponse.WordWrap = false;
            // 
            // Debugger
            // 
            this.Debugger.Controls.Add(this.DebugInfoLbl);
            this.Debugger.Controls.Add(this.dbIEbtn);
            this.Debugger.Controls.Add(this.dbNPbtn);
            this.Debugger.Controls.Add(this.button5);
            this.Debugger.Controls.Add(this.debugSaveAs);
            this.Debugger.Controls.Add(this.DebugBox);
            this.Debugger.Location = new System.Drawing.Point(4, 22);
            this.Debugger.Name = "Debugger";
            this.Debugger.Size = new System.Drawing.Size(488, 230);
            this.Debugger.TabIndex = 7;
            this.Debugger.Text = "Debugger";
            // 
            // DebugInfoLbl
            // 
            this.DebugInfoLbl.Location = new System.Drawing.Point(8, 16);
            this.DebugInfoLbl.Name = "DebugInfoLbl";
            this.DebugInfoLbl.Size = new System.Drawing.Size(248, 16);
            this.DebugInfoLbl.TabIndex = 5;
            this.DebugInfoLbl.Text = "Debug Info";
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
            this.Help.Controls.Add(this.AdvancedBtn);
            this.Help.Controls.Add(this.InfoBtn);
            this.Help.Controls.Add(this.OptionsBtn);
            this.Help.Controls.Add(this.SettingsBtn);
            this.Help.Controls.Add(this.richTextBox1);
            this.Help.Location = new System.Drawing.Point(4, 22);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(488, 230);
            this.Help.TabIndex = 4;
            this.Help.Text = "Help";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(96, 8);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "Updater";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // AdvancedBtn
            // 
            this.AdvancedBtn.Location = new System.Drawing.Point(264, 8);
            this.AdvancedBtn.Name = "AdvancedBtn";
            this.AdvancedBtn.Size = new System.Drawing.Size(80, 23);
            this.AdvancedBtn.TabIndex = 5;
            this.AdvancedBtn.Text = "Advanced";
            this.AdvancedBtn.Click += new System.EventHandler(this.AdvancedBtn_Click);
            // 
            // InfoBtn
            // 
            this.InfoBtn.Location = new System.Drawing.Point(352, 8);
            this.InfoBtn.Name = "InfoBtn";
            this.InfoBtn.Size = new System.Drawing.Size(80, 23);
            this.InfoBtn.TabIndex = 4;
            this.InfoBtn.Text = "Information";
            this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
            // 
            // OptionsBtn
            // 
            this.OptionsBtn.Location = new System.Drawing.Point(176, 8);
            this.OptionsBtn.Name = "OptionsBtn";
            this.OptionsBtn.Size = new System.Drawing.Size(80, 23);
            this.OptionsBtn.TabIndex = 2;
            this.OptionsBtn.Text = "Options";
            this.OptionsBtn.Click += new System.EventHandler(this.OptionsBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Location = new System.Drawing.Point(8, 8);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(80, 23);
            this.SettingsBtn.TabIndex = 1;
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
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
            this.About.Size = new System.Drawing.Size(488, 230);
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 259);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(470, 16);
            this.progressBar1.TabIndex = 27;
            // 
            // clearSVFiles
            // 
            this.clearSVFiles.Location = new System.Drawing.Point(8, 229);
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
            this.groupBox3.Location = new System.Drawing.Point(504, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 260);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Saved Variables";
            // 
            // SVList
            // 
            this.SVList.CheckOnClick = true;
            this.SVList.Location = new System.Drawing.Point(8, 16);
            this.SVList.Name = "SVList";
            this.SVList.Size = new System.Drawing.Size(112, 199);
            this.SVList.TabIndex = 21;
            this.SVList.SelectedIndexChanged += new System.EventHandler(this.SVList_SelectedIndexChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 279);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(494, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 19;
            this.statusBar1.Text = "Idle";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "Idle";
            this.statusBarPanel1.Width = 494;
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
            this.groupBox15.Size = new System.Drawing.Size(160, 80);
            this.groupBox15.TabIndex = 4;
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
            this.groupBox8.Controls.Add(this.AddonNameLbl);
            this.groupBox8.Controls.Add(this.pictureBox7);
            this.groupBox8.Controls.Add(this.AddonVerLbl);
            this.groupBox8.Controls.Add(this.AddonTOCLbl);
            this.groupBox8.Controls.Add(this.AddonDescLbl);
            this.groupBox8.Controls.Add(this.pictureBox6);
            this.groupBox8.Controls.Add(this.pictureBox5);
            this.groupBox8.Controls.Add(this.pictureBox4);
            this.groupBox8.Controls.Add(this.button7);
            this.groupBox8.Controls.Add(this.button6);
            this.groupBox8.Controls.Add(this.AddonsListLbl);
            this.groupBox8.Controls.Add(this.treeView1);
            this.groupBox8.Location = new System.Drawing.Point(12, 280);
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
            this.addonSyncBtn.Size = new System.Drawing.Size(75, 23);
            this.addonSyncBtn.TabIndex = 35;
            this.addonSyncBtn.Text = "Synchronize";
            this.addonSyncBtn.Click += new System.EventHandler(this.addonSyncBtn_Click);
            // 
            // AddonNameLbl
            // 
            this.AddonNameLbl.Location = new System.Drawing.Point(32, 16);
            this.AddonNameLbl.Name = "AddonNameLbl";
            this.AddonNameLbl.Size = new System.Drawing.Size(48, 16);
            this.AddonNameLbl.TabIndex = 34;
            this.AddonNameLbl.Text = "=Name";
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
            // AddonVerLbl
            // 
            this.AddonVerLbl.Location = new System.Drawing.Point(240, 16);
            this.AddonVerLbl.Name = "AddonVerLbl";
            this.AddonVerLbl.Size = new System.Drawing.Size(80, 16);
            this.AddonVerLbl.TabIndex = 32;
            this.AddonVerLbl.Text = "=Version";
            // 
            // AddonTOCLbl
            // 
            this.AddonTOCLbl.Location = new System.Drawing.Point(184, 16);
            this.AddonTOCLbl.Name = "AddonTOCLbl";
            this.AddonTOCLbl.Size = new System.Drawing.Size(40, 16);
            this.AddonTOCLbl.TabIndex = 31;
            this.AddonTOCLbl.Text = "=TOC";
            // 
            // AddonDescLbl
            // 
            this.AddonDescLbl.Location = new System.Drawing.Point(96, 16);
            this.AddonDescLbl.Name = "AddonDescLbl";
            this.AddonDescLbl.Size = new System.Drawing.Size(72, 16);
            this.AddonDescLbl.TabIndex = 30;
            this.AddonDescLbl.Text = "=Description";
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
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 26;
            this.button7.Text = "Collapse All";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(320, 136);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 25;
            this.button6.Text = "Expand All";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // AddonsListLbl
            // 
            this.AddonsListLbl.Location = new System.Drawing.Point(320, 32);
            this.AddonsListLbl.Name = "AddonsListLbl";
            this.AddonsListLbl.Size = new System.Drawing.Size(152, 96);
            this.AddonsListLbl.TabIndex = 0;
            this.AddonsListLbl.Text = "These are addons which UniAdmin has available to be automatically updated on your" +
                " system.  The addons which are marked \"required\" in UniAdmin can\'t be unchecked." +
                "";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(8, 32);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(304, 128);
            this.treeView1.TabIndex = 24;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.node_AfterCheck);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(504, 292);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(120, 112);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(494, 301);
            this.Controls.Add(this.progressBar1);
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
            this.MinimumSize = new System.Drawing.Size(500, 329);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniUploader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.myTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTimer2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Settings.ResumeLayout(false);
            this.configGroup.ResumeLayout(false);
            this.configGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Advanced.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.otherexes.ResumeLayout(false);
            this.otherexes.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.wowAddons.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoSyncInterval)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.Options.ResumeLayout(false);
            this.vargrp.ResumeLayout(false);
            this.vargrp.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.response.ResumeLayout(false);
            this.response.PerformLayout();
            this.Debugger.ResumeLayout(false);
            this.Help.ResumeLayout(false);
            this.About.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

// ----------------------------------------------

		///	<summary>
		///	The	main entry point for the application.
		///	</summary>
		[STAThread]
		static void Main()
		{
			// If UniUploader is already running then no point trying to launch a 2nd version
			// First lets get the name of our application/process
			string proc=Process.GetCurrentProcess().ProcessName;
			// Now we need to get the list of all processes by that name
			Process[] processes=Process.GetProcessesByName(proc);
			// Check if there is more than one process...
			if (processes.Length > 1) {
				// More than one process found so lets quit out of this launch
				DialogResult resultFCO = MessageBox.Show(proc+" is already running, force close other "+proc+"?","ERROR: "+proc+" already running!",System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
				if (resultFCO == DialogResult.Yes)
				{
					// Lets make sure to get the current Id so we don't close this by mistake
					Process currentProcess = Process.GetCurrentProcess();
					// Close all the other running versions
					foreach (Process p in processes)
					{
						// Only close all other existing processes, not this apps process
						if (p.Id != currentProcess.Id)
						{
							// Kill the other running process
							p.Kill();
						}
					}
				}
				if (resultFCO == DialogResult.No)
				{
					DialogResult resultLAI = MessageBox.Show("Launch another instance of "+proc+"?","ERROR: "+proc+" already running!",System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
					if (resultLAI == DialogResult.No)
					{
						// Ignore all the other running versions and close this one instead
						Application.Exit();
						return;
					}
				}
			}

			try
			{
				Application.EnableVisualStyles();
				Application.Run(new MainForm());
			}
			catch (Exception ex)
			{
				if (ex.GetType() == typeof(System.Security.SecurityException))
					MessageBox.Show("UniUploader is unable to run due to constraints set by the current .NET Framework security policy.", "Failure", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
				else
					MessageBox.Show(ex.ToString(), "Failure", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
			}
		}

// ----------------------------------------------

		private void Form1_Load(object sender, System.EventArgs e)
		{
			windowstate = "starting";
			IsUploading = true;
			DebugLine(_STING);
			DebugLine(".NET Framework " + System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion());
			Thread.CurrentThread.Name = "Main thread";
			statusBarPanel1.Text = _INIT;

			http.onReceiveProgress += new UniUploader.http.ReceiveProgressDelegate(http_onReceiveProgress);
			http.onSendProgress += new UniUploader.http.SendProgressDelegate(http_onSendProgress);
			http.onInformationMessage += new UniUploader.http.httpInfoDelegate(http_onInformationMessage);

			UUuserAgent = buildUserAgent();
			userAgent.Text = UUuserAgent;
			version.Text = uniVersionMajor + "." + uniVersionMinor + "." + uniVersionBuild + "." + uniVersionRevision;
			libLink.Links.Remove(libLink.Links[0]);
			libLink.Links.Add(0, libLink.Text.Length, "http://wowroster.net");
			this.Resize += new EventHandler(Form1_Resize);

			watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Attributes | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
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
				}
				else
				{
					WindowState = FormWindowState.Minimized;
				}
			}
			if (stwowlaunch.Checked) { LaunchWoWWait(); }
			Upload_Timer.Enabled = true;
			Upload_Timer.Stop();
			close_timer.Enabled = true;
			close_timer.Stop();
			myTimer.Enabled = false;
			if (addonAutoUpdate.Checked || uuSettingsUpdater.Checked || UUUpdaterCheck.Checked || retrdatafromsite.Checked)
			{
				autoAddonSyncNow_Click(null, new System.EventArgs());
			}
			string UUPath = WorkSpacePath;
			try
			{
				if (File.Exists(UUPath + @"\logo1.png"))
				{
					pictureBox1.Image = Image.FromFile(UUPath + @"\logo1.png");
				}
				else if (File.Exists(UUPath + @"\logo1.gif"))
				{
					pictureBox1.Image = Image.FromFile(UUPath + @"\logo1.gif");
				}
				else if (File.Exists(UUPath + @"\logo1.jpg"))
				{
					pictureBox1.Image = Image.FromFile(UUPath + @"\logo1.jpg");
				}

				if (File.Exists(UUPath + @"\logo2.png"))
				{
					pictureBox2.Image = Image.FromFile(UUPath + @"\logo2.png");
				}
				else if (File.Exists(UUPath + @"\logo2.gif"))
				{
					pictureBox2.Image = Image.FromFile(UUPath + @"\logo2.gif");
				}
				else if (File.Exists(UUPath + @"\logo2.jpg"))
				{
					pictureBox2.Image = Image.FromFile(UUPath + @"\logo2.jpg");
				}
			}
			catch (Exception err)
			{
				DebugLine(@"Form1_load, pictureBoxX.Image = Image.FromFile(UUPath + @""\logoX.XXX"");:" + err.Message);
			}
			if (exeOnUuStart.Checked)
			{
				LaunchEXEs();
			}
			if (retrdatafromsite.Checked)
			{
				doWebsiteToWow();
			}
			if (TEST_VERSION)
			{
				UUUpdaterCheck.Checked = false;
				UUUpdaterCheck.Enabled = false;
				UUAutoUpdaterCheck.Checked = false;
				UUAutoUpdaterCheck.Enabled = false;
			}
			populateContextMenu2();
			string uuver = uniVersionMajor + "." + uniVersionMinor + "." + uniVersionBuild + "." + uniVersionRevision;
			DebugLine("v" + uuver + " " + _READY);
			statusBarPanel1.Text = _READY;
			IsUploading = false;
			SetSysTrayIcon();
			windowstate = "";
			http.UserAgent = getUserAgent();
			if (cbCloseAfterWowLaunch.Checked && stwowlaunch.Checked)
			{
				closeWait();
			}
		}

// ----------------------------------------------

		void http_onSendProgress(int CurrentPosition, int TotalSize)
		{
			if (TotalSize > 0)
			{
				double p = (double)CurrentPosition / (double)TotalSize;
				p = p * 100;
				p = Math.Round(p, 0);
				if (p > 98 && p < 100) p = 100;
				if (p > 100) p = 100;
				if (p < 0) p = 0;
				SetProgressBarValue(progressBar1, (int)p);
				InvokeProgressBarUpdate(progressBar1);
			}
		}

// ----------------------------------------------

		void http_onReceiveProgress(int CurrentPosition, int TotalSize)
		{
			if (TotalSize > 0)
			{
				double p = CurrentPosition / TotalSize;
				p = p * 100;
				p = Math.Round(p, 0);
				if (p > 98 && p < 100) p = 100;
				if (p > 100) p = 100;
				if (p < 0) p = 0;
				SetProgressBarValue(progressBar1, (int)p);
				InvokeProgressBarUpdate(progressBar1);
			}
		}

// ----------------------------------------------

		private void closeWait()
		{
			Thread t = new Thread(new ThreadStart(closeWait2));
			t.Start();
		}

// ----------------------------------------------

		private void closeWait2()
		{

			while (this.windowstate != "" || this.UpdatesGoing || this.updating || this.IsUploading)
			{
				Thread.Sleep(1000);
			}
			CloseForm();

		}

// ----------------------------------------------

		private void LaunchWoWWait()
		{
			Thread t = new Thread(new ThreadStart(LaunchWoWWait2));
			t.Start();
		}

// ----------------------------------------------

		private delegate void LaunchWoWWaitDelegate();

// ----------------------------------------------

		private void LaunchWoWWait2()
		{

			while (this.windowstate != "" || this.UpdatesGoing || this.updating || this.IsUploading)
			{
				Thread.Sleep(1000);
			}
			if (this.InvokeRequired)
			{
				LaunchWoWWaitDelegate dele = new LaunchWoWWaitDelegate(LaunchWoWWait3);
				this.BeginInvoke(dele);
			}
			else
			{
				LaunchWoWWait3();
			}

		}

// ----------------------------------------------

		private void LaunchWoWWait3()
		{
			LaunchWoW();
		}

// ----------------------------------------------

		private void setupWatchers()
		{
			string InstallPath = GetInstallPath();
			string goodpath = InstallPath + "\\WTF\\Account\\" + AccountList.SelectedItem;
			if (Directory.Exists(goodpath))
			{
				mainSvLocation = goodpath + "\\SavedVariables.lua";
			}
			if (Directory.Exists(mainSvLocation.Replace(".lua", "")))
			{
				watcher.Path = mainSvLocation.Replace(".lua", "");
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

// ----------------------------------------------

		private void doLogos(string url)
		{
			string filename = Path.GetFileName(url);
			string serverMD5 = RetrData(AutoAddonURL.Text, null, null, "OPERATION", "GETFILEMD5", "FILENAME", filename, null, null, UUTimeOut, null, null);
			if (serverMD5 != "")
			{
				string path = WorkSpacePath + filename;
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

// ----------------------------------------------

		private void upload()
		{
			UploadNowBtn.Enabled = false;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			IsUploading = true;
			//servResponse.Clear();
			TextBoxClear(servResponse);
			string path = mainSvLocation.Replace(".lua", "");
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
			if (arg1check.Checked == true) { param1 = arrg1.Text; val1 = valu1.Text; }
			else { param1 = null; val1 = null; }
			if (arg2check.Checked == true)
			{
				param2 = arrg2.Text;
				if (sendPwSecurely.Checked)
					val2 = MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text));
				else
					val2 = valu2.Text;
			}
			else { param2 = null; val2 = null; }
			if (arg3check.Checked == true) { param3 = arrg3.Text; val3 = valu3.Text; }
			else { param3 = null; val3 = null; }
			if (arg4check.Checked == true) { param4 = arrg4.Text; val4 = valu4.Text; }
			else { param4 = null; val4 = null; }
			if (retrdatafromsite.Checked && chWtoWOWbeforeUpload.Checked)
			{
				doWebsiteToWow();
			}
			if (cbInclAddonData.Checked)
			{
				//do the primary URL
				SetStatusBarPanelText(statusBarPanel1, _UPLOADING_PRIMARY + " - " + URL.Text);
				DebugLine(_UPLOADING_PRIMARY + ": " + URL.Text);
				responseFromServer = Upload(URL.Text, null, null, null, param1, param2, param3, param4, val1, val2, val3, val4);
				responseFromServer = responseFromServer.Replace("\n", CRLF);
				TextBoxAppendText(servResponse, "<!-- ############ " + _UPLOADING_PRIMARY + CRLF +
					"	 ############ " + URL.Text + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF);
				if (chaddurl1.Checked)
				{
					statusBarPanel1.Text = _UPLOADING_ADDURL1 + " - " + addurl1.Text;
					DebugLine(_UPLOADING_ADDURL1 + " - " + addurl1.Text);
					responseFromServer = Upload(addurl1.Text, null, null, null, param1, param2, param3, param4, val1, val2, val3, val4);
					responseFromServer = responseFromServer.Replace("\n", CRLF);
					TextBoxAppendText(servResponse, "<!-- ############ " + _UPLOADING_ADDURL1 + CRLF +
						"	 ############ " + addurl1.Text + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF);
				}
				if (chaddurl2.Checked)
				{
					statusBarPanel1.Text = _UPLOADING_ADDURL2 + " - " + addurl2.Text;
					DebugLine(_UPLOADING_ADDURL2 + " - " + addurl2.Text);
					responseFromServer = Upload(addurl2.Text, null, null, null, param1, param2, param3, param4, val1, val2, val3, val4);
					responseFromServer = responseFromServer.Replace("\n", CRLF);
					TextBoxAppendText(servResponse, "<!-- ############ " + _UPLOADING_ADDURL2 + CRLF +
						"	 ############ " + addurl2.Text + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF);
				}
				if (chaddurl3.Checked)
				{
					statusBarPanel1.Text = _UPLOADING_ADDURL3 + " - " + addurl3.Text;
					DebugLine(_UPLOADING_ADDURL3 + " - " + addurl3.Text);
					responseFromServer = Upload(addurl3.Text, null, null, null, param1, param2, param3, param4, val1, val2, val3, val4);
					responseFromServer = responseFromServer.Replace("\n", CRLF);
					TextBoxAppendText(servResponse, "<!-- ############ " + _UPLOADING_ADDURL3 + CRLF +
						"	 ############ " + addurl3.Text + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF);
				}
				if (chaddurl4.Checked)
				{
					statusBarPanel1.Text = _UPLOADING_ADDURL4 + " - " + addurl4.Text;
					DebugLine(_UPLOADING_ADDURL4 + " - " + addurl4.Text);
					responseFromServer = Upload(addurl4.Text, null, null, null, param1, param2, param3, param4, val1, val2, val3, val4);
					responseFromServer = responseFromServer.Replace("\n", CRLF);
					TextBoxAppendText(servResponse, "<!-- ############ " + _UPLOADING_ADDURL4 + CRLF +
						"	 ############ " + addurl4.Text + " -->" + CRLF + CRLF + responseFromServer + CRLF + CRLF + CRLF);
				}
			}
			if (cbInclScreenShots.Checked)
			{
				doScreenshots();
			}
			if (retrdatafromsite.Checked && chWtoWOWafterUpload.Checked)
			{
				doWebsiteToWow();
			}
			myTimer2.Interval = 2000;
			myTimer2.Enabled = true;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			//UploadNowBtn.Enabled = true;
			setControlEnabled(UploadNowBtn, true);
			//statusBarPanel1.Text = _READY;
			SetStatusBarPanelText(statusBarPanel1, _READY);
			//UploadThread.Abort();
		}

// ----------------------------------------------

		private Hashtable getSVFileList()
		{
			Hashtable files = new Hashtable();
			string fullFilePath = "";
			string sep = Path.DirectorySeparatorChar.ToString();
			foreach (string checkedSV in SVList.CheckedItems) //itterate through all checked files in the sv file list
			{
				if (checkedSV != "SavedVariables")
				{

					fullFilePath = Path.GetDirectoryName(this.mainSvLocation) + sep + "SavedVariables" + sep + checkedSV + ".lua";
				}
				else
				{

					fullFilePath = Path.GetDirectoryName(this.mainSvLocation) + sep + "SavedVariables.lua";
				}

				files[checkedSV] = fullFilePath;
			}
			return files;
		}

// ----------------------------------------------

		private string fixLineEnds(string inString)
		{
			inString = inString.Replace("\r", "");
			inString = inString.Replace("\n", Environment.NewLine);
			return inString;
		}

// ----------------------------------------------

		private string writeDummyScreenshotsLuaFile()
		{
			byte[] contents = System.Text.ASCIIEncoding.ASCII.GetBytes(@"screenshots = {}");
			string sep = Path.DirectorySeparatorChar.ToString();
			string path = WorkSpacePath + sep + "screenshots.lua";
			if (File.Exists(path)) File.Delete(path);
			FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
			fs.Write(contents, 0, contents.Length);
			fs.Close();
			return path;
		}

// ----------------------------------------------

		private void doScreenshots()
		{
			Hashtable files = new Hashtable();//getSVFileList();
			string dummyFilePath = writeDummyScreenshotsLuaFile();
			files["screenshots"] = dummyFilePath;

			SetStatusBarPanelText(statusBarPanel1, Environment.NewLine + "Checking Screenshots" + Environment.NewLine);
			Hashtable h = get_screenshot_list();
			string data = "";
			foreach (DictionaryEntry de in h)
			{
				data += de.Value + "\n";
			}
			ArrayList allParams = get_all_params();
			allParams.Add(new string[2] { "OPERATION", "CHECKSHOTS" });
			allParams.Add(new string[2] { "data", data });
			UniUploader.http.Response Response = new UniUploader.http.Response();
			if (http.post(ref Response, URL.Text, allParams, files))
			{
				TextBoxAppendText(servResponse, Environment.NewLine + "Screenshot Process Step 1 Response:" + Environment.NewLine);
				TextBoxAppendText(servResponse, fixLineEnds(Response.ToString()));

				string[] NotUploadedYet = Response.ToString().Split('\n');
				foreach (string ssToUp in NotUploadedYet)
				{
					foreach (DictionaryEntry de in h)
					{
						if ((string)de.Value == ssToUp)
						{
							files[ssToUp] = de.Key;
						}
					}
				}
				if (files.Count - 1 > 0)
				{
					allParams = get_all_params();
					allParams.Add(new string[2] { "OPERATION", "UPSHOTS" });
					SetStatusBarPanelText(statusBarPanel1, "Uploading " + (files.Count - 1).ToString() + " Screenshots");
					if (http.post(ref Response, URL.Text, allParams, files))
					{
						TextBoxAppendText(servResponse, Environment.NewLine + "Screenshot Process Step 2 Response:" + Environment.NewLine);
						TextBoxAppendText(servResponse, fixLineEnds(Response.ToString()));
						DebugLine("Uploaded " + (files.Count - 1).ToString() + " Screenshots");
					}
					else
					{
						if (cbUpErrorPop.Checked)
						{
							MessageBox.Show("Error - Check Debug Log");
						}
					}
				}

			}
			else
			{
				if (cbUpErrorPop.Checked)
				{
					MessageBox.Show("Error - Check Debug Log");
				}
				DebugLine("Failed to upload screenshots");
			}

			SetStatusBarPanelText(statusBarPanel1, _READY);
		}

// ----------------------------------------------

		private ArrayList get_all_params()
		{
			ArrayList allParams = new ArrayList();
			if (arg1check.Checked) allParams.Add(new string[2] { arrg1.Text, valu1.Text });
			if (arg2check.Checked) allParams.Add(new string[2] { arrg2.Text, (sendPwSecurely.Checked) ? MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text)) : valu2.Text });
			if (arg3check.Checked) allParams.Add(new string[2] { arrg3.Text, valu3.Text });
			if (arg4check.Checked) allParams.Add(new string[2] { arrg4.Text, valu4.Text });
			return allParams;
		}

// ----------------------------------------------

		private Hashtable get_screenshot_list()
		{
			Hashtable h = new Hashtable();
			string sspath = wowExeLoc + "\\Screenshots";
			if (Directory.Exists(sspath))
			{
				DirectoryInfo d = new DirectoryInfo(sspath);
				FileInfo[] files;
				files = d.GetFiles("*.jpg");
				foreach (FileInfo file in files)
				{
					String fileName = file.FullName;
					String fileSize = file.Length.ToString();
					h[fileName] = MD5SUM(FileToByteArray(fileName));
				}
			}
			return h;
		}

// ----------------------------------------------

		public void doWebsiteToWow()
		{
			SetStatusBarPanelText(statusBarPanel1, _RETRDATA);
			string retrdatadfromsite = "";
			string pw = "";
			if (sendPwSecurely.Checked)
				pw = MD5SUM(new UTF8Encoding(true).GetBytes(valu2.Text));
			else
				pw = valu2.Text;
			if (arg1check.Checked && arg2check.Checked)
			{
				retrdatadfromsite = RetrData(retrDataUrl.Text, null, null, "OPERATION", "GETDATA", arrg1.Text, valu1.Text, arrg2.Text, pw, -1, null, null);
			}
			else
			{
				retrdatadfromsite = RetrData(retrDataUrl.Text, null, null, "OPERATION", "GETDATA", null, null, null, null, -1, null, null);
			}
			setControlText(retrdatawindow, retrdatadfromsite.Replace("\n", "\r\n"));
			SetStatusBarPanelText(statusBarPanel1, _WRITINGSV);
			string filename = "";
			if (webWoWSvFile.Text != "SavedVariables.lua")
			{
				filename = mainSvLocation.Replace(".lua", "") + @"\" + webWoWSvFile.Text;
			}
			else
			{
				filename = mainSvLocation;
			}
			byte[] finalArray = new UTF8Encoding().GetBytes(retrdatadfromsite + "\n"); //i think its UTF8 default?
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
				inFile.Write(finalArray, 0, finalArray.Length);
				inFile.Close();
			}
			SetStatusBarPanelText(statusBarPanel1, _READY);
		}

// ----------------------------------------------

		private string ReadFileToString(string fullPath)
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
				DebugLine(_CANTREADFILE + ": " + e.Message);
			}
			return FileString;
		}

// ----------------------------------------------

		private string findLangFile()
		{
			string thisAppDataPath = Application.UserAppDataPath;
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
						if (fi.Name.ToLower() == "languages.ini")
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
				if (fi.Name.ToLower() == "languages.ini")
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

		private string findSettingFile()
		{
			string thisAppDataPath = Application.UserAppDataPath;
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
								case "UPLOADSVS":
									cbInclAddonData.Checked = settingValueBool;
									break;
								case "UPLOADSCREENSHOTS":
									cbInclScreenShots.Checked = settingValueBool;
									break;
								case "PURGEFIRST":
									purgefirstCh.Checked = settingValueBool;
									break;
								case "ALLOWADDONDEL":
									chAllowDelAddons.Checked = settingValueBool;
									if (addonAutoUpdate.Checked) { chAllowDelAddons.Enabled = true; }
									else { chAllowDelAddons.Enabled = false; }
									break;
								case "SELECTEDACCT":
									selectedAcc = settingValue;
									break;
								//case "SELECTEDACCT":
								//	AccountList.SelectedItem = settingValue;
								//	break;
								case "UPLOADALLACCOUNTS":
									UploadALLAccounts.Checked = settingValueBool;
									break;
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
									userAgent.Text = settingValue;
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
								case "STOREPWSECURE":
									storePwSecurely.Checked = settingValueBool;
									break;
								case "CHECKEDSVLIST":
									checkedSVsFromSettings = settingValue.Split('|');
									break;
								case "CHECKEDADDONS":
									string[] cas = settingValue.Split('|');
									foreach (string ca in cas)
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
									if (addonAutoUpdate.Checked) { chAllowDelAddons.Enabled = true; }
									else { chAllowDelAddons.Enabled = false; }
									break;
								case "UUSETTINGSUPDATER":
									uuSettingsUpdater.Checked = settingValueBool;
									break;
								case "UUUPDATERCHECK":
									UUUpdaterCheck.Checked = settingValueBool;
									break;
								case "UUAUTOUPDATERCHECK":
									UUAutoUpdaterCheck.Checked = settingValueBool;
									break;
								case "SYNCHROURL":
									AutoAddonURL.Text = settingValue;
									break;
								case "UPDATESURL":
									UpdatesURL.Text = settingValue;
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
									if (storePwSecurely.Checked) { valu2.Text = Decrypt(settingValue); }
									else{ valu2.Text = settingValue; }
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
								case "CLOSETOSYSTRAY":
									CloseToSysTray.Checked = settingValueBool;
									break;
								case "DELAYUPLOAD":
									delaych.Checked = settingValueBool;
									break;
								case "DELAYSECONDS":
									DelaySecs.Text = settingValue;
									break;
								case "UPERRPOPUP":
									cbUpErrorPop.Checked = settingValueBool;
									break;
								case "CLOSEAFUPD":
									cbCloseAfterUpdates.Checked = settingValueBool;
									break;
								case "CLOSEAFLAU":
									cbCloseAfterWowLaunch.Checked = settingValueBool;
									break;
								case "AUTOSYNCIN":
									nudAutoSyncInterval.Value = Decimal.Parse(settingValue);
									break;
								case "USEAPPDATA":
									cbAppData.Checked = settingValueBool;
									break;
								case "AUTOLAUNCHTIMER":
									autoLaunchTimer = Convert.ToInt32(settingValue);
									break;
								case "UUTIMEOUT":
									UUTimeOut = Convert.ToInt32(settingValue);
									break;
								case "GUILDNAME":
									GuildName = settingValue;
									if (GuildName != "") // Only alter the title/systray text if theres an actual setting text to use
									{
										Text = GuildName + "UniUploader" + OfficerStr;
										notifyIcon1.Text = Text;
									}
									break;
								case "ENABLEOFFICERBUILD":
									EnableOfficerBuild = settingValueBool;
									break;
								case "OFFICERSTR":
									if (IsOfficerBuild)
									{
										OfficerStr = settingValue;
										if (OfficerStr != "") // Only alter the title/systray text if theres an actual setting text to use
										{
											Text = GuildName + "UniUploader" + OfficerStr;
											notifyIcon1.Text = Text;
										}
									}
									else
									{
										OfficerStr = "";
										Text = GuildName + "UniUploader" + OfficerStr;
										notifyIcon1.Text = Text;
									}
									break;
								case "MEMBERUUVAL":
									if (storePwSecurely.Checked) { MemberUUVal = Decrypt(settingValue); }
									else{ MemberUUVal = settingValue; }
									if (EnableOfficerBuild && !IsOfficerBuild)
									{
										if (MemberUUVal!="") { valu2.Text=MemberUUVal; }
									}
									break;
								case "OFFICERUUVAL":
									if (storePwSecurely.Checked) { OfficerUUVal = Decrypt(settingValue); }
									else{ OfficerUUVal = settingValue; }
									if (EnableOfficerBuild && IsOfficerBuild)
									{
										if (OfficerUUVal!="") { valu2.Text=OfficerUUVal; }
									}
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
				DebugLine("ReadSettings: " + e.Message);
				if (e.Message == "Object reference not set to an instance of an object.")
				{
					MessageBox.Show("Your settings file is somehow corrupted.\nPlease delete settings.ini or repair it.");
				}
				return;
			}
		}

// ----------------------------------------------

		private void WriteSettings()
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
					ini.AddCategory("custom");
					string checkedSvsFromList = ""; //delimited collection of checked SVs from the list
					int i = 0;
					foreach (string checkedSV in SVList.CheckedItems) //itterate through all checked files in the sv file list
					{
						if (i > 0)
						{
							checkedSvsFromList += "|" + checkedSV;
						}
						else
						{
							checkedSvsFromList += checkedSV;
						}
						i++;
					}

					string checkedAddonsFromList = ""; //delimited collection of checked Addons from the list
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
					#region AllSettings
					ini.AddValue("settings", "PRIMARYURL", URL.Text);
					//ini.AddValue("settings","AUTOPATH",AutoPath.Checked.ToString());
					ini.AddValue("settings", "WINDOWMODE", windowmode.Checked.ToString());
					ini.AddValue("settings", "SELECTEDACCT", AccountList.SelectedItem.ToString());
					ini.AddValue("settings", "UPLOADALLACCOUNTS", UploadALLAccounts.Checked.ToString());
					ini.AddValue("settings", "FILELOCATION", mainSvLocation);
					ini.AddValue("settings", "PROGRAMMODE", ProgramMode);
					ini.AddValue("settings", "OPENGL", OpenGl.Checked.ToString());
					if (langselect.SelectedItem != null) { ini.AddValue("settings", "LANGUAGE", langselect.SelectedItem.ToString()); }
					ini.AddValue("settings", "EXELOC", wowExeLoc);
					ini.AddValue("settings", "AUTODETECTWOW", AutoInstallDirDetect.Checked.ToString());
					ini.AddValue("settings", "UPLOADSCREENSHOTS", cbInclScreenShots.Checked.ToString());
					ini.AddValue("settings", "UPLOADSVS", cbInclAddonData.Checked.ToString());

					ini.AddValue("updater", "ADDONAUTOUPDATE", addonAutoUpdate.Checked.ToString());
					ini.AddValue("updater", "UUSETTINGSUPDATER", uuSettingsUpdater.Checked.ToString());
					ini.AddValue("updater", "UUUPDATERCHECK", UUUpdaterCheck.Checked.ToString());
					ini.AddValue("updater", "UUAUTOUPDATERCHECK", UUAutoUpdaterCheck.Checked.ToString());
					ini.AddValue("updater", "SYNCHROURL", AutoAddonURL.Text);
					ini.AddValue("updater", "UPDATESURL", UpdatesURL.Text);
					ini.AddValue("updater", "ALLOWADDONDEL", chAllowDelAddons.Checked.ToString());
					ini.AddValue("updater", "AUTOSYNCIN", nudAutoSyncInterval.Value.ToString());
					ini.AddValue("updater", "AUTOLAUNCHTIMER", autoLaunchTimer.ToString());
					ini.AddValue("updater", "UUTIMEOUT", UUTimeOut.ToString());

					ini.AddValue("options", "SYSTRAY", checkBox1.Checked.ToString());
					ini.AddValue("options", "ALWAYSONTOP", checkBox6.Checked.ToString());
					ini.AddValue("options", "AUTOUPLOADONFILECHANGES", autoUploader.Checked.ToString());
					ini.AddValue("options", "ADDVAR1CH", arg1check.Checked.ToString());
					ini.AddValue("options", "ADDVAR2CH", arg2check.Checked.ToString());
					ini.AddValue("options", "ADDVAR3CH", arg3check.Checked.ToString());
					ini.AddValue("options", "ADDVAR4CH", arg4check.Checked.ToString());
					ini.AddValue("options", "ADDURL1CH", chaddurl1.Checked.ToString());
					ini.AddValue("options", "ADDURL2CH", chaddurl2.Checked.ToString());
					ini.AddValue("options", "ADDURL3CH", chaddurl3.Checked.ToString());
					ini.AddValue("options", "ADDURL4CH", chaddurl4.Checked.ToString());
					ini.AddValue("options", "ADDVARNAME1", arrg1.Text);
					ini.AddValue("options", "ADDVARNAME2", arrg2.Text);
					ini.AddValue("options", "ADDVARNAME3", arrg3.Text);
					ini.AddValue("options", "ADDVARNAME4", arrg4.Text);
					ini.AddValue("options", "ADDVARVAL1", valu1.Text);
					if (!EnableOfficerBuild)
					{
						if (storePwSecurely.Checked) { ini.AddValue("options", "ADDVARVAL2", Encrypt(valu2.Text)); }
						else{ ini.AddValue("options", "ADDVARVAL2", valu2.Text); }
					}
					else
					{
						if (IsOfficerBuild)
						{
							if (storePwSecurely.Checked) { ini.AddValue("options", "ADDVARVAL2", Encrypt(OfficerUUVal)); }
							else{ ini.AddValue("options", "ADDVARVAL2", OfficerUUVal); }
						}
						else
						{
							if (storePwSecurely.Checked) { ini.AddValue("options", "ADDVARVAL2", Encrypt(MemberUUVal)); }
							else{ ini.AddValue("options", "ADDVARVAL2", MemberUUVal); }
						}
					}
					ini.AddValue("options", "ADDVARVAL3", valu3.Text);
					ini.AddValue("options", "ADDVARVAL4", valu4.Text);
					ini.AddValue("options", "ADDURL1", addurl1.Text);
					ini.AddValue("options", "ADDURL2", addurl2.Text);
					ini.AddValue("options", "ADDURL3", addurl3.Text);
					ini.AddValue("options", "ADDURL4", addurl4.Text);
					if (userAgent.Text != UUuserAgent)
					{
						ini.AddValue("options", "USERAGENT", userAgent.Text);
					}
					ini.AddValue("options", "UPERRPOPUP", cbUpErrorPop.Checked.ToString());
					ini.AddValue("options", "CLOSEAFUPD", cbCloseAfterUpdates.Checked.ToString());
					ini.AddValue("options", "CLOSEAFLAU", cbCloseAfterWowLaunch.Checked.ToString());

					ini.AddValue("advanced", "GZIP", GZcompress.Checked.ToString());
					ini.AddValue("advanced", "RETRDATAFROMSITE", retrdatafromsite.Checked.ToString());
					ini.AddValue("advanced", "CHECKEDSVLIST", checkedSvsFromList);
					ini.AddValue("advanced", "CHECKEDADDONS", checkedAddonsFromList);
					//launch other program(s)
					ini.AddValue("advanced", "EXEUULAUNCH", exeOnUuStart.Checked.ToString());
					ini.AddValue("advanced", "EXEWOWLAUNCH", exeOnWowLaunch.Checked.ToString());
					ini.AddValue("advanced", "EXE1", exe1.Checked.ToString());
					ini.AddValue("advanced", "EXE2", exe2.Checked.ToString());
					ini.AddValue("advanced", "EXE3", exe3.Checked.ToString());
					ini.AddValue("advanced", "EXE1LOCATION", exe1Location.Text);
					ini.AddValue("advanced", "EXE2LOCATION", exe2Location.Text);
					ini.AddValue("advanced", "EXE3LOCATION", exe3Location.Text);
					ini.AddValue("advanced", "STARTWITHWINDOWS", stboot.Checked.ToString());
					ini.AddValue("advanced", "AUTOLAUNCHWOW", stwowlaunch.Checked.ToString());
					ini.AddValue("advanced", "STARTMINI", stmin.Checked.ToString());
					ini.AddValue("advanced", "CLOSETOSYSTRAY", CloseToSysTray.Checked.ToString());
					ini.AddValue("advanced", "DELAYUPLOAD", delaych.Checked.ToString());
					ini.AddValue("advanced", "DELAYSECONDS", DelaySecs.Text);
					ini.AddValue("advanced", "RETRDATAURL", retrDataUrl.Text);
					ini.AddValue("advanced", "SENDPWSECURE", sendPwSecurely.Checked.ToString());
					ini.AddValue("advanced", "STOREPWSECURE", storePwSecurely.Checked.ToString());
					ini.AddValue("advanced", "DOWNLOADBEFOREUPLOAD", chWtoWOWbeforeUpload.Checked.ToString());
					ini.AddValue("advanced", "DOWNLOADAFTERUPLOAD", chWtoWOWafterUpload.Checked.ToString());
					ini.AddValue("advanced", "DOWNLOADBEFOREWOWL", chWtoWOWbeforeWOWLaunch.Checked.ToString());
					ini.AddValue("advanced", "USELAUNCHER", chUseLauncher.Checked.ToString());
					ini.AddValue("advanced", "WEBWOWSVFILE", webWoWSvFile.Text);
					ini.AddValue("advanced", "WOWARGS", launchWoWargs.Text);
					ini.AddValue("advanced", "PURGEFIRST", purgefirstCh.Checked.ToString());
					ini.AddValue("advanced", "USEAPPDATA", cbAppData.Checked.ToString());

					ini.AddValue("custom", "GUILDNAME", GuildName);
					ini.AddValue("custom", "ENABLEOFFICERBUILD", EnableOfficerBuild.ToString());
					if (!EnableOfficerBuild) {
						ini.AddValue("custom", "OFFICERSTR", "");
						if (storePwSecurely.Checked) { ini.AddValue("custom", "MEMBERUUVAL", Encrypt("")); }
						else{ ini.AddValue("custom", "MEMBERUUVAL", ""); }
						if (storePwSecurely.Checked) { ini.AddValue("custom", "OFFICERUUVAL", Encrypt("")); }
						else{ ini.AddValue("custom", "OFFICERUUVAL", ""); }
						}
					else {
						ini.AddValue("custom", "OFFICERSTR", OfficerStr);
						if (storePwSecurely.Checked) { ini.AddValue("custom", "MEMBERUUVAL", Encrypt(MemberUUVal)); }
						else{ ini.AddValue("custom", "MEMBERUUVAL", MemberUUVal); }
						if (storePwSecurely.Checked) { ini.AddValue("custom", "OFFICERUUVAL", Encrypt(OfficerUUVal)); }
						else{ ini.AddValue("custom", "OFFICERUUVAL", OfficerUUVal); }
						}

					#endregion
					IniStructure.WriteIni(ini, WorkSpacePath + "\\settings.ini", "UniUploader initialization file \ngenerated by \n" + "Version : " + uniVersionMajor + "." + uniVersionMinor + "." + uniVersionBuild + "." + uniVersionRevision);
				}
			}
			catch (Exception e)
			{
				DebugLine("ReadSettings: " + e.Message);
				return;
			}
		}

// ----------------------------------------------

		private void UploadNowBtn_Click(object sender, System.EventArgs e)
		{
			if (!File.Exists(mainSvLocation))
			{
				MessageBox.Show(_HITBRS);
				return;
			}
			if (myTimer2.Enabled == false)
			{
				UploadNowBtn.Enabled = false;
				if (delaych.Checked)
				{
					myTimer.Interval = (Convert.ToInt16(DelaySecs.Text)) * 1000;
					myTimer.Enabled = true;
				}
				else
				{
					myTimer.Interval = 1000;
					myTimer.Enabled = true;
				}
			}
		}

// ----------------------------------------------

		private void populateAccountList()
		{
			string InstallPath = GetInstallPath();
			string[] Accounts = GetAccounts(InstallPath);
			if (Accounts == null)
			{
				AccountList.Items.Clear();
				AccountList.Items.Add(_NOACCFOUND);
				AccountList.SelectedIndex = 0;
				PathFound = false;
				AccountSelectLbl.Enabled = false;
				AccountList.Enabled = false;
			}
			else
			{
				string goodpath = InstallPath + "\\WTF\\Account";
				AccountList.Items.Clear();
				foreach (string Account in Accounts)
				{
					AccountList.Items.Add(Account);
				}
				AccountList.SelectedIndex = 0;
				PathFound = true;
				AccountSelectLbl.Enabled = true;
				if (UploadALLAccounts.Checked) { AccountList.Enabled = false; }
				else { AccountList.Enabled = true; }
				if (selectedAcc != "")
				{
					AccountList.SelectedItem = selectedAcc;
					selectedAcc = "";
				}
			}
		}

// ----------------------------------------------

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
					System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(exe, Arguments);
					//start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
					System.Diagnostics.Process.Start(start);
				}
				catch (Exception e)
				{
					DebugLine("LaunchWoW: " + e.Message);
				}
			}
			else
			{
				DebugLine(_WOWNOTFOUND);
			}
		}

// ----------------------------------------------

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// If we're set to ignore the Close 'X' button then just shrink to the SysTray
			if (CloseToSysTray.Checked && this.WindowState != FormWindowState.Minimized && !UpdateBypass) {
/*
				if (UpdateBypass) {
					this.notifyIcon1.Visible = false;
					WriteSettings();
					cleanUpTempFiles();
				}
*/
				this.WindowState = FormWindowState.Minimized;
				e.Cancel = true;
			}
			else {
				this.notifyIcon1.Visible = false;
				WriteSettings();
				cleanUpTempFiles();
			}
		}

// ----------------------------------------------

		private void cleanUpTempFiles()
		{
			string directory = WorkSpacePath;
			if (File.Exists(directory + "\\RespNotepad.tmp") == true) @File.Delete(directory + "\\RespNotepad.tmp");
			if (File.Exists(directory + "\\RespIE.tmp") == true) @File.Delete(directory + "\\RespIE.tmp");
			if (File.Exists(directory + "\\SiteSVNotepad.tmp") == true) @File.Delete(directory + "\\SiteSVNotepad.tmp");
			if (File.Exists(directory + "\\SiteSVIE.tmp") == true) @File.Delete(directory + "\\SiteSVIE.tmp");
		}

// ----------------------------------------------

		private string GetInstallPath()
		{
			if (AutoInstallDirDetect.Checked)
			{
				RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Blizzard Entertainment\\World of Warcraft");
				if (key != null)
				{
					if (key.GetValue("InstallPath") != null)
					{
						string drv = (string)key.GetValue("InstallPath");
						string wowDir = drv.Substring(0, drv.Length - 1);
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

// ----------------------------------------------

		private string browseWoWDir()
		{
			AutoInstallDirDetect.Checked = false;
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
						string accountDir = wowExeLoc + "\\WTF\\Account\\" + AccountList.SelectedItem;
						if (Directory.Exists(accountDir))
						{
							mainSvLocation = accountDir + "\\SavedVariables.lua";
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

// ----------------------------------------------

		private string InstallStartupKey()
		{
			try
			{
				string path;
				path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
				path = path.Replace("file:\\", "");
				RegistryKey rkHKLM = Registry.LocalMachine;
				RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
				if (key != null)
				{
					//we are in the registry, no probs so far
					if (key.GetValue("UniUploader") != null)
					{
						//key exists, check it
						string pathFromReg = (string)key.GetValue("UniUploader");
						if (pathFromReg != path + "\\UniUploader.exe")
						{
							//key is wrong, change it
							key.SetValue("UniUploader", path + "\\UniUploader.exe");
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
						key.SetValue("UniUploader", path + "\\UniUploader.exe");
						return _STVALCREATE;
					}
				}
				else
				{
					return _REGPROB;
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

// ----------------------------------------------

		private string UninstallStartupKey()
		{
			try
			{
				RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
				if (key != null)
				{
					//we are in the registry, no probs so far
					if (key.GetValue("UniUploader") != null)
					{
						//key exists, delete it
						key.DeleteValue("UniUploader", false);
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
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

// ----------------------------------------------

		private string[] GetAccounts(string InstallPath)
		{
			string goodpath = InstallPath + "\\WTF\\Account";
			if (Directory.Exists(goodpath))
			{
				DirectoryInfo di = new DirectoryInfo(goodpath);
				DirectoryInfo[] Accts = di.GetDirectories("*.*");
				int i = 0;
				string[] Accounts = new string[Accts.Length];
				foreach (DirectoryInfo Account in Accts)
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

// ----------------------------------------------

		public void OnChanged(object source, FileSystemEventArgs e)
		{
			if (autoUploader.Checked)
			{
				string filenameFromSVList = "";
				foreach (string checkedSV in SVList.CheckedItems)
				{
					filenameFromSVList = checkedSV + ".lua";
					if (e.Name.ToLower() == filenameFromSVList.ToLower() || filesysDelay_flag1 == true)
					{
						filesysDelay_flag1 = false;
						if (UploadNowBtn.Enabled == true && IsUploading == false && myTimer2.Enabled == false && windowstate != "starting")
						{
							UploadNowBtn.Enabled = false;
							DebugLine(_FILECHDET);
							if (delaych.Checked == true)
							{
								myTimer.Interval = (Convert.ToInt16(DelaySecs.Text)) * 1000;
								myTimer.Enabled = true;
							}
							else
							{
								myTimer.Interval = 1000;
								myTimer.Enabled = true;
							}
						}
					}
				}
			}
		}

// ----------------------------------------------

		public void newWatcherHandler(object source, FileSystemEventArgs e)
		{
			if (e.Name == "savedvariables")
			{
				filesysDelay_enabled = true;
			}
		}

// ----------------------------------------------

		private void UploadDelayTimerElapsed(object source, System.Timers.ElapsedEventArgs e)
		{
			if (UploadNowBtn.Enabled == false && windowstate != "starting")
			{
				myTimer.Enabled = false;
				Upload_Timer_Tick(null, new System.EventArgs());
			}
		}

// ----------------------------------------------

		private void myTimer2Tick(object source, System.Timers.ElapsedEventArgs e)
		{
			myTimer2.Enabled = false;
			IsUploading = false;
		}

// ----------------------------------------------

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			linkLabel1.LinkVisited = true;
			System.Diagnostics.Process.Start("mailto:Matt@MatthewMiller.info?subject=UniUploader");
		}

// ----------------------------------------------

		private void libLink_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			libLink.LinkVisited = true;
			System.Diagnostics.Process.Start("http://WoWRoster.net");
		}

// ----------------------------------------------

		private void linkLabel4_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			linkLabel4.LinkVisited = true;
			System.Diagnostics.Process.Start("http://www.wowroster.net/member26367/");
		}

// ----------------------------------------------

		private void linkLabel5_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			linkLabel5.LinkVisited = true;
			System.Diagnostics.Process.Start("mailto:calystos@virgin.net?subject=UniUploader");
		}

// ----------------------------------------------

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			if (windowstate != "min")
			{
				if (checkBox1.Checked == true)
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

// ----------------------------------------------

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			this.Show();
			this.TopLevel = true;
			this.WindowState = FormWindowState.Normal;
			this.Activate();
		}

// ----------------------------------------------

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (checkBox1.Checked == false)
			{
				notifyIcon1.Visible = false;
				this.ShowInTaskbar = true;
			}
			else
			{
				notifyIcon1.Visible = true;
				this.ShowInTaskbar = false;
			}
		}

// ----------------------------------------------

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			UploadNowBtn.Enabled = false;
			job = new ThreadStart(upload);
			UploadThread = new Thread(job);
			UploadThread.Name = "Upload Thread";
			UploadThread.Start();
		}

// ----------------------------------------------

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			//Show();
			WindowState = FormWindowState.Maximized;
			//this.BringToFront();
		}

// ----------------------------------------------

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			// If we're set to minimize, then make sure its minimized before we attempt to close
			if (CloseToSysTray.Checked && this.WindowState != FormWindowState.Minimized) {
				this.WindowState = FormWindowState.Minimized;
				}
			this.Close();
		}

// ----------------------------------------------

		private void AccountList_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			setupWatchers();
			populateSvList();
		}

// ----------------------------------------------

		private void arg1check_CheckedChanged(object sender, System.EventArgs e)
		{
			if (arrg1.Enabled == false)
			{
				arrg1.Enabled = true;
				valu1.Enabled = true;
				arg2check.Checked = true;
			}
			else
			{
				arrg1.Enabled = false;
				valu1.Enabled = false;
				arg2check.Checked = false;
			}
		}

// ----------------------------------------------

		private void arg2check_CheckedChanged(object sender, System.EventArgs e)
		{
			if (arrg2.Enabled == false)
			{
				arrg2.Enabled = true;
				valu2.Enabled = true;
				sendPwSecurely.Enabled = true;
				storePwSecurely.Enabled = true;
			}
			else
			{
				arrg2.Enabled = false;
				valu2.Enabled = false;
				sendPwSecurely.Enabled = false;
				storePwSecurely.Enabled = false;
			}
		}

// ----------------------------------------------

		private void arg3check_CheckedChanged(object sender, System.EventArgs e)
		{
			if (arrg3.Enabled == false) { arrg3.Enabled = true; valu3.Enabled = true; }
			else { arrg3.Enabled = false; valu3.Enabled = false; }
		}

// ----------------------------------------------

		private void arg4check_CheckedChanged(object sender, System.EventArgs e)
		{
			if (arrg4.Enabled == false) { arrg4.Enabled = true; valu4.Enabled = true; }
			else { arrg4.Enabled = false; valu4.Enabled = false; }
		}

// ----------------------------------------------

		private void SettingsBtn_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Text = _HELP1;
		}

// ----------------------------------------------

		private void OptionsBtn_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Text = _HELP2;
		}

// ----------------------------------------------

		private void AdvancedBtn_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Text = _HELP3;
		}

// ----------------------------------------------

		private void InfoBtn_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Text = _HELP4;
		}

// ----------------------------------------------

		private void checkBox6_CheckedChanged(object sender, System.EventArgs e)
		{
			if (windowstate != "starting")
			{
				if (checkBox6.Checked == true) { MainForm.ActiveForm.TopMost = true; }
				else { MainForm.ActiveForm.TopMost = false; }
			}
		}

// ----------------------------------------------

		private void chaddurl1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chaddurl1.Checked) { addurl1.Enabled = true; }
			else { addurl1.Enabled = false; }
		}

// ----------------------------------------------

		private void chaddurl2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chaddurl2.Checked) { addurl2.Enabled = true; }
			else { addurl2.Enabled = false; }
		}

// ----------------------------------------------

		private void chaddurl3_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chaddurl3.Checked) { addurl3.Enabled = true; }
			else { addurl3.Enabled = false; }
		}

// ----------------------------------------------

		private void chaddurl_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chaddurl4.Checked) { addurl4.Enabled = true; }
			else { addurl4.Enabled = false; }
		}

// ----------------------------------------------

		private void retrdatafromsite_CheckedChanged(object sender, System.EventArgs e)
		{
			if (retrdatafromsite.Checked)
			{
				purgefirstCh.Enabled = true;
				retrDataUrl.Enabled = true;
				chWtoWOWafterUpload.Enabled = true;
				chWtoWOWbeforeWOWLaunch.Enabled = true;
				btnWtoWOWDownload.Enabled = true;
				chWtoWOWbeforeUpload.Enabled = true;
				webToWowLbl.Enabled = true;
				webWoWSvFile.Enabled = true;
			}
			else
			{
				purgefirstCh.Enabled = false;
				retrDataUrl.Enabled = false;
				chWtoWOWafterUpload.Enabled = false;
				chWtoWOWbeforeWOWLaunch.Enabled = false;
				btnWtoWOWDownload.Enabled = false;
				chWtoWOWbeforeUpload.Enabled = false;
				webToWowLbl.Enabled = false;
				webWoWSvFile.Enabled = false;
			}
		}

// ----------------------------------------------

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
			string newdataArray = DataWriteAs.Text + @" = """ + newResult + @"""" + newLine;
			byte[]  finalArray = new UTF8Encoding().GetBytes(newdataArray); //i think its UTF8 default?
			using (FileStream inFile = new FileStream(FileLocation.Text, FileMode.Append))
			{
				inFile.Write(finalArray,0,finalArray.Length);
				inFile.Close();
			}
			*/
			byte[] finalArray = new UTF8Encoding().GetBytes(data + "\n"); //i think its UTF8 default?
			using (FileStream inFile = new FileStream(file, FileMode.Append))
			{
				inFile.Write(finalArray, 0, finalArray.Length);
				inFile.Close();
			}
		}

// ----------------------------------------------

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

// ----------------------------------------------

		private void stwowlaunch_CheckedChanged(object sender, System.EventArgs e)
		{
			if (stwowlaunch.Checked)
			{
				//stboot.Checked = false;
			}
		}

// ----------------------------------------------

		private void mini_timer_Tick(object sender, System.EventArgs e)
		{
			mini_timer.Stop();
			Hide();
		}

// ----------------------------------------------

		private void Upload_Timer_Tick(object sender, System.EventArgs e)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Upload_Timer.Stop();
			UploadNowBtn.Enabled = false;
			//ThreadStart job = new ThreadStart(upload);
			//Thread thread = new Thread(job);
			job = new ThreadStart(upload);
			UploadThread = new Thread(job);
			UploadThread.Name = "Upload Thread";
			UploadThread.Start();
			//public ThreadStart job;// = new ThreadStart(upload);
			//public Thread UploadThread;// = new Thread(job);
		}

// ----------------------------------------------

		private void wowlaunch_Click(object sender, System.EventArgs e)
		{
			if (exeOnWowLaunch.Checked)
			{
				LaunchEXEs();
			}
			LaunchWoWWait();
		}

// ----------------------------------------------

		public void LaunchEXEs()
		{
			if (exe1.Checked)
			{
				if (File.Exists(exe1Location.Text))
				{
					DebugLine("Launching: " + exe1Location.Text);
					LaunchEXE(exe1Location.Text, null);
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
					LaunchEXE(exe2Location.Text, null);
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
					LaunchEXE(exe3Location.Text, null);
				}
				else
				{
					DebugLine("EXE3 location invalid");
				}
			}
		}

// ----------------------------------------------

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

// ----------------------------------------------

		private void close_timer_Tick(object sender, System.EventArgs e)
		{
			if (components != null)
			{
				components.Dispose();
			}
			base.Dispose(true);
		}

// ----------------------------------------------

		private void addonAutoUpdate_CheckedChanged(object sender, System.EventArgs e)
		{
			if (addonAutoUpdate.Checked) { chAllowDelAddons.Enabled = true; }
			else { chAllowDelAddons.Enabled = false; }

			if (addonAutoUpdate.Checked || uuSettingsUpdater.Checked) { autoAddonSyncNow.Enabled = true; AutoAddonURL.Enabled = true; SynchURLLbl.Enabled = true; }
			else { autoAddonSyncNow.Enabled = false; AutoAddonURL.Enabled = false; SynchURLLbl.Enabled = false; }

			if (UUUpdaterCheck.Checked || addonAutoUpdate.Checked || uuSettingsUpdater.Checked) { autoAddonSyncNow.Enabled = true; }
			else { autoAddonSyncNow.Enabled = false; }
		}

// ----------------------------------------------

		private void autoAddonSyncNow_Click(object sender, System.EventArgs e)
		{
			UserClickedNoUpdate = false;
			job = new ThreadStart(SyncNOW);
			UploadThread = new Thread(job);
			UploadThread.Name = "SyncThread";
			UploadThread.Start();
		}

// ----------------------------------------------

		private void SyncNOW()
		{
			if (UpdatesGoing) return;
			UpdatesGoing = true;
			setControlEnabled(UploadNowBtn, false);
			//UploadNowBtn.Enabled = false;
			setControlEnabled(autoAddonSyncNow, false);
			//autoAddonSyncNow.Enabled = false;
			if (UUUpdaterCheck.Checked)
			{
				//statusBarPanel1.Text = _CHUUUPDATE;
				SetStatusBarPanelText(statusBarPanel1, _CHUUUPDATE);
				if (!TEST_VERSION)
					CheckForUpdates();
				if (!updating)
				{
					checkLangFile();
					checkChLogFile();
					//statusBarPanel1.Text = _READY;
					SetStatusBarPanelText(statusBarPanel1, _READY);
				}
			}
			if (!updating)
			{
				if (uuSettingsUpdater.Checked)
				{
					SetStatusBarPanelText(statusBarPanel1, _CHECKSET);
					UpdateUUSettings();
					SetStatusBarPanelText(statusBarPanel1, _READY);
				}
				if (addonAutoUpdate.Checked)
				{
					SetStatusBarPanelText(statusBarPanel1, _UPDWOWADDON);
					UpdateAddons();
					if (chAllowDelAddons.Checked)
					{
						deleteSpecifiedAddons();
					}
					DebugLine(_ADDONSUPD);
					SetStatusBarPanelText(statusBarPanel1, _READY);
					//statusBarPanel1.Text = _READY;
				}
				setControlEnabled(UploadNowBtn, true);
				if (uuSettingsUpdater.Checked || addonAutoUpdate.Checked || UUUpdaterCheck.Checked)
				{
					setControlEnabled(autoAddonSyncNow, true);
				}
				if (retrdatafromsite.Checked)
				{
					doWebsiteToWow();
				}
				windowstate = "";
			}
			UpdatesGoing = false;
			//UploadThread.Abort();
			if (cbCloseAfterUpdates.Checked)
			{
				closeWait();
			}
		}

// ----------------------------------------------

		private bool UpdatesGoing = false;

// ----------------------------------------------

		private string WorkSpacePath
		{
			get
			{
				if (cbAppData.Checked)
				{
					return Application.UserAppDataPath;
				}
				else
				{
					return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
				}
			}
		}

// ----------------------------------------------

		public string WriteAddonXmlFile(string DATA)
		{
			string path;
			path = WorkSpacePath;
			DirectoryInfo di = new DirectoryInfo(path);
			FileInfo[] rgFiles = di.GetFiles("unisettings.ini");
			if (rgFiles.GetLength(0) > 0)
			{
				File.Delete(path + "\\AddonList.xml");
			}
			try
			{
				FileStream file = new FileStream(path + "\\AddonList.xml", FileMode.OpenOrCreate, FileAccess.Write);
				StreamWriter sw = new StreamWriter(file);
				sw.Write(DATA);
				sw.Close();
				file.Close();
			}
			catch (Exception e)
			{
				DebugLine("WriteAddonXmlFile: " + e.Message);
			}
			string XmlPath;
			XmlPath = WorkSpacePath;
			XmlPath = XmlPath + "\\AddonList.xml";
			return XmlPath;
		}

// ----------------------------------------------

		public string GetDateAndTime()
		{
			return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
		}

// ----------------------------------------------

		public void DebugLine(string Text)
		{
			string[] TextSplit = Text.Split(new Char[] { '\n' });
			foreach (string line in TextSplit)
			{
				//DebugBox.Items.Add("[" + GetDateAndTime() + "] " + line);
				ListBoxItemAdd(DebugBox, "[" + GetDateAndTime() + "] " + line);
			}
			int numLines = DebugBox.Items.Count;
			SetListBoxSelectedIndex(DebugBox, numLines - 1);
		}

// ----------------------------------------------

		public void DebugLines(string[] Text)
		{
			foreach (string line in Text)
			{
				//DebugBox.Items.Add("[" + GetDateAndTime() + "] " + line);
				ListBoxItemAdd(DebugBox, "[" + GetDateAndTime() + "] " + line);
			}
			int numLines = DebugBox.Items.Count;
			SetListBoxSelectedIndex(DebugBox, numLines - 1);
		}

// ----------------------------------------------

		public void DebugLines(string text)
		{
			string[] s = text.Split(new Char[] { '\n' });
			foreach (string line in s)
			{
				//DebugBox.Items.Add("[" + GetDateAndTime() + "] " + line);
				ListBoxItemAdd(DebugBox, "[" + GetDateAndTime() + "] " + line);
			}
			int numLines = DebugBox.Items.Count;
			SetListBoxSelectedIndex(DebugBox, numLines - 1);
		}

// ----------------------------------------------

		private void menuItem2_Click_1(object sender, System.EventArgs e)
		{
			LaunchWoWWait();
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
			catch (Exception e)
			{
				DebugLine("FileToByteArray: " + e.Message);
				return null; //the file possibly does not exist
			}
		}

// ----------------------------------------------

		private void uuSettingsUpdater_CheckedChanged(object sender, System.EventArgs e)
		{
			if (uuSettingsUpdater.Checked || addonAutoUpdate.Checked) { autoAddonSyncNow.Enabled = true; AutoAddonURL.Enabled = true; }
			else { autoAddonSyncNow.Enabled = false; AutoAddonURL.Enabled = false; }

			if (UUUpdaterCheck.Checked) { autoAddonSyncNow.Enabled = true; }
		}

// ----------------------------------------------

		private void UUUpdaterCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (UUUpdaterCheck.Checked) { updateCheckBtn.Enabled = true; UpdatesURL.Enabled = true; UpdURLLbl.Enabled = true; UUAutoUpdaterCheck.Enabled = true; }
			else { updateCheckBtn.Enabled = false; UpdatesURL.Enabled = false; UpdURLLbl.Enabled = false; UUAutoUpdaterCheck.Enabled = false; }

			if (uuSettingsUpdater.Checked || addonAutoUpdate.Checked) { autoAddonSyncNow.Enabled = true; }
			else { autoAddonSyncNow.Enabled = false; }
		}

// ----------------------------------------------

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
				DebugLine("RemoveReadOnly: " + excpt.Message);
			}
		}

// ----------------------------------------------

		private delegate void UpdateUUSettingsDelegate();

// ----------------------------------------------

		public void UpdateUUSettings()
		{
			if (this.InvokeRequired)
			{
				UpdateUUSettingsDelegate dele = new UpdateUUSettingsDelegate(UpdateUUSettings2);
				this.Invoke(dele);
			}
			else
			{
				UpdateUUSettings2();
			}

		}

// ----------------------------------------------

		public bool ChkTrueFalse(string ChkStr)
		{
			if (ChkStr == "1") { return true; }
			else { return false; }
		}

// ----------------------------------------------

		public void UpdateUUSettings2()
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
				UpdateQueryResponse = RetrData(synchroUrl, null, null, "OPERATION", "GETSETTINGS", arrg1.Text, valu1.Text, arrg2.Text, value2, -1, null, null);
			}
			else
			{
				UpdateQueryResponse = RetrData(synchroUrl, null, null, "OPERATION", "GETSETTINGS", null, null, null, null, -1, null, null);
			}
			string uaVersion = RetrData(synchroUrl, null, null, "OPERATION", "GETUAVER", null, null, null, null, -1, null, null);
			bool oldDelims = true;
			if (uaVersion != "UniUploader Update Interface Ready..." && uaVersion != "")
			{
				oldDelims = false;
			}
			string[] settings;
			if (!oldDelims)
			{
				settings = Regex.Split(UpdateQueryResponse, "\\[\\|\\]");
			}
			else
			{
				settings = UpdateQueryResponse.Split('|');
			}
			string[] settingSplit = { "", "" };
			foreach (string setting in settings)
			{
				if (!oldDelims)
				{
					settingSplit = Regex.Split(setting, "\\[\\=\\]");
				}
				else
				{
					settingSplit = setting.Split('=');
				}
				try
				{
					switch (settingSplit[0].ToUpper())
					{
						#region cases

						case "HOMEURL":
							doHomeURL(settingSplit[1]);
							break;
						case "FORUMURL":
							doForumURL(settingSplit[1]);
							break;
						case "ROSTERURL":
							doRosterURL(settingSplit[1]);
							break;
						case "UNIADMINURL":
							doUniAdminURL(settingSplit[1]);
							break;
						case "UPLOADALLACCOUNTS":
							UploadALLAccounts.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "UPLOADSCREENSHOTS":
							cbInclScreenShots.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "UPLOADSVS":
							cbInclAddonData.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "UPERRPOPUP":
							cbUpErrorPop.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "CLOSEAFUPD":
							cbCloseAfterUpdates.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "CLOSEAFLAU":
							cbCloseAfterWowLaunch.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "AUTOSYNCIN":
							nudAutoSyncInterval.Value = Decimal.Parse(settingSplit[1]);
							break;
						case "USEAPPDATA":
							cbAppData.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ALLOWADDONDEL":
							chAllowDelAddons.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "PURGEFIRST":
							purgefirstCh.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "AUTODETECTWOW":
							AutoInstallDirDetect.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "USELAUNCHER":
							chUseLauncher.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "LANGUAGE":
							Language = settingSplit[1];
							PopulateLanguageSelector();
							break;
						case "DOWNLOADAFTERUPLOAD":
							chWtoWOWafterUpload.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "DOWNLOADBEFOREUPLOAD":
							chWtoWOWbeforeUpload.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "DOWNLOADBEFOREWOWL":
							chWtoWOWbeforeWOWLaunch.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "WEBWOWSVFILE":
							webWoWSvFile.Text = settingSplit[1];
							break;
						case "USERAGENT":
							userAgent.Text = settingSplit[1];
							break;
						case "SENDPWSECURE":
							sendPwSecurely.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "STOREPWSECURE":
							storePwSecurely.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "PROGRAMMODE":
							if (settingSplit[1] == "Advanced")
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
							URL.Text = settingSplit[1];
							break;
						case "SVLIST":
							setSVlist(UpdateQueryResponse);
							break;
						case "LOGO1":
							doLogos(settingSplit[1]);
							//updateLogo(settingSplit[1]);
							break;
						case "LOGO2":
							doLogos(settingSplit[1]);
							//updateLogo(settingSplit[1]);
							break;
						case "RETRDATAURL":
							retrDataUrl.Text = settingSplit[1];
							break;
						case "ADDONAUTOUPDATE":
							addonAutoUpdate.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "UUSETTINGSUPDATER":
							uuSettingsUpdater.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "UUUPDATERCHECK":
							if (!TEST_VERSION)
							{
								UUUpdaterCheck.Checked = ChkTrueFalse(settingSplit[1]);
							}
							break;
						case "UUAUTOUPDATERCHECK":
							if (!TEST_VERSION)
							{
								UUAutoUpdaterCheck.Checked = ChkTrueFalse(settingSplit[1]);
							}
							break;
						case "SYNCHROURL":
							AutoAddonURL.Text = settingSplit[1];
							break;
						case "UPDATESURL":
							UpdatesURL.Text = settingSplit[1];
							break;
						case "SYSTRAY":
							checkBox1.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ALWAYSONTOP":
							// checkBox6.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "AUTOUPLOADONFILECHANGES":
							autoUploader.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ADDVAR1CH":
							arg1check.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ADDVAR2CH":
							arg2check.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ADDVAR3CH":
							arg3check.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ADDVAR4CH":
							arg4check.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ADDURL1CH":
							chaddurl1.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ADDURL2CH":
							chaddurl2.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ADDURL3CH":
							chaddurl3.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ADDURL4CH":
							chaddurl4.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "ADDVARNAME1":
							arrg1.Text = settingSplit[1];
							break;
						case "ADDVARNAME2":
							arrg2.Text = settingSplit[1];
							break;
						case "ADDVARNAME3":
							arrg3.Text = settingSplit[1];
							break;
						case "ADDVARNAME4":
							arrg4.Text = settingSplit[1];
							break;
						case "ADDVARVAL1":
							valu1.Text = settingSplit[1];
							break;
						case "ADDVARVAL2":
							valu2.Text = settingSplit[1];
							break;
						case "ADDVARVAL3":
							valu3.Text = settingSplit[1];
							break;
						case "ADDVARVAL4":
							valu4.Text = settingSplit[1];
							break;
						case "ADDURL1":
							addurl1.Text = settingSplit[1];
							break;
						case "ADDURL2":
							addurl2.Text = settingSplit[1];
							break;
						case "ADDURL3":
							addurl3.Text = settingSplit[1];
							break;
						case "ADDURL4":
							addurl4.Text = settingSplit[1];
							break;
						case "GZIP":
							GZcompress.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "RETRDATAFROMSITE":
							if (settingSplit[1] == "1")
							{
								retrdatafromsite.Checked = true;
								retrDataUrl.Enabled = true;
								chWtoWOWafterUpload.Enabled = true;
								chWtoWOWbeforeWOWLaunch.Enabled = true;
								btnWtoWOWDownload.Enabled = true;
								chWtoWOWbeforeUpload.Enabled = true;
								webToWowLbl.Enabled = true;
								webWoWSvFile.Enabled = true;
							}
							else
							{
								retrdatafromsite.Checked = false;
								retrDataUrl.Enabled = false;
								chWtoWOWafterUpload.Enabled = false;
								chWtoWOWbeforeWOWLaunch.Enabled = false;
								btnWtoWOWDownload.Enabled = false;
								chWtoWOWbeforeUpload.Enabled = false;
								webToWowLbl.Enabled = false;
								webWoWSvFile.Enabled = false;
							}
							break;
						case "WINDOWMODE":
							windowmode.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "STARTWITHWINDOWS":
							if (settingSplit[1] == "1")
							{
								stboot.Checked = true;
								DebugLine(InstallStartupKey());
							}
							else
							{
								stboot.Checked = false;
								DebugLine(UninstallStartupKey());
							}
							break;
						case "AUTOLAUNCHWOW":
							stwowlaunch.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "STARTMINI":
							stmin.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "CLOSETOSYSTRAY":
							CloseToSysTray.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "DELAYUPLOAD":
							delaych.Checked = ChkTrueFalse(settingSplit[1]);
							break;
						case "DELAYSECONDS":
							DelaySecs.Text = settingSplit[1];
							break;
						case "AUTOLAUNCHTIMER":
							autoLaunchTimer = Convert.ToInt32(settingSplit[1]);
							break;
						case "UUTIMEOUT":
							UUTimeOut = Convert.ToInt32(settingSplit[1]);
							break;
						case "GUILDNAME":
							GuildName = settingSplit[1];
							if (GuildName != "") // Only alter the title/systray text if theres an actual setting text to use
							{
								GuildName = GuildName + " ";
								Text = GuildName + "UniUploader" + OfficerStr;
								notifyIcon1.Text = Text;
							}
							break;
						case "ENABLEOFFICERBUILD":
							EnableOfficerBuild = ChkTrueFalse(settingSplit[1]);
							break;
						case "OFFICERSTR":
							if (EnableOfficerBuild)
							{
								OfficerStr = settingSplit[1];
								if (OfficerStr != "") // Only alter the title/systray text if theres an actual setting text to use
								{
									OfficerStr = " " + OfficerStr;
									Text = GuildName + "UniUploader" + OfficerStr;
									notifyIcon1.Text = Text;
								}
							}
							else
							{
								OfficerStr = "";
								Text = GuildName + "UniUploader" + OfficerStr;
								notifyIcon1.Text = Text;
							}
							break;
						case "MEMBERUUVAL":
							MemberUUVal = settingSplit[1];
							if (EnableOfficerBuild && !IsOfficerBuild)
							{
								valu2.Text = MemberUUVal;
							}
							break;
						case "OFFICERUUVAL":
							OfficerUUVal = settingSplit[1];
							if (EnableOfficerBuild && IsOfficerBuild)
							{
								valu2.Text = OfficerUUVal;
							}
							break;
						default:
							break;
						#endregion
					}
				}
				catch (Exception e)
				{
					DebugLine("UpdateUUSettings: " + e.Message);
				}
			}
		}

// ----------------------------------------------

		private void doContextMenuMoveToBottom(string text)
		{
			foreach (MenuItem mi in contextMenu1.MenuItems)
			{
				if (mi.Text == text)
				{
					contextMenu1.MenuItems.RemoveAt(mi.Index);
					contextMenu1.MenuItems.Add(menuItem3);
				}
			}
		}

// ----------------------------------------------

		private void doHomeURL(string URL)
		{
			string text = "Guild Homepage";
			MenuItem homeMI = new MenuItem(text);
			homeMI.Tag = URL;
			homeMI.Click += new EventHandler(homeMI_Click);

			int i = -1;
			foreach (MenuItem mi in contextMenu1.MenuItems)
			{
				if (mi.Text == text)
				{
					i = mi.Index;
				}
			}
			if (i != -1)
			{
				contextMenu1.MenuItems.RemoveAt(i);
				contextMenu1.MenuItems.Add(homeMI);
			}
			else
			{
				contextMenu1.MenuItems.Add(homeMI);
			}
			// Put the Exit option at the BOTTOM of the list!
			doContextMenuMoveToBottom("Exit");
		}

// ----------------------------------------------

		void homeMI_Click(object sender, EventArgs e)
		{
			string url = (string)((MenuItem)sender).Tag;
			System.Diagnostics.Process.Start(url);
		}

// ----------------------------------------------

		void forumMI_Click(object sender, EventArgs e)
		{
			string url = (string)((MenuItem)sender).Tag;
			System.Diagnostics.Process.Start(url);
		}

// ----------------------------------------------

		private void doForumURL(string URL)
		{
			string text = "Guild Forum";
			MenuItem homeMI = new MenuItem(text);
			homeMI.Tag = URL;
			homeMI.Click += new EventHandler(forumMI_Click);

			int i = -1;
			foreach (MenuItem mi in contextMenu1.MenuItems)
			{
				if (mi.Text == text)
				{
					i = mi.Index;
				}
			}
			if (i != -1)
			{
				contextMenu1.MenuItems.RemoveAt(i);
				contextMenu1.MenuItems.Add(homeMI);
			}
			else
			{
				contextMenu1.MenuItems.Add(homeMI);
			}
			// Put the Exit option at the BOTTOM of the list!
			doContextMenuMoveToBottom("Exit");
		}

// ----------------------------------------------

		private void doRosterURL(string URL)
		{
			string text = "Guild Roster";
			MenuItem homeMI = new MenuItem(text);
			homeMI.Tag = URL;
			homeMI.Click += new EventHandler(rosterMI_Click);

			int i = -1;
			foreach (MenuItem mi in contextMenu1.MenuItems)
			{
				if (mi.Text == text)
				{
					i = mi.Index;
				}
			}
			if (i != -1)
			{
				contextMenu1.MenuItems.RemoveAt(i);
				contextMenu1.MenuItems.Add(homeMI);
			}
			else
			{
				contextMenu1.MenuItems.Add(homeMI);
			}
			// Put the Exit option at the BOTTOM of the list!
			doContextMenuMoveToBottom("Exit");
		}

// ----------------------------------------------

		void rosterMI_Click(object sender, EventArgs e)
		{
			string url = (string)((MenuItem)sender).Tag;
			System.Diagnostics.Process.Start(url);
		}

// ----------------------------------------------

		private void doUniAdminURL(string URL)
		{
			string text = "Guild UniAdmin";
			MenuItem homeMI = new MenuItem(text);
			homeMI.Tag = URL;
			homeMI.Click += new EventHandler(uniadminMI_Click);

			int i = -1;
			foreach (MenuItem mi in contextMenu1.MenuItems)
			{
				if (mi.Text == text)
				{
					i = mi.Index;
				}
			}
			if (i != -1)
			{
				contextMenu1.MenuItems.RemoveAt(i);
				contextMenu1.MenuItems.Add(homeMI);
			}
			else
			{
				contextMenu1.MenuItems.Add(homeMI);
			}
			// Put the Exit option at the BOTTOM of the list!
			doContextMenuMoveToBottom("Exit");
		}

// ----------------------------------------------

		void uniadminMI_Click(object sender, EventArgs e)
		{
			string url = (string)((MenuItem)sender).Tag;
			System.Diagnostics.Process.Start(url);
		}

// ----------------------------------------------

		private void setSVlist(string delimitedSettings)
		{
			//MessageBox.Show(delimitedSettings.ToString());
			int start = delimitedSettings.IndexOf("SVLIST[=]");
			//MessageBox.Show(start.ToString());
			int end = delimitedSettings.IndexOf("[=]", start + 9);
			//MessageBox.Show(end.ToString());
			string it = "";
			if (end == -1)
				it = delimitedSettings.Substring(start);
			else
				it = delimitedSettings.Substring(start, end - start);
			//	MessageBox.Show(it);
			string[] svs = Regex.Split(it, "\\[\\|\\]");
			for (int a = 0; a < SVList.Items.Count; a++)
			{
				for (int b = 0; b < svs.Length; b++)
				{
					string s = SVList.Items[a].ToString().ToUpper();
					string r = svs[b].ToUpper();
					//MessageBox.Show(s+" "+r);
					if (r.IndexOf("SVLIST[=]") > -1) r = r.Substring(9);
					if (s == r)
					{
						SVList.SetItemChecked(a, true);
					}
				}
			}
		}

// ----------------------------------------------

		private bool UserClickedNoUpdate = false;
		private bool UpdateBypass = false;

// ----------------------------------------------

		// Function to test whether the string has a letter in it or not
		public bool HasAlpha(String strToCheck)
		{
			return Regex.IsMatch(strToCheck, @".[a-zA-Z]+");
		}

// ----------------------------------------------

		public bool CheckVersion(String verToCheck)
		{
			if (HasAlpha(verToCheck))
			{ // Alpha digit found in version EG 0.0.0a and not 0.0.0, use old style version checker
				DebugLine("Version detected has alpha/numeric code running basic version checker.");

				if ((uniVersionMajor + "." + uniVersionMinor + "." + uniVersionBuild + "." + uniVersionRevision) != verToCheck && !UserClickedNoUpdate)
				{
					DebugLine("New UniUploader version detected");
					return true;
				}
			}
			else { // Version is fully numeric EG 0.0.0 and not 0.0.0a, use new style version checker
				DebugLine("Version detected has full numeric code, running advanced version checker.");

				Version v1 = new Version(uniVersionMajor + "." + uniVersionMinor + "." + uniVersionBuild + "." + uniVersionRevision), v2 = new Version(verToCheck);
				DebugLine("UniUploader Version: " + v1 + ", Update.php UniUploader Version: " + v2 + ".");
				if (v1 >= v2) { DebugLine("UniUploader is latest version"); return false; }
				else if (v1 < v2 && !UserClickedNoUpdate)
				{
					DebugLine("New UniUploader version detected");
					return true;
				}
			}

			DebugLine("UniUploader is latest version");
			return false;
		}

// ----------------------------------------------

		public void CheckForUpdates()
		{
			string UpdateQueryResponse = "";
			UpdateQueryResponse = RetrData(UpdatesURL.Text, null, null, "OPERATION", "CHECKUPDATES", null, null, null, null, UUTimeOut, null, null);
			char[] sep = { '|' };
			string[] Response = UpdateQueryResponse.Split(sep);
			if (Response[0] == "")
			{
				DebugLine("CheckForUpdates: " + "Update Search Timed out (20 second time limit)");
			}
			else
			{
				// Lets do some version comparison checks shall we
				if (CheckVersion(Response[0]) && !UserClickedNoUpdate)
				{
					if (UUAutoUpdaterCheck.Checked)
					{
						string UUPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
						//updater retrieval
						UpdateQueryResponse = RetrData(UpdatesURL.Text, null, null, "OPERATION", "GETUPDATERLATEST", null, null, null, null, -1, null, null);
						string fileName = GetfileNameFromURI(UpdateQueryResponse);
						string FileLocalLocation = UUPath + @"\" + fileName;
						statusBar1.Text = _DOWNUPD;

						download(UpdateQueryResponse, FileLocalLocation);
						SetProgressBarValue(progressBar1, 0);
						InvokeProgressBarUpdate(progressBar1);
						//progressBar1.Value = 0;
						//progressBar1.Update();
						//UpdateLanguagePack();
						//PopulateLanguageSelector();
						if (File.Exists(UUPath + "\\update.exe"))
						{
							updating = true;
							System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(UUPath + "\\update.exe", @"-uuver """ + uniVersionMajor + "." + uniVersionMinor + "." + uniVersionBuild + "." + uniVersionRevision + @""" -lang """ + Language + @"""");
							System.Diagnostics.Process.Start(start);
							UpdateBypass = true;
							CloseForm();
						}
						else
						{
							DebugLine(_UPDEXENOTFD);
						}
					}
					else if (MessageBox.Show(_CHANGES + @":
" + Response[1] + @"
" + _UPDYESNO, _NEWUPDAVAIL, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						string UUPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
						//updater retrieval
						UpdateQueryResponse = RetrData(UpdatesURL.Text, null, null, "OPERATION", "GETUPDATERLATEST", null, null, null, null, -1, null, null);
						string fileName = GetfileNameFromURI(UpdateQueryResponse);
						string FileLocalLocation = UUPath + @"\" + fileName;
						statusBar1.Text = _DOWNUPD;

						download(UpdateQueryResponse, FileLocalLocation);
						SetProgressBarValue(progressBar1, 0);
						InvokeProgressBarUpdate(progressBar1);
						//progressBar1.Value = 0;
						//progressBar1.Update();
						//UpdateLanguagePack();
						//PopulateLanguageSelector();
						if (File.Exists(UUPath + "\\update.exe"))
						{
							updating = true;
							System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(UUPath + "\\update.exe", @"-uuver """ + uniVersionMajor + "." + uniVersionMinor + "." + uniVersionBuild + "." + uniVersionRevision + @""" -lang """ + Language + @"""");
							System.Diagnostics.Process.Start(start);
							UpdateBypass = true;
							CloseForm();
						}
						else
						{
							DebugLine(_UPDEXENOTFD);
						}
					}
					else
					{
						UserClickedNoUpdate = true;
					}
				}
			}
		}

// ----------------------------------------------

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

// ----------------------------------------------

		private bool download(string path_download, string path_local)
		{
			UniUploader.http.Response Response = new UniUploader.http.Response();
			if (http.post(ref Response, path_download))
			{
				FileStream lFileStream = new FileStream(path_local, FileMode.Create);
				lFileStream.Write(Response.Content.ToArray(), 0, (int)Response.ContentLength);
				lFileStream.Close();
				return true;
			}
			else
			{
				if (cbUpErrorPop.Checked)
				{
					MessageBox.Show("Error - Check Debug Log");
				}
			}
			return false;
		}

// ----------------------------------------------

		public void updateLogo(string fileLocation)
		{
			try
			{
				string filename = GetfileNameFromURI(fileLocation);
				string UUPath = WorkSpacePath;
				string localFileLocation = UUPath + "\\" + filename;

				if (Path.GetFileName(fileLocation) == "logo1.png") {
					if (pictureBox1.Image != null) {
						pictureBox1.Visible = false;
						pictureBox1.Image.Dispose();
						File.Delete(UUPath + @"\logo1.png");
						}
					}
				else if (Path.GetFileName(fileLocation) == "logo1.gif") {
					if (pictureBox1.Image != null) {
						pictureBox1.Visible = false;
						pictureBox1.Image.Dispose();
						File.Delete(UUPath + @"\logo1.gif");
						}
					}
				else if (Path.GetFileName(fileLocation) == "logo1.jpg") {
					if (pictureBox1.Image != null) {
						pictureBox1.Visible = false;
						pictureBox1.Image.Dispose();
						File.Delete(UUPath + @"\logo1.jpg");
						}
					}

				if (Path.GetFileName(fileLocation) == "logo2.png") {
					if (pictureBox2.Image != null) {
						pictureBox2.Visible = false;
						pictureBox2.Image.Dispose();
						File.Delete(UUPath + @"\logo2.png");
						}
					}
				else if (Path.GetFileName(fileLocation) == "logo2.gif") {
					if (pictureBox2.Image != null) {
						pictureBox2.Visible = false;
						pictureBox2.Image.Dispose();
						File.Delete(UUPath + @"\logo2.gif");
						}
					}
				else if (Path.GetFileName(fileLocation) == "logo2.jpg") {
					if (pictureBox2.Image != null) {
						pictureBox2.Visible = false;
						pictureBox2.Image.Dispose();
						File.Delete(UUPath + @"\logo2.jpg");
						}
					}

				statusBarPanel1.Text = _DOWNLOADING + " " + filename;
				download(fileLocation, localFileLocation);
				//progressBar1.Value = 0;
				//progressBar1.Update();
				//SetProgressBarValue(progressBar1, 0);
				//InvokeProgressBarUpdate(progressBar1);

				if (File.Exists(UUPath + @"\" + filename) && filename == "logo1.png") {
					pictureBox1.Image = Image.FromFile(UUPath + @"\logo1.png");
					pictureBox1.Visible = true;
					}
				else if (File.Exists(UUPath + @"\" + filename) && filename == "logo1.gif") {
					pictureBox1.Image = Image.FromFile(UUPath + @"\logo1.gif");
					pictureBox1.Visible = true;
					}
				else if (File.Exists(UUPath + @"\" + filename) && filename == "logo1.jpg") {
					pictureBox1.Image = Image.FromFile(UUPath + @"\logo1.jpg");
					pictureBox1.Visible = true;
					}

				if (File.Exists(UUPath + @"\" + filename) && filename == "logo2.png") {
					pictureBox2.Image = Image.FromFile(UUPath + @"\logo2.png");
					pictureBox2.Visible = true;
					}
				else if (File.Exists(UUPath + @"\" + filename) && filename == "logo2.gif") {
					pictureBox2.Image = Image.FromFile(UUPath + @"\logo2.gif");
					pictureBox2.Visible = true;
					}
				else if (File.Exists(UUPath + @"\" + filename) && filename == "logo2.jpg") {
					pictureBox2.Image = Image.FromFile(UUPath + @"\logo2.jpg");
					pictureBox2.Visible = true;
					}
				}
			catch (Exception e)
			{
				DebugLine("updateLogo: " + e.Message);
			}
		}

// ----------------------------------------------

		private void debugSaveAs_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Text file|*.txt|Document|*.doc";
			saveFileDialog1.Title = _SAVLOG;
			saveFileDialog1.ShowDialog();
			if (saveFileDialog1.FileName != "")
			{
				// Saves the Image via a FileStream created by the OpenFile method.
				System.IO.FileStream fs =
					(System.IO.FileStream)saveFileDialog1.OpenFile();
				string[] DebugBoxArray = new string[DebugBox.Items.Count];
				DebugBox.Items.CopyTo(DebugBoxArray, 0);
				string DebugString = "";
				foreach (string line in DebugBoxArray)
				{
					DebugString = DebugString + line + "\r\n";
				}
				System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
				byte[] logByteArray = encoding.GetBytes(DebugString);
				fs.Write(logByteArray, 0, logByteArray.Length);
				fs.Close();
			}
		}

// ----------------------------------------------

		string GetfileNameFromURI(string uri)
		{
			//string[] splitUri = new string[];
			char[] sep = { '/' };
			string[] splitUri;
			splitUri = uri.Split(sep);
			return splitUri[splitUri.Length - 1];
		}

// ----------------------------------------------

		public int IndexOfI(string haystack, string needle)
		{
			int nIndex = System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(haystack, needle, System.Globalization.CompareOptions.IgnoreCase);
			return nIndex;
		}

// ----------------------------------------------

		public void UnzipAddon(string filename, ArrayList files)
		{
			DebugLine(_UNZIPPING);
			bool addon = false;
			foreach (string file in files)
			{
				string type1 = "Interface\\AddOns";
				string type2 = "Interface/AddOns";
				if (file.ToLower().IndexOf(type1.ToLower()) > -1 || file.ToLower().IndexOf(type2.ToLower()) > -1) addon = true;
			}
			ZipInputStream s = new ZipInputStream(File.OpenRead(filename));
			ZipEntry theEntry;
			bool pathIncluded = false;
			while ((theEntry = s.GetNextEntry()) != null)
			{
				string directoryName = "";
				pathIncluded = false;
				if (IndexOfI(theEntry.Name, @"Interface\\AddOns") > -1 || IndexOfI(theEntry.Name, @"Interface/AddOns") > -1) pathIncluded = true;
				if (pathIncluded && addon)
				{
					directoryName = GetInstallPath() + @"\" + Path.GetDirectoryName(theEntry.Name);
				}
				else if (addon && !pathIncluded)
				{
					directoryName = GetInstallPath() + "\\Interface\\AddOns\\" + Path.GetDirectoryName(theEntry.Name);
				}
				else if (!addon)
				{
					directoryName = GetInstallPath() + @"\" + Path.GetDirectoryName(theEntry.Name);
				}
				string fileName = Path.GetFileName(theEntry.Name);
				if (!Directory.Exists(directoryName))
				{
					DebugLine(_CREATINGDIR + " " + directoryName);
					Directory.CreateDirectory(directoryName);
				}
				if (fileName != String.Empty)
				{
					if (!isDisAllowedFileExtension(Path.GetExtension(fileName).ToLower()))
					{
						DebugLine(_WRITINGFILE + " " + directoryName + @"\" + fileName);
						FileStream streamWriter = File.Create(directoryName + @"\" + fileName);
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
						DebugLine(_UNLISTEDFILE + " " + directoryName + @"\" + fileName);
					}
				}
			}
			s.Close();
		}

// ----------------------------------------------

		private bool isDisAllowedFileExtension(string extension)
		{
			foreach (string fileTypeExt in fileBlacklist)
			{
				if (extension.ToLower() == fileTypeExt.ToLower())
					return true;
			}
			return false;
		}

// ----------------------------------------------

		string MD5SUM(byte[] FileOrText) //Output: String<-> Input: Byte[] //
		{
			try
			{
				return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(FileOrText)).Replace("-", "").ToLower();
			}
			catch
			{
				//DebugLine("MD5SUM: "+e.Message);
				return null; //the addon possibly does not exist
			}
		}

// ----------------------------------------------

		private void button5_Click(object sender, System.EventArgs e)
		{
			DebugBox.Items.Clear();
		}

// ----------------------------------------------

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
				UpdateQueryResponse = RetrData(URL, null, null, "OPERATION", "GETDELETEADDONS", arrg1.Text, valu1.Text, arrg2.Text, value2, -1, null, null);
			}
			else
			{
				UpdateQueryResponse = RetrData(URL, null, null, "OPERATION", "GETDELETEADDONS", null, null, null, null, -1, null, null);
			}
			DebugLine(_XMLPARS);
			if (UpdateQueryResponse == string.Empty) return;
			ArrayList addonsToCheck = new ArrayList();
			try
			{
				XmlDocument doc = new XmlDocument();
				/////////////////////////////////////
				///	Begin Reading the XML data ///
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
			catch (Exception ex)
			{
				DebugLine("deleteSpecifiedAddons: " + ex.Message);
			}
			string addonPath = GetInstallPath() + "\\Interface\\AddOns";
			try
			{
				DirectoryInfo addonDirInfo = new DirectoryInfo(addonPath);
				DirectoryInfo[] installedAddons = addonDirInfo.GetDirectories();
				foreach (DirectoryInfo installedAddonDir in installedAddons)
				{
					foreach (string addon in addonsToCheck)
					{
						//MessageBox.Show(installedAddonDir.Name.ToLower());
						if (installedAddonDir.Name.ToLower() == addon.ToLower())
						{
							Directory.Delete(installedAddonDir.FullName, true);
						}
					}
				}
			}
			catch (Exception ex)
			{
				DebugLine("deleteSpecifiedAddons: " + ex.Message);
			}
		}

// ----------------------------------------------

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
				UpdateQueryResponse = RetrData(URL, null, null, "OPERATION", "GETADDONLIST", arrg1.Text, valu1.Text, arrg2.Text, value2, -1, null, null);
			}
			else
			{
				UpdateQueryResponse = RetrData(URL, null, null, "OPERATION", "GETADDONLIST", null, null, null, null, -1, null, null);
			}
			//string[] UpdateList;
			int UpdateCount = 0;
			try
			{
				DebugLine(_XMLPARS);
				XmlDocument doc = new XmlDocument();
				/////////////////////////////////////
				///	Begin Reading the XML data ///
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
					foreach (Hashtable h in UpdateList)
					{
						DebugLine((string)h["name"]);
					}
					//DebugLines(UpdateList);
				}
				else
				{
					DebugLine(_NOADDONS);
				}
				int i = 0;
				foreach (Hashtable h in UpdateList)
				{
					i++;
					string status = _NOWUPD + " [ " + i + " / " + UpdateList.Count.ToString() + " ]  " + (string)h["name"];
					DebugLine("                                               ");
					DebugLine(status);
					SetStatusBarPanelText(statusBarPanel1, status);
					try
					{
						UpdateSingleAddon((string)h["name"], URL, (ArrayList)h["files"]);
					}
					catch (Exception e)
					{
						DebugLine("UpdateAddons: " + e.Message);
					}
					SetStatusBarPanelText(statusBarPanel1, _UPDWOWADDON);
				}
			}
			catch (Exception e)
			{
				DebugLine("UpdateAddons: " + e.Message);
			}
			if (UpdateCount > 0)
			{
				if (UpdateCount > 1)
				{
					DebugLine(UpdateCount + _ADDONSUPD);
				}
				else
				{
					DebugLine(UpdateCount + _ADDONUPD);
				}
			}
		}

// ----------------------------------------------

		public bool IsFileUpDated(string addonName, string ServerMd5Sum, string filename)
		{
			string md5sum;
			string LocalPath = GetInstallPath() + filename.Replace("/", @"\");
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

// ----------------------------------------------

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
				try { required = Node.Attributes.GetNamedItem("required").Value.ToString(); }
				catch { }
				string requiredoff = "1";
				try { requiredoff = Node.Attributes.GetNamedItem("requiredoff").Value.ToString(); }
				catch { }
				if (isAddonChecked(AddonName) || required == "1" || (requiredoff == "1" && IsOfficerBuild && EnableOfficerBuild))
				{
					Updated = true;
					foreach (XmlNode FileNode in Node)
					{
						md5 = FileNode.Attributes.GetNamedItem("md5sum").Value.ToString();
						FileName = FileNode.Attributes.GetNamedItem("name").Value.ToString();
						Updated = IsFileUpDated(AddonName, md5, FileName);
						files.Add(FileName);
						if (isDisAllowedFileExtension(Path.GetExtension(FileName).ToLower()))
						{
							DebugLine(_UNLISTEDFILE + " " + @"\" + FileName);
							Updated = true;
						}
						if (!Updated) { break; }
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

// ----------------------------------------------

		public void UpdateSingleAddon(string AddonName, string URL, ArrayList files)
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
				AddonRetrievalResponse = RetrData(URL, null, null, "OPERATION", "GETADDON", "ADDON", AddonName, arrg1.Text, valu1.Text, -1, arrg2.Text, value2);
			}
			else
			{
				AddonRetrievalResponse = RetrData(URL, null, null, "OPERATION", "GETADDON", "ADDON", AddonName, null, null, -1, null, null);
			}
			char[] sep = { '.' };
			//DebugLine(_ADDONRETRRESP);
			//DebugLine(AddonRetrievalResponse);
			//WebClient client = new  WebClient();
			string fileName = GetfileNameFromURI(AddonRetrievalResponse);
			DebugLine(_FILENAME + fileName);
			string zipFileLocalLocation = GetInstallPath() + @"\" + fileName;
			DebugLine("zipFileLocalLocation: " + zipFileLocalLocation);
			//client.DownloadFile(AddonRetrievalResponse,zipFileLocalLocation); //file saved
			DebugLine(_DOWNLOADING + ": " + AddonRetrievalResponse);
			download(AddonRetrievalResponse, zipFileLocalLocation);
			//SetProgressBarValue(progressBar1, 0);
			//InvokeProgressBarUpdate(progressBar1);
			//DebugLine(_UNZIPPING);
			UnzipAddon(zipFileLocalLocation, files);//file unzipped to WoW install folder (WoW folder\Interface\Addons\blahBlah
			DebugLine(_DELZIPFILE);
			File.Delete(zipFileLocalLocation);//dont need the zip file anymore
			DebugLine(_UPDFOR + AddonName + _ISCOMP);
		}

// ----------------------------------------------

		private void Mode_Click(object sender, System.EventArgs e)
		{
			SwitchMode();
		}

// ----------------------------------------------

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
																						// this.URLLbl,
																						this.UploadNowBtn,
																						this.showAddonsBtn,
																						//this.URL,
																						// this.AccountList,
																						//this.AccountSelectLbl,

																						this.togSVList
																					});
				this.groupBox15.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.stwowlaunch,
																						 this.stmin,
																						 this.stboot,
																						 this.CloseToSysTray});
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
																						//this.progressBar1,
																						this.configGroup,
																						this.pictureBox1,
																						this.wowlaunch,
																						this.showAddonsBtn,
																						//this.URLLbl,
																						this.UploadNowBtn,
																						// this.URL,
																						//this.AccountList,
																						//this.AccountSelectLbl,

																						this.togSVList
																					});
				this.groupBox9.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.stwowlaunch,
																						this.stmin,
																						this.stboot,
																						this.CloseToSysTray});
				this.vargrp.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.valu2,
																					 this.valu1,
																					 this.arg1check});
				this.About.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.copyrightInfoLabel,
																					this.groupBox2});
				arrg1.Location = new System.Drawing.Point(24, 16);
				valu1.Location = new System.Drawing.Point(64, 16);
				arrg2.Location = new System.Drawing.Point(24, 40);
				valu2.Location = new System.Drawing.Point(64, 40);
				ProgramMode = "Advanced";
				progressBar1.BringToFront();
			}
		}

// ----------------------------------------------

		public void PopulateLanguageSelector()
		{
			try
			{
				string file = findLangFile();
				if (File.Exists(file))
				{
					LanguageIni = IniStructure.ReadIni(file);
					string[] allCategories = LanguageIni.GetCategories();
					if (allCategories.Length > 0)
					{
						setControlEnabled(langselect, true);
						SetComboBoxSelectedItem(langselect, Language);
						ResetLangVars(Language);
					}
					else
					{
						setControlEnabled(langselect, false);
						SetComboBoxSelectedItem(langselect, "English");
					}
				}
				else
				{
					setControlEnabled(langselect, false);
				}
			}
			catch (Exception e)
			{
				DebugLines("PopulateLanguageSelector: " + e.Message);
				setControlEnabled(langselect, false);
			}
		}

// ----------------------------------------------

		private void langselect_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string file = WorkSpacePath + "\\languages.ini";
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

// ----------------------------------------------

		public void ResetLangVars(string Lang)
		{
			string file = WorkSpacePath + "\\languages.ini";
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
						string settingValue = LanguageIni.GetValue(category, key).Replace("<br>", '\n'.ToString());
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
							case "_ADDONS":
								_ADDONS = @settingValue;
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
							case "_UPALLACC":
								_UPALLACC = @settingValue;
								break;
							case "_UPSCRSHT":
								_UPSCRSHT = @settingValue;
								break;
							case "_UPSVS":
								_UPSVS = @settingValue;
								break;
							case "_SENDPWSECURELE":
								_SENDPWSECURELE = @settingValue;
								break;
							case "_STOREPWSECURE":
								_STOREPWSECURE = @settingValue;
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
							case "_CSIST":
								_CSIST = @settingValue;
								break;
							case "_AOT":
								_AOT = @settingValue;
								break;
							case "_AUOFC":
								_AUOFC = @settingValue;
								break;
							case "_UPERRPU":
								_UPERRPU = @settingValue;
								break;
							case "_CLAFUP":
								_CLAFUP = @settingValue;
								break;
							case "_CLAFWL":
								_CLAFWL = @settingValue;
								break;
							case "_SYSTICO":
								_SYSTICO = @settingValue;
								break;
							case "_USERAGENT":
								_USERAGENT = @settingValue;
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
							case "_AUTLU":
								_AUTLU = @settingValue;
								break;
							case "_SYNCHURL":
								_SYNCHURL = @settingValue;
								break;
							case "_UPDATESURL":
								_UPDATESURL = @settingValue;
								break;
							case "_SAPU":
								_SAPU = @settingValue;
								break;
							case "_SYNCHNOW":
								_SYNCHNOW = @settingValue;
								break;
							case "_UPDCHK":
								_UPDCHK = @settingValue;
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
							case "_USEAPPDATA":
								_USEAPPDATA = @settingValue;
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
							case "_MINLBL":
								_MINLBL = @settingValue;
								break;
							case "_ASILBL":
								_ASILBL = @settingValue;
								break;
							case "_CRTDBY":
								_CRTDBY = @settingValue;
								break;
							case "_UPTDBY":
								_UPTDBY = @settingValue;
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

// ----------------------------------------------

		private delegate void InitLanguageChangeDelegate();

// ----------------------------------------------

		public void InitLanguageChange()
		{
			InitLanguageChangeDelegate dele = new InitLanguageChangeDelegate(InitLanguageChange2);
			this.Invoke(dele);

		}

// ----------------------------------------------

		private void InitLanguageChange2()
		{
			populateContextMenu2();
			URLLbl.Text = _URLLABEL;
			AccountSelectLbl.Text = _SELACC;
			windowmode.Text = _WINMODE;
			wowlaunch.Text = _LAUNCHWOW;
			langLabel.Text = _LANG;
			Settings.Text = _SETTINGS;
			response.Text = _SERVRESP;
			FURfWLbl.Text = _UPLLABEL;
			servResponse.Text = _DATARESP1;
			retrdatawindow.Text = _DATARESP2;
			WebDataLbl.Text = _DATARESP3;
			Options.Text = _OPTIONS;
			groupBox1.Text = _MISC;
			checkBox1.Text = _SIST;
			checkBox6.Text = _AOT;
			autoUploader.Text = _AUOFC;
			cbUpErrorPop.Text = _UPERRPU;
			cbCloseAfterUpdates.Text = _CLAFUP;
			cbCloseAfterWowLaunch.Text = _CLAFWL;
			btnSysTrayIco.Text = _SYSTICO;
			userAlbl.Text = _USERAGENT;
			vargrp.Text = _ADDVARS;
			groupBox4.Text = _ADDURLS;
			wowAddons.Text = _UPDATER;
			groupBox11.Text = _AUTOUPD;
			addonAutoUpdate.Text = _KMAU;
			uuSettingsUpdater.Text = _KMCUSU;
			UUUpdaterCheck.Text = _CFUTU;
			UUAutoUpdaterCheck.Text = _AUTLU;
			SynchURLLbl.Text = _SYNCHURL;
			autoAddonSyncNow.Text = _SYNCHNOW;
			updateCheckBtn.Text = _UPDCHK;
			UpdURLLbl.Text = _UPDATESURL;
			addonSyncBtn.Text = _SYNCHNOW;
			groupBox12.Text = _WARN;
			WarnMsgLbl.Text = _WARNMSG;
			Debugger.Text = _DEBUGGER;
			Advanced.Text = _ADVANCED;
			groupBox5.Text = _ADVANCEDSETTINGS;
			GZcompress.Text = _GZIPLAB;
			cbAppData.Text = _USEAPPDATA;
			groupBox10.Text = _SITEWOW;
			retrdatafromsite.Text = _RETRDATA2;
			groupBox6.Text = _OTHEROPT;
			SecondsLbl.Text = _SECONDS;
			groupBox9.Text = _STOPTIONS;
			stboot.Text = _STWITHWIN;
			stwowlaunch.Text = _AUTOLCHWOW;
			stmin.Text = _STMINI;
			CloseToSysTray.Text = _CSIST;
			Help.Text = _HELP;
			SettingsBtn.Text = _SETT;
			OptionsBtn.Text = _OPTI;
			AdvancedBtn.Text = _ADV;
			InfoBtn.Text = _INFOZ;
			About.Text = _ABT;
			copyrightInfoLabel.Text = _CPY;
			UploadNowBtn.Text = _UPLOAD;
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
			UploadALLAccounts.Text = _UPALLACC;
			cbInclScreenShots.Text = _UPSCRSHT;
			cbInclAddonData.Text = _UPSVS;
			sendPwSecurely.Text = _SENDPWSECURELE;
			storePwSecurely.Text = _STOREPWSECURE;
			delaych.Text = _DELAYTHEUPLOAD;
			chWtoWOWbeforeWOWLaunch.Text = _BEFOREWOWLAUNCH;
			chWtoWOWbeforeUpload.Text = _BEFOREUPLOADING;
			chWtoWOWafterUpload.Text = _AFTERUPLOADING;
			webToWowLbl.Text = _SVFILETOWRITETO;
			btnWtoWOWDownload.Text = _DOWNLOADIT;
			chUseLauncher.Text = _USETHELAUNCHER;
			DebugInfoLbl.Text = _THEDEBUGINFO;
			btnLegal.Text = _THELICENSE;
			button6.Text = _EXPANDALL;
			button7.Text = _COLLAPSEALL;
			AddonsListLbl.Text = _THESEAREADDONS;
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
			ArgsLbl.Text = _ARRGS;
			configGroup.Text = _CONFIGG;
			groupBox8.Text = _ADDONS;
			groupBox3.Text = _SVBLS;
			chAllowDelAddons.Text = _ALLOWUAADDONDEL;
			AddonNameLbl.Text = _ADDONAME;
			AddonVerLbl.Text = _ADDOVERS;
			AddonTOCLbl.Text = _ADDOTOC;
			AddonDescLbl.Text = _ADDODESCRIP;
			purgefirstCh.Text = _PURGEFIRST;
			MinLbl.Text = _MINLBL;
			ASILbl.Text = _ASILBL;
			CreatedLbl.Text = _CRTDBY;
			UpdByLbl.Text = _UPTDBY;
		}

// ----------------------------------------------

		public void UpdateLanguagePack()
		{
			string UUPath = WorkSpacePath;
			//lang file retrieval
			string UpdateQueryResponse = RetrData(UpdatesURL.Text, null, null, "OPERATION", "GETLANGLATEST", null, null, null, null, -1, null, null);
			string fileName = GetfileNameFromURI(UpdateQueryResponse);
			string FileLocalLocation = UUPath + @"\" + fileName;
			SetStatusBarPanelText(statusBarPanel1, _DOWNLOADING + " languages.ini");
			download(UpdateQueryResponse, FileLocalLocation);
			//progressBar1.Value = 0;
			//SetProgressBarValue(progressBar1, 0);
			//progressBar1.Update();
			//InvokeProgressBarUpdate(progressBar1);
			ConvertTextFileFromNtoRN(FileLocalLocation);
		}

// ----------------------------------------------

		public void UpdateChangeLog()
		{
			string UUPath = WorkSpacePath;
			//lang file retrieval
			string UpdateQueryResponse = RetrData(UpdatesURL.Text, null, null, "OPERATION", "GETCHLOGLATEST", null, null, null, null, -1, null, null);
			string fileName = GetfileNameFromURI(UpdateQueryResponse);
			string FileLocalLocation = UUPath + @"\" + fileName;
			SetStatusBarPanelText(statusBarPanel1, _DOWNLOADING + " ChangeLog.txt");
			download(UpdateQueryResponse, FileLocalLocation);
			//progressBar1.Value = 0;
			//SetProgressBarValue(progressBar1, 0);
			//progressBar1.Update();
			//InvokeProgressBarUpdate(progressBar1);
			ConvertTextFileFromNtoRN(FileLocalLocation);
		}

// ----------------------------------------------

		public static byte[] StrToByteArray(string str)
		{
			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
			return encoding.GetBytes(str);
		}

// ----------------------------------------------

		private void siteToWowSaveas_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Text file|*.txt";
			//saveFileDialog1.Title = _SAVLOG;
			saveFileDialog1.ShowDialog();
			if (saveFileDialog1.FileName != "")
			{
				// Saves the Image via a FileStream created by the OpenFile method.
				System.IO.FileStream fs =
					(System.IO.FileStream)saveFileDialog1.OpenFile();
				System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
				byte[] BodyByteArray = encoding.GetBytes(retrdatawindow.Text);
				fs.Write(BodyByteArray, 0, BodyByteArray.Length);
				fs.Close();
			}
		}

// ----------------------------------------------

		private void servResponseSaveas_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Text file|*.txt";
			//saveFileDialog1.Title = _SAVLOG;
			saveFileDialog1.ShowDialog();
			if (saveFileDialog1.FileName != "")
			{
				// Saves the Image via a FileStream created by the OpenFile method.
				System.IO.FileStream fs =
					(System.IO.FileStream)saveFileDialog1.OpenFile();
				System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
				byte[] BodyByteArray = encoding.GetBytes(servResponse.Text);
				fs.Write(BodyByteArray, 0, BodyByteArray.Length);
				fs.Close();
			}
		}

// ----------------------------------------------

		private void ClearSiteWoW_Click(object sender, System.EventArgs e)
		{
			retrdatawindow.Clear();
		}

// ----------------------------------------------

		private void ClearServResp_Click(object sender, System.EventArgs e)
		{
			servResponse.Clear();
		}

// ----------------------------------------------

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

// ----------------------------------------------

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

// ----------------------------------------------

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

// ----------------------------------------------

		private void exeOnSrtart_CheckedChanged(object sender, System.EventArgs e)
		{
			exe1.Enabled = true;
			exe2.Enabled = true;
			exe3.Enabled = true;
		}

// ----------------------------------------------

		private void exeOnWowLaunch_CheckedChanged(object sender, System.EventArgs e)
		{
			exe1.Enabled = true;
			exe2.Enabled = true;
			exe3.Enabled = true;
		}

// ----------------------------------------------

		private void LaunchEXE(string EXELocation, string Arguments)
		{
			System.Diagnostics.ProcessStartInfo start = null;
			if (Arguments == null)
			{
				start = new System.Diagnostics.ProcessStartInfo(EXELocation);
			}
			else
			{
				start = new System.Diagnostics.ProcessStartInfo(EXELocation, Arguments);
			}
			start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
			System.Diagnostics.Process.Start(start);
		}

// ----------------------------------------------

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

// ----------------------------------------------

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

// ----------------------------------------------

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

// ----------------------------------------------

		private void respOpenNP_Click(object sender, System.EventArgs e)
		{
			string exe = getOpenWithApp(".txt");
			if (exe == "")
			{
				exe = "NOTEPAD.EXE";
			}
			runApp(servResponse.Text, exe, "RespNotepad.htm");
		}

// ----------------------------------------------

		private void respOpenIE_Click(object sender, System.EventArgs e)
		{
			runApp(servResponse.Text, "IEXPLORE.EXE", "RespNotepad.htm");
		}

// ----------------------------------------------

		private void respOpenNP2_Click(object sender, System.EventArgs e)
		{
			string exe = getOpenWithApp(".txt");
			if (exe == "")
			{
				exe = "NOTEPAD.EXE";
			}
			runApp(retrdatawindow.Text, exe, "SiteSVNotepad.htm");
		}

// ----------------------------------------------

		private void respOpenIE2_Click(object sender, System.EventArgs e)
		{
			runApp(retrdatawindow.Text, "IEXPLORE.EXE", "SiteSVIE.htm");
		}

// ----------------------------------------------

		private void populateSvList()
		{
			bool checkThem = false; //unchecked by default
			if (checkedSVsFromSettings != null) checkThem = false;
			SVList.Items.Clear();
			if (Directory.Exists(mainSvLocation.Replace(".lua", "")))
			{
				string[] svFiles = Directory.GetFiles(mainSvLocation.Replace(".lua", ""), "*.lua");
				for (int a = 0; a < svFiles.Length; a++)
				{
					if (a == 0) SVList.Items.Add("SavedVariables", false);
					SVList.Items.Add(Path.GetFileName(svFiles[a]).Replace(".lua", ""), checkThem);
				}
				if (checkedSVsFromSettings != null)
				{
					bool checkIt = false;
					for (int i = 0; i < SVList.Items.Count; i++)
					{
						foreach (string settingSV in checkedSVsFromSettings)
						{
							if (settingSV == (string)SVList.Items[i]) checkIt = true;
						}
						if (checkIt) SVList.SetItemChecked(i, true);
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

// ----------------------------------------------

		private void SVList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int a = 0;
			string delimited = "";
			foreach (string checkedItem in SVList.CheckedItems)
			{
				if (a > 0)
					delimited += "|" + checkedItem;
				else
					delimited = checkedItem;
				a++;
			}
			checkedSVsFromSettings = delimited.Split('|');
		}

// ----------------------------------------------

		private void togSVList_Click(object sender, System.EventArgs e)
		{
			if (MainForm.ActiveForm.Size.Width < 640)
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

// ----------------------------------------------

		private void btnTranslations_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(@"French - Gryndel, shan_aya
Deutsch - Nightreaver, SethDeBlade
Nederlands - TheAvenger@Al'Akir
Russian - NSentinel
Swedish - KaThogh", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
		}

// ----------------------------------------------

		private void clearSVFiles_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show(_WARNINGWILLCLEAR, _WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				string path = "";
				foreach (string checkedSV in SVList.CheckedItems)
				{
					if (checkedSV != "SavedVariables")
					{
						path = mainSvLocation.Replace(".lua", "") + @"\" + checkedSV + ".lua";
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

// ----------------------------------------------

		private void checkLangFile()
		{
			string serverMD5 = "";
			serverMD5 = RetrData(UpdatesURL.Text, null, null, "OPERATION", "GETLANGMD5", null, null, null, null, UUTimeOut, null, null);
			if (serverMD5 != "")
			{
				string path = WorkSpacePath + "\\languages.ini";
				string md5sum = "";
				if (File.Exists(path))
				{
					md5sum = MD5SUM(FileToByteArray(path));
					//DebugLine("MD5SUM of local languages.ini: " + md5sum);
				}
				if (md5sum != serverMD5)
				{
					UpdateLanguagePack();
					PopulateLanguageSelector();
				}
			}
		}

// ----------------------------------------------

		private void checkChLogFile()
		{
			string serverMD5 = "";
			serverMD5 = RetrData(UpdatesURL.Text, null, null, "OPERATION", "GETCHLOGMD5", null, null, null, null, UUTimeOut, null, null);
			if (serverMD5 != "")
			{
				string path = WorkSpacePath + "\\ChangeLog.txt";
				string md5sum = "";
				if (File.Exists(path))
				{
					md5sum = MD5SUM(FileToByteArray(path));
					//DebugLine("MD5SUM of local ChangeLog.txt: " + md5sum);
				}
				if (md5sum != serverMD5)
				{
					UpdateChangeLog();
				}
			}
		}

// ----------------------------------------------

		private void checkDefaultSVs()
		{
			for (int z = 0; z < SVList.Items.Count; z++)
			{
				foreach (string preset in presets)
				{
					if (preset == SVList.Items[z].ToString())
					{
						SVList.SetItemChecked(z, true);
					}
				}
			}
			//populate the checked sv list
			this.checkedSVsFromSettings = new string[SVList.CheckedItems.Count];
			for (int z = 0; z < SVList.CheckedItems.Count; z++)
			{
				this.checkedSVsFromSettings[z] = SVList.CheckedItems[z].ToString();
			}
		}

// ----------------------------------------------

		private void sortSVList()
		{
			string[,] svList = new string[SVList.Items.Count, 2];
			for (int i = 0; i < SVList.Items.Count; i++)
			{
				svList[i, 0] = SVList.Items[i].ToString();
				foreach (string checkedSV in SVList.CheckedItems)
				{
					if (checkedSV == svList[i, 0])
					{
						svList[i, 1] = "checked";
						break;
					}
					else
					{
						svList[i, 1] = "";
					}
				}
			}
			string buff = "";
			for (int index = 0; index < svList.Length / 2; index++)
			{
				for (int i = 0; i < svList.Length / 2; i++)
				{
					if (svList[index, 1] != "checked" && svList[i, 1] == "checked")
					{
						buff = svList[index, 0];
						svList[index, 0] = svList[i, 0];
						svList[index, 1] = "checked";
						svList[i, 0] = buff;
						svList[i, 1] = "";
					}
				}
			}
			if (svList.Length > 0)
			{
				SVList.Items.Clear();
				for (int i = svList.Length / 2 - 1; i >= 0; i--)
				{
					if (svList[i, 0] != "checked" && svList[i, 0] != "")
					{
						if (svList[i, 1] == "checked")
						{
							SVList.Items.Add(svList[i, 0], true);
						}
						else
						{
							SVList.Items.Add(svList[i, 0], false);
						}
					}
				}
			}
		}

// ----------------------------------------------

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
			runApp(contents, exe, "debug_notepad.txt");
		}

// ----------------------------------------------

		private void dbIEbtn_Click(object sender, System.EventArgs e)
		{
			string contents = "";
			foreach (string item in DebugBox.Items)
			{
				contents += item + "\r\n";
			}
			runApp(contents, "IEXPLORE.EXE", "debug_ie.txt");
		}

// ----------------------------------------------

		private void runApp(string contents, string program, string filename)
		{
			string file = WorkSpacePath + "\\" + filename;
			if (File.Exists(file) == true) @File.Delete(file);
			using (FileStream fs = File.Create(file))
			{
				byte[] info = new UTF8Encoding(true).GetBytes(contents);
				fs.Write(info, 0, info.Length);
			}
			System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(program, file);
			start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
			System.Diagnostics.Process.Start(start);
		}

// ----------------------------------------------

		private void filesysDelay_Tick(object sender, System.EventArgs e)
		{
			//filesysDelay.Enabled = false;
			if (filesysDelay_enabled)
			{
				filesysDelay_enabled = false;
				setupWatchers();
				populateSvList();
				filesysDelay_flag1 = true;
				OnChanged(this, new System.IO.FileSystemEventArgs(WatcherChangeTypes.Created, "", ""));
			}
		}

// ----------------------------------------------

		private void btnLegal_Click(object sender, System.EventArgs e)
		{
			showLicense(false);
		}

// ----------------------------------------------

		private bool showLicense(bool buttons)
		{
			string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
			string txtFilePath = exePath + "\\LICENSE.TXT";
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
			LaunchEXE(exe, txtFilePath);
			//runApp(servResponse.Text,exe,txtFilePath);
			return true;
		}

// ----------------------------------------------

		private string getOpenWithApp(string ext)
		{
			string keyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + ext + @"\OpenWithList";
			RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath);
			if (key != null)
			{
				if (key.GetValue("a") != null)
				{
					return (string)key.GetValue("a");
				}
			}
			return "";
		}

// ----------------------------------------------

		private void btnWtoWOWDownload_Click(object sender, System.EventArgs e)
		{
			doWebsiteToWow();
		}

// ----------------------------------------------

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

// ----------------------------------------------

		private void findInstallBtn_Click(object sender, System.EventArgs e)
		{
			wowExeLocBrowsed = "";
			browseWoWDir();
			populateAccountList();
			populateSvList();
			setupWatchers();
		}

// ----------------------------------------------

		private string getUserAgent()
		{
			string agent = buildUserAgent();
			if (userAgent.Text != agent)
				agent = userAgent.Text;
			return agent;
		}

// ----------------------------------------------

		private string buildUserAgent()
		{
			return "UniUploader " + uniVersionMajor + ".0 (UU " + uniVersionMajor + "." + uniVersionMinor + "." + uniVersionBuild + "." + uniVersionRevision + "; " + Language + ")";
		}

// ----------------------------------------------

		public string UploadALL(string url, string fieldname, CookieContainer cookies, CredentialCache credentials, string param1, string param2, string param3, string param4, string val1, string val2, string val3, string val4, string name, string location)
		{
			Hashtable files = new Hashtable();
			string fullFilePath = "";
			string sep = Path.DirectorySeparatorChar.ToString();
			foreach (string checkedSV in SVList.CheckedItems) //itterate through all checked files in the sv file list
			{
				if (checkedSV != "SavedVariables")
				{

					fullFilePath = Path.GetDirectoryName(location) + sep + "SavedVariables" + sep + checkedSV + ".lua";
				}
				else
				{

					fullFilePath = Path.GetDirectoryName(location) + sep + "SavedVariables.lua";
				}

				files[checkedSV] = fullFilePath;
			}
			ArrayList AllParams = new ArrayList();
			AllParams.Add(new string[2] { param1, val1 });
			AllParams.Add(new string[2] { param2, val2 });
			AllParams.Add(new string[2] { param3, val3 });
			AllParams.Add(new string[2] { param4, val4 });
			UniUploader.http.FILE_COMPRESSION_METHODS CompressionMethod = UniUploader.http.FILE_COMPRESSION_METHODS.NONE;
			if (GZcompress.Checked)
				CompressionMethod = UniUploader.http.FILE_COMPRESSION_METHODS.GZIP;
			http.UserAgent = getUserAgent();

			DebugLine("UploadALL: ------------------------------------------------------------------------");
			//http.onInformationMessage += new UniUploader.http.httpInfoDelegate(http_onInformationMessage);
			//string result = http.post(files, AllParams, url, UniUploader.http.ENCODING_TYPES.MULTI_FORM_DATA, UniUploader.http.REQUEST_METHODS.POST, "", CompressionMethod, cookies, credentials);

			UniUploader.http.Response Response = new UniUploader.http.Response();
			if (!http.post(ref Response, url, AllParams, files, CompressionMethod))
			{
				if (cbUpErrorPop.Checked)
				{
					MessageBox.Show("Error - Check Debug Log");
				}
				DebugLine("Failed to Upload");
			}

			//http.onInformationMessage -= new UniUploader.http.httpInfoDelegate(http_onInformationMessage);
			DebugLine("[See Server Response Tab for upload result]");
			DebugLine("UploadALL: ------------------------------------------------------------------------");
			return Response.ToString();
		}

// ----------------------------------------------

		public string Upload(string url, string fieldname, CookieContainer cookies, CredentialCache credentials, string param1, string param2, string param3, string param4, string val1, string val2, string val3, string val4)
		{
			if (UploadALLAccounts.Checked) {
				string InstallPath = GetInstallPath();
				string[] Accounts = GetAccounts(InstallPath);

				if (Accounts == null) {
					return "";
					}

				foreach (string Account in Accounts) {
					tmpmainSvLocation = InstallPath + "\\WTF\\Account\\" + Account + "\\SavedVariables.lua";
					DebugLine("UploadALL: Name \"" + Account + "\"");
					UploadALL(url, fieldname, cookies, credentials, param1, param2, param3, param4, val1, val2, val3, val4, Account, tmpmainSvLocation);
					}

				return "";
				}

			Hashtable files = new Hashtable();
			string fullFilePath = "";
			string sep = Path.DirectorySeparatorChar.ToString();
			foreach (string checkedSV in SVList.CheckedItems) //itterate through all checked files in the sv file list
			{
				if (checkedSV != "SavedVariables")
				{

					fullFilePath = Path.GetDirectoryName(this.mainSvLocation) + sep + "SavedVariables" + sep + checkedSV + ".lua";
				}
				else
				{

					fullFilePath = Path.GetDirectoryName(this.mainSvLocation) + sep + "SavedVariables.lua";
				}

				files[checkedSV] = fullFilePath;
			}
			ArrayList AllParams = new ArrayList();
			AllParams.Add(new string[2] { param1, val1 });
			AllParams.Add(new string[2] { param2, val2 });
			AllParams.Add(new string[2] { param3, val3 });
			AllParams.Add(new string[2] { param4, val4 });
			UniUploader.http.FILE_COMPRESSION_METHODS CompressionMethod = UniUploader.http.FILE_COMPRESSION_METHODS.NONE;
			if (GZcompress.Checked)
				CompressionMethod = UniUploader.http.FILE_COMPRESSION_METHODS.GZIP;
			http.UserAgent = getUserAgent();

			DebugLine("Upload: ------------------------------------------------------------------------");
			//http.onInformationMessage += new UniUploader.http.httpInfoDelegate(http_onInformationMessage);
			//string result = http.post(files, AllParams, url, UniUploader.http.ENCODING_TYPES.MULTI_FORM_DATA, UniUploader.http.REQUEST_METHODS.POST, "", CompressionMethod, cookies, credentials);

			UniUploader.http.Response Response = new UniUploader.http.Response();
			if (!http.post(ref Response, url, AllParams, files, CompressionMethod))
			{
				if (cbUpErrorPop.Checked)
				{
					MessageBox.Show("Error - Check Debug Log");
				}
				DebugLine("Failed to Upload");
			}

			//http.onInformationMessage -= new UniUploader.http.httpInfoDelegate(http_onInformationMessage);
			DebugLine("[See Server Response Tab for upload result]");
			DebugLine("Upload: ------------------------------------------------------------------------");
			return Response.ToString();
		}

// ----------------------------------------------

		private Hashtable getQueryStringParams(string url)
		{
			int queryStringStart = url.IndexOf("?");
			if (queryStringStart == -1) return new Hashtable();
			string queryString = url.Substring(queryStringStart + 1);
			Hashtable h = new Hashtable();
			string[] pairs = queryString.Split('&');
			foreach (string pair in pairs)
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

// ----------------------------------------------

		private string RetrData(string url, CookieContainer cookies, CredentialCache credentials, string param1, string val1, string param2, string val2, string param3, string val3, int Timeout, string param4, string val4)
		{
			return RetrData(url, cookies, credentials, param1, val1, param2, val2, param3, val3, Timeout, param4, val4, null);
		}

// ----------------------------------------------

		private string RetrData(string url, CookieContainer cookies, CredentialCache credentials, string param1, string val1, string param2, string val2, string param3, string val3, int Timeout, string param4, string val4, Hashtable Files)
		{
			DebugLine("");
			DebugLine("RetrData: url: " + url);
			if (param1 != null)
			{
				DebugLine("RetrData: param1: " + param1);
				DebugLine("RetrData: val1: (hidden)");
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
			if (param4 != null)
			{
				DebugLine("RetrData: param4: " + param4);
				DebugLine("RetrData: val4: (hidden)");
			}
			DebugLine("RetrData: Timeout: " + Timeout);
			DebugLine("RetrData: ------------------------------------------------------------------------");
			ArrayList allParams = new ArrayList();
			allParams.Add(new string[2] { param1, val1 });
			allParams.Add(new string[2] { param2, val2 });
			allParams.Add(new string[2] { param3, val3 });
			allParams.Add(new string[2] { param4, val4 });
			UniUploader.http.Response Response = new UniUploader.http.Response();
			if (!http.post(ref Response, url, allParams))
			{
				if (cbUpErrorPop.Checked)
				{
					MessageBox.Show("Error - Check Debug Log");
				}
				DebugLine("Failed to Retrieve Data");
			}
			DebugLine(Response.ToString());
			DebugLine("RetrData: ------------------------------------------------------------------------");
			return Response.ToString();
		}

// ----------------------------------------------

		void http_onInformationMessage(string s)
		{
			DebugLine(s);
		}

// ----------------------------------------------

		private void showAddonsBtn_Click(object sender, System.EventArgs e)
		{
			if (MainForm.ActiveForm.Size.Height < 450)
			{
				showAddonsBtn.Text = _HIDEADDONSBUT;
				this.Height = 506;
			}
			else
			{
				showAddonsBtn.Text = _SHOWADDONSBUT;
				this.Height = 329;
			}
		}

// ----------------------------------------------

		private void debugcheckedaddons()
		{
			foreach (string s in checkedAddons)
			{
				servResponse.Text += s + "\r\n";
			}
			servResponse.Text += "\r\n\r\n";
		}

// ----------------------------------------------

		public void doAddonList(XmlNodeList lstXMLData)
		{
			availableAddons = new ArrayList();
			foreach (XmlNode Node in lstXMLData)
			{
				Hashtable addon = new Hashtable();
				string name = Node.Attributes.GetNamedItem("name").Value.ToString();
				string required = "1";
				try { required = Node.Attributes.GetNamedItem("required").Value.ToString(); }
				catch { }
				string requiredoff = "1";
				try { requiredoff = Node.Attributes.GetNamedItem("requiredoff").Value.ToString(); }
				catch { }
				string toc = "?????";
				try { toc = Node.Attributes.GetNamedItem("toc").Value.ToString(); }
				catch { }
				string version = Node.Attributes.GetNamedItem("version").Value.ToString();
				string notes = "";
				try { notes = Node.Attributes.GetNamedItem("notes").Value.ToString(); }
				catch { }
				//MessageBox.Show(version);
				//				addonsList.Items.Add(AddonName+" "+required+" "+toc+" "+version);
				addon["name"] = name;
				addon["required"] = required;
				addon["requiredoff"] = requiredoff;
				addon["toc"] = toc;
				addon["version"] = version;
				addon["notes"] = notes;
				availableAddons.Add(addon);
			}
			TreeViewClear(treeView1);
			foreach (Hashtable addon in availableAddons)
			{
				string name = (string)addon["name"];
				string required = (string)addon["required"];
				string requiredoff = (string)addon["requiredoff"];
				string toc = (string)addon["toc"];
				string version = (string)addon["version"];
				string notes = (string)addon["notes"];
				bool isChecked = false;
				foreach (string checkedAddon in checkedAddons)
				{
					if (checkedAddon == (string)addon["name"]) isChecked = true;
				}
				if (required == "1") isChecked = true;
				if (EnableOfficerBuild)
				{
					// We only mark Officer Required addons as required if we are running the officer build and officer build is enabled
					if (requiredoff == "1" && IsOfficerBuild) isChecked = true;
				}
				addAddontoAddonList(name, version, toc, isChecked, notes);
				//showAddonsBtn.Enabled = true;
				setControlEnabled(showAddonsBtn, true);
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

// ----------------------------------------------

		private void addAddontoAddonList(string name, string version, string toc, bool isChecked, string notes)
		{
			TreeNode myNode = new TreeNode();
			myNode.Text = name;
			myNode.Nodes.Add(new TreeNode(version, 1, 1));
			myNode.Nodes.Add(new TreeNode(toc, 2, 2));
			myNode.Nodes.Add(new TreeNode(notes, 3, 3));
			myNode.Checked = isChecked;
			myNode.ImageIndex = 0;
			foreach (Hashtable addon in availableAddons)
			{
				string thisName = (string)addon["name"];
				string isRequired = (string)addon["required"];
				string isRequiredOff = (string)addon["requiredoff"];
				if (thisName == name && (isRequired == "1" || (isRequiredOff == "1" && IsOfficerBuild && EnableOfficerBuild)))
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
					new object[] { myNode });
				return;
			}
			treeView1.Nodes.Add(myNode);
		}

// ----------------------------------------------

		private delegate void AddAddonNodeDelegate(TreeNode myNode);

// ----------------------------------------------

		private void AddAddonNode(TreeNode myNode)
		{
			treeView1.Nodes.Add(myNode);
			if (myNode.Checked)
				CheckAllChildNodes(myNode, true);
		}

// ----------------------------------------------

		// Updates all child tree nodes recursively.
		private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
		{
			foreach (TreeNode node in treeNode.Nodes)
			{
				node.Checked = nodeChecked;
				if (node.Nodes.Count > 0)
				{
					// If the current node has child nodes, call the CheckAllChildsNodes method recursively.
					this.CheckAllChildNodes(node, nodeChecked);
				}
			}
		}

// ----------------------------------------------

		// NOTE This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
		// After a tree node's Checked property is changed, all its child nodes are updated to the same value.
		private void node_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Nodes.Count > 0)
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

// ----------------------------------------------

		private bool isAddonChecked(string addonToCheck)
		{
			foreach (string s in checkedAddons)
			{
				if (s == addonToCheck) return true;
			}
			return false;
		}

// ----------------------------------------------

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
					foreach (Hashtable addon in availableAddons)
					{
						string name = (string)addon["name"];
						string isRequired = (string)addon["required"];
						string isRequiredOff = (string)addon["requiredoff"];
						string toc = (string)addon["toc"];
						string version = (string)addon["version"];
						if (name == e.Node.Text)
						{
							if (isRequired == "1") required = true;
							if (isRequiredOff == "1" && IsOfficerBuild && EnableOfficerBuild) required = true;
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

// ----------------------------------------------

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

// ----------------------------------------------

		private void button6_Click(object sender, System.EventArgs e)
		{
			treeView1.ExpandAll();
		}

// ----------------------------------------------

		private void button7_Click(object sender, System.EventArgs e)
		{
			treeView1.CollapseAll();
		}

// ----------------------------------------------

		private void chAllowDelAddons_CheckedChanged(object sender, System.EventArgs e)
		{
		}

// ----------------------------------------------

		private void linkLabel2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			linkLabel2.LinkVisited = true;
			System.Diagnostics.Process.Start("http://www.wowroster.net/member232/");
		}

// ----------------------------------------------

		private void button8_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Text = _UPDATERHELP;
		}

// ----------------------------------------------

		private void addonSyncBtn_Click(object sender, System.EventArgs e)
		{
			job = new ThreadStart(doAddons);
			UploadThread = new Thread(job);
			UploadThread.Name = "SyncThread";
			UploadThread.Start();
		}

// ----------------------------------------------

		private void doAddons()
		{
			SetStatusBarPanelText(statusBarPanel1, _UPDWOWADDON);
			setControlEnabled(addonSyncBtn, false);
			setControlEnabled(autoAddonSyncNow, false);
			UpdateAddons();
			if (chAllowDelAddons.Checked)
			{
				deleteSpecifiedAddons();
			}
			DebugLine(_ADDONSUPD);
			setControlEnabled(addonSyncBtn, true);
			setControlEnabled(autoAddonSyncNow, true);
			SetStatusBarPanelText(statusBarPanel1, _READY);
		}

// ----------------------------------------------

		private void updateCheckBtn_Click(object sender, System.EventArgs e)
		{
			job = new ThreadStart(doUpdates);
			UploadThread = new Thread(job);
			UploadThread.Name = "UpdatesThread";
			UploadThread.Start();
		}

// ----------------------------------------------

		private void doUpdates()
		{
			UserClickedNoUpdate = false;
			CheckForUpdates();
		}

// ----------------------------------------------

		private void treeView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				//if (e.Node.Parent != null)
				//{
				//	treeView1.SelectedNode = e.Node.Parent;
				//	e.Cancel = true;
				//}
				TreeNode t = treeView1.GetNodeAt(e.X, e.Y);
				if (t.Parent != null)
				{
					treeView1.SelectedNode = t.Parent;
				}
				else
				{
					treeView1.SelectedNode = t;
				}
				//treeView1.SelectedNode = treeView1.GetNodeAt (e.X ,e.Y );
				Point clickPoint = new Point(e.X, e.Y);
				TreeNode clickNode = treeView1.GetNodeAt(clickPoint);
				if (clickNode == null) return;
				// Convert from Tree coordinates to Screen coordinates
				Point screenPoint = treeView1.PointToScreen(clickPoint);
				// Convert from Screen coordinates to Form coordinates
				Point formPoint = PointToClient(screenPoint);
				// Show context menu
				if (autoAddonSyncNow.Enabled)
				{
					contextMenu2.Show(this, formPoint);
				}
				//MessageBox.Show("asdf");
			}
		}

// ----------------------------------------------

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
			this.UploadNowBtn.Click += new System.EventHandler(this.UploadNowBtn_Click);
		}

// ----------------------------------------------

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

// ----------------------------------------------

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

// ----------------------------------------------

		private void updateAddon()
		{
			addonSyncBtn.Enabled = false;
			autoAddonSyncNow.Enabled = false;
			string status = _NOWUPD + " [ 1 / 1 ]  " + singleUpdateTmp;
			DebugLine("                                               ");
			DebugLine(status);
			statusBarPanel1.Text = status;
			ArrayList a = new ArrayList();
			a.Add("Interface/AddOns");
			//SetProgressBarValue(progressBar1,0);
			//InvokeProgressBarUpdate(progressBar1);
			UpdateSingleAddon(singleUpdateTmp, AutoAddonURL.Text, a);
			addonSyncBtn.Enabled = true;
			autoAddonSyncNow.Enabled = true;
			statusBarPanel1.Text = _READY;
		}

// ----------------------------------------------

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
				AddonRetrievalResponse = RetrData(URL, null, null, "OPERATION", "GETADDON", "ADDON", singleUpdateTmp, arrg1.Text, valu1.Text, -1, arrg2.Text, value2);
			}
			else
			{
				AddonRetrievalResponse = RetrData(URL, null, null, "OPERATION", "GETADDON", "ADDON", singleUpdateTmp, null, null, -1, null, null);
			}
			string filename = GetfileNameFromURI(AddonRetrievalResponse);
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Zip file|*.zip";
			saveFileDialog1.FileName = filename;
			//saveFileDialog1.Title = _SAVLOG;
			DialogResult ok = saveFileDialog1.ShowDialog();
			if (ok == DialogResult.OK || ok == DialogResult.Yes)
			{
				string status = _DOWNLOADING + " [ 1 / 1 ]  " + singleUpdateTmp;
				DebugLine("                                               ");
				DebugLine(status);
				statusBarPanel1.Text = status;
				//SetProgressBarValue(progressBar1,0);
				//InvokeProgressBarUpdate(progressBar1);
				download(AddonRetrievalResponse, saveFileDialog1.FileName);
				statusBarPanel1.Text = _READY;
			}
		}

// ----------------------------------------------

		private System.Threading.Timer AutoSyncTimer = null;

// ----------------------------------------------

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (nudAutoSyncInterval.Value == 0)
			{
				AutoSyncTimer = null;
				return;
			}
			else
			{
				int ms = ((int)nudAutoSyncInterval.Value * 60 * 1000);
				AutoSyncTimer = new System.Threading.Timer(new System.Threading.TimerCallback(SyncNowTimerHelper), null, 0, ms);
				AutoSyncTimer.Change(ms, ms);
			}
		}

// ----------------------------------------------

		private void SyncNowTimerHelper(Object State)
		{
			if (!updating)
				SyncNOW();
		}

// ----------------------------------------------

		private void SelectSystemTrayIcon()
		{
			clearSysTrayIcon();
			OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
			OpenFileDialog1.Filter = "Icon File|*.ico";
			OpenFileDialog1.Title = "Choose a system tray icon.";
			OpenFileDialog1.ShowDialog();
			String SourceFile = OpenFileDialog1.FileName;
			if (OpenFileDialog1.FileName != "")
			{
				String destinationFile = WorkSpacePath + "\\systray.ico";
				if (File.Exists(destinationFile))
				{
					File.Delete(destinationFile);
				}
				if (!File.Exists(SourceFile))
				{
					DebugLine("Source Icon File is missing");
					return;
				}
				try
				{
					File.Copy(SourceFile, destinationFile);
					SetSysTrayIcon();
				}
				catch (Exception e)
				{
					DebugLine(e.Message);
					return;
				}
			}
			else
			{
				return;
			}
		}

// ----------------------------------------------

		private void clearSysTrayIcon()
		{
			setDefaultIcon();

			String IconFile = WorkSpacePath + "\\systray.ico";
			if (File.Exists(IconFile))
			{
				try
				{
					File.Delete(IconFile);
				}
				catch (Exception e)
				{
					DebugLine(e.Message);
				}

			}
		}

// ----------------------------------------------

		private void SetSysTrayIcon()
		{
			String IconFile = WorkSpacePath + "\\systray.ico";
			if (File.Exists(IconFile))
			{
				try
				{
					this.notifyIcon1.Visible = false;
					this.notifyIcon1 = new NotifyIcon();
					this.notifyIcon1.ContextMenu = this.contextMenu1;
					this.notifyIcon1.Icon = new Icon(IconFile);
					this.notifyIcon1.Text = this.GuildName + "UniUploader" + this.OfficerStr;
					this.notifyIcon1.Visible = true;
					notifyIcon1.DoubleClick += new EventHandler(notifyIcon1_DoubleClick);
				}
				catch (Exception e)
				{
					DebugLine(e.Message);
				}
			}
			else
			{
				setDefaultIcon();
			}
			checkBox1_CheckedChanged(null, null);
		}

// ----------------------------------------------

		private void setDefaultIcon()
		{
			try
			{
				this.notifyIcon1.Visible = false;
				this.notifyIcon1 = new NotifyIcon();
				this.notifyIcon1.ContextMenu = this.contextMenu1;
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
				this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
				this.notifyIcon1.Text = this.GuildName + "UniUploader" + this.OfficerStr;
				this.notifyIcon1.Visible = true;
				notifyIcon1.DoubleClick += new EventHandler(notifyIcon1_DoubleClick);
				checkBox1_CheckedChanged(null, null);
			}
			catch (Exception e)
			{
				DebugLine(e.Message);
			}
		}

// ----------------------------------------------

		private void btnSysTrayIco_Click(object sender, EventArgs e)
		{
			SelectSystemTrayIcon();
		}

// ----------------------------------------------

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			linkLabel3.LinkVisited = true;
			System.Diagnostics.Process.Start("http://MatthewMiller.info");
		}

// ----------------------------------------------

		private void userAgent_TextChanged(object sender, EventArgs e)
		{
			http.UserAgent = getUserAgent();
		}

// ----------------------------------------------

		private void UploadALLAccounts_CheckedChanged(object sender, System.EventArgs e)
		{
			if (UploadALLAccounts.Checked) { AccountList.Enabled = false; }
			else { AccountList.Enabled = true; }
		}

// ----------------------------------------------

		/// <summary>
		/// Encrypt a string.
		/// </summary>
		/// <param name="originalString">The original string.</param>
		/// <returns>The encrypted string.</returns>
		public static string Encrypt(string originalString)
		{
			string pstrEncrKey = "1701;[TeamPNX)WibbleWibbleWibbleMcFish";
			byte[] byKey ={ };
			byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
			byKey = System.Text.Encoding.UTF8.GetBytes(pstrEncrKey.Substring(0, 8));
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			byte[] inputByteArray = Encoding.UTF8.GetBytes(originalString);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			return Convert.ToBase64String(ms.ToArray());
		}

// ----------------------------------------------

		/// <summary>
		/// Decrypt a crypted string.
		/// </summary>
		/// <param name="cryptedString">The crypted string.</param>
		/// <returns>The decrypted string.</returns>
		public static string Decrypt(string cryptedString)
		{
			cryptedString = cryptedString.Replace(" ", "+");
			string pstrDecrKey = "1701;[TeamPNX)WibbleWibbleWibbleMcFish";
			byte[] byKey ={ };
			byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
			byte[] inputByteArray = new byte[cryptedString.Length];

			byKey = System.Text.Encoding.UTF8.GetBytes(pstrDecrKey.Substring(0, 8));
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			inputByteArray = Convert.FromBase64String(cryptedString);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			System.Text.Encoding encoding = System.Text.Encoding.UTF8;
			return encoding.GetString(ms.ToArray());
		}

// ----------------------------------------------

	}
}

// ----------------------------------------------
