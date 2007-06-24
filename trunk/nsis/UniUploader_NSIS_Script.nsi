; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "UniUploader"
!define PRODUCT_VERSION "2.6.6"
!define PRODUCT_PUBLISHER "Matt Miller"
!define PRODUCT_WEB_SITE "http://www.wowroster.net"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\UniUploader.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"
!define PRODUCT_STARTMENU_REGVAL "NSIS:StartMenuDir"

;--------------------------------
; Set compressor for the installer
  SetCompressor /SOLID lzma

;--------------------------------
; URL to the .NET Framework 2.0 download
; No different locales needed for it is multilingual
  !define URL_DOTNET "http://download.microsoft.com/download/5/6/7/567758a3-759e-473e-bf8f-52154438565a/dotnetfx.exe"

;--------------------------------
; Declaring variables
  Var "DOTNET_RETURN_CODE"

;--------------------------------
; include Modern User Interface
  !include "MUI.nsh"

;--------------------------------
; MUI Settings
  !define MUI_ABORTWARNING
  !define MUI_UNABORTWARNING
  
  !define MUI_ICON "NEWUUIcon.ico"
  !define MUI_UNICON "NEWUUIcon.ico"
  ;!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\orange-install.ico"
  ;!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\orange-uninstall.ico"


;--------------------------------
; Language Selection Dialog Settings
;
; (This will try to get the language
; for the installer and the uninstaller
; if UniUploader is already installed.
; Comment this out if you want to have
; the language selection dialog every time
; you install or uninstall)
  !define MUI_LANGDLL_REGISTRY_ROOT "${PRODUCT_UNINST_ROOT_KEY}"
  !define MUI_LANGDLL_REGISTRY_KEY "${PRODUCT_UNINST_KEY}"
  !define MUI_LANGDLL_REGISTRY_VALUENAME "NSIS:Language"


;--------------------------------
;Pages for the installer

  ; Welcome page
  !insertmacro MUI_PAGE_WELCOME
  
  ; License page
  !insertmacro MUI_PAGE_LICENSE $(MLLicense)
  
  ; Directory page
  !insertmacro MUI_PAGE_DIRECTORY
  
  ; Start menu page
  var ICONS_GROUP
  !define MUI_STARTMENUPAGE_NODISABLE
  !define MUI_STARTMENUPAGE_DEFAULTFOLDER "UniUploader"
  !define MUI_STARTMENUPAGE_REGISTRY_ROOT "${PRODUCT_UNINST_ROOT_KEY}"
  !define MUI_STARTMENUPAGE_REGISTRY_KEY "${PRODUCT_UNINST_KEY}"
  !define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "${PRODUCT_STARTMENU_REGVAL}"
  !insertmacro MUI_PAGE_STARTMENU Application $ICONS_GROUP
  
  ; Instfiles page
  !insertmacro MUI_PAGE_INSTFILES
  
  ; Finish page
  !define MUI_FINISHPAGE_RUN "$INSTDIR\UniUploader.exe"
  !insertmacro MUI_PAGE_FINISH

;--------------------------------
;Pages for the deinstaller

  ; Welcome page
  !insertmacro MUI_UNPAGE_WELCOME

  ; Confirmation page
  !insertmacro MUI_UNPAGE_CONFIRM

  ; Uninstallation of files page
  !insertmacro MUI_UNPAGE_INSTFILES

  ; Finish page
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
; Language files

  !insertmacro MUI_LANGUAGE "English"
  !insertmacro MUI_LANGUAGE "German"
  ; put other languages in here
  ; !insertmacro MUI_LANGUAGE "French"

;--------------------------------
; License Language String

  LicenseLangString MLLicense ${LANG_ENGLISH} "License.txt"
  LicenseLangString MLLicense ${LANG_GERMAN} "License.txt"
  ; Put licenses for other languages here
  ; Put license.txt in the same dir as the script file or point the path
  ; If you don't have a license in your language set this to the english version.
  ; LicenseLangString MLLicense ${LANG_FRENCH} "\path\relative\to\script_file\License_FR.txt"

;--------------------------------
; Language Strings
;
; Put the strings for your language below

  LangString PRODUCT_NAME_ML ${LANG_ENGLISH} "UniUploader"
  LangString PRODUCT_NAME_ML ${LANG_GERMAN} "UniUploader"
  ;LangString PRODUCT_NAME_ML ${LANG_FRENCH} "UniUploader"

  LangString DESC_REMAINING ${LANG_ENGLISH} " (%d %s%s remaining)"
  LangString DESC_REMAINING ${LANG_GERMAN} " (noch %d %s%s)"
  ;LangString DESC_REMAINING ${LANG_FRENCH} "insert your translation here"
  
  LangString DESC_PROGRESS ${LANG_ENGLISH} "%dkB of %dkB @ %d.%01dkB/s"
  LangString DESC_PROGRESS ${LANG_GERMAN} "%dkB von %dkB @ %d.%01dkB/s"
  
  LangString DESC_PLURAL ${LANG_ENGLISH} "s"
  LangString DESC_PLURAL ${LANG_GERMAN} "n"
  
  LangString DESC_HOUR ${LANG_ENGLISH} "hour"
  LangString DESC_HOUR ${LANG_GERMAN} "Stunde"
  
  LangString DESC_MINUTE ${LANG_ENGLISH} "minute"
  LangString DESC_MINUTE ${LANG_GERMAN} "Minute"
  
  LangString DESC_SECOND ${LANG_ENGLISH} "second"
  LangString DESC_SECOND ${LANG_GERMAN} "Sekunde"
  
  LangString DESC_CONNECTING ${LANG_ENGLISH} "Connecting..."
  LangString DESC_CONNECTING ${LANG_GERMAN} "Verbindung wird aufgebaut..."
  
  LangString DESC_DOWNLOADING ${LANG_ENGLISH} "Downloading %s"
  LangString DESC_DOWNLOADING ${LANG_GERMAN} "Lade %s herunter"
  
  LangString DESC_SHORTDOTNET ${LANG_ENGLISH} "Microsoft .Net Framework 2.0"
  LangString DESC_SHORTDOTNET ${LANG_GERMAN} "Microsoft .Net Framework 2.0"
  
  LangString DESC_LONGDOTNET ${LANG_ENGLISH} "Microsoft .Net Framework 2.0"
  LangString DESC_LONGDOTNET ${LANG_GERMAN} "Microsoft .Net Framework 2.0"
  
  LangString DESC_DOTNET_DECISION ${LANG_ENGLISH} "$(DESC_SHORTDOTNET) was not \
    found on your system. \
    $\nIt is strongly advised that you install $(DESC_SHORTDOTNET) before continuing. \
    $\nIf you choose to continue, you will need to connect to the Internet \
    $\nbefore proceeding. \
    $\n$\nShould $(DESC_SHORTDOTNET) be installed now?"
  LangString DESC_DOTNET_DECISION ${LANG_GERMAN} "$(DESC_SHORTDOTNET) wurde nicht auf \
    Ihrem System gefunden. \
    $\nEs wird empfohlen $(DESC_SHORTDOTNET) zu installieren. \
    $\nWenn Sie das tun m�chten, stellen Sie bitte eine Internetverbindung her, \
    $\nbevor sie die Installation fortsetzen. \
    $\n$\nSoll $(DESC_SHORTDOTNET) jetzt installiert werden?"
  
  LangString SEC_DOTNET ${LANG_ENGLISH} "$(DESC_SHORTDOTNET)"
  LangString SEC_DOTNET ${LANG_GERMAN} "$(DESC_SHORTDOTNET)"
  
  LangString DESC_INSTALLING ${LANG_ENGLISH} "Installing"
  LangString DESC_INSTALLING ${LANG_GERMAN} "Installieren von"
  
  LangString DESC_DOWNLOADING1 ${LANG_ENGLISH} "Downloading"
  LangString DESC_DOWNLOADING1 ${LANG_GERMAN} "Heruntergeladen von"
  
  LangString DESC_DOWNLOADFAILED ${LANG_ENGLISH} "Download Failed:"
  LangString DESC_DOWNLOADFAILED ${LANG_GERMAN} "Herunterladen fehlgeschlagen:"
  
  LangString ERROR_DUPLICATE_INSTANCE ${LANG_ENGLISH} "The $(DESC_SHORTDOTNET) Installer is \
    already running."
  LangString ERROR_DUPLICATE_INSTANCE ${LANG_GERMAN} "Die Installation von $(DESC_SHORTDOTNET) \
    ist bereits gestartet."
  
  LangString ERROR_NOT_ADMINISTRATOR ${LANG_ENGLISH} "You are not administrator."
  LangString ERROR_NOT_ADMINISTRATOR ${LANG_GERMAN} "Sie sind nicht der Administrator."
  
  LangString ERROR_INVALID_PLATFORM ${LANG_ENGLISH} "OS not supported."
  LangString ERROR_INVALID_PLATFORM ${LANG_GERMAN} "Betriebsystem nicht �nterst�tzt."
  
  LangString DESC_DOTNET_TIMEOUT ${LANG_ENGLISH} "The installation of the $(DESC_SHORTDOTNET) \
    has timed out."
  LangString DESC_DOTNET_TIMEOUT ${LANG_GERMAN} "Die Installation von $(DESC_SHORTDOTNET) \
    ist abgelaufen."
  
  LangString ERROR_DOTNET_INVALID_PATH ${LANG_ENGLISH} "The $(DESC_SHORTDOTNET) Installation \
    $\n was not found in the following location:$\n"
  LangString ERROR_DOTNET_INVALID_PATH ${LANG_GERMAN} "In dem folgenden Verzeichnis wurde keine \
    $\nInstallation von $(DESC_SHORTDOTNET) gefunden:$\n"
  
  LangString ERROR_DOTNET_FATAL ${LANG_ENGLISH} "A fatal error occurred during the installation \
    $\nof $(DESC_SHORTDOTNET)."
  LangString ERROR_DOTNET_FATAL ${LANG_GERMAN} "Kritischer Fehler bei der Installation von \
    $(DESC_SHORTDOTNET) aufgetreten."
  
  LangString FAILED_DOTNET_INSTALL ${LANG_ENGLISH} "$(DESC_LONGDOTNET) was not installed. \
    $\n$(PRODUCT_NAME_ML) may not function properly until $(DESC_LONGDOTNET) is installed. \
    $\n$\nDo you still want to install $(PRODUCT_NAME_ML)?"
  LangString FAILED_DOTNET_INSTALL ${LANG_GERMAN} "$(DESC_LONGDOTNET) wurde nicht installiert. \
    $\n$(PRODUCT_NAME_ML) k�nnte nicht richtig funktionieren, solange $(DESC_LONGDOTNET) \
    $\nnicht installiert ist. \
    $\n$\nM�chten Sie $(PRODUCT_NAME_ML) trotzdem installieren?"

  LangString NOT_INSTALLED ${LANG_ENGLISH} "was not installed."
  LangString NOT_INSTALLED ${LANG_GERMAN} "wurde nicht installiert."

;--------------------------------
; General

  Name "${PRODUCT_NAME}"
  OutFile "${PRODUCT_NAME}_${PRODUCT_VERSION}_Installer.exe"
  InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"
  InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
  ShowInstDetails show
  ShowUnInstDetails show

;--------------------------------
; Install funtion

  Function .onInit
    !insertmacro MUI_LANGDLL_DISPLAY
    InitPluginsDir
  FunctionEnd

;--------------------------------
; Check for .NET Framework install

  Function IsDotNETInstalled
    Push $0
    Push $1
    Push $2
    Push $3
    Push $4

    ReadRegStr $4 HKEY_LOCAL_MACHINE \
      "Software\Microsoft\.NETFramework" "InstallRoot"
    # remove trailing back slash
    Push $4
    Exch $EXEDIR
    Exch $EXEDIR
    Pop $4
    # if the root directory doesn't exist .NET is not installed
    IfFileExists $4 0 noDotNET

    StrCpy $0 0

    EnumStart:
      EnumRegKey $2 HKEY_LOCAL_MACHINE \
        "Software\Microsoft\.NETFramework\Policy"  $0
      IntOp $0 $0 + 1
      StrCmp $2 "" noDotNET

      StrCpy $1 0

    EnumPolicy:
      EnumRegValue $3 HKEY_LOCAL_MACHINE \
        "Software\Microsoft\.NETFramework\Policy\$2" $1
      IntOp $1 $1 + 1
      StrCmp $3 "" EnumStart
      IfFileExists "$4\$2.$3" foundDotNET EnumPolicy

    noDotNET:
      StrCpy $0 0
      Goto done

    foundDotNET:
      StrCpy $0 1

    done:
      Pop $4
      Pop $3
      Pop $2
      Pop $1
      Exch $0
  FunctionEnd

;--------------------------------
; Section for .NET Framework
; This downloads and installs Miscrosoft .NET Framework 2.0
; if not found on the system

  Section $(SEC_DOTNET) SECDOTNET
    Call IsDotNETInstalled
    Pop $R3
    ; IsDotNETInstalled returns 1 for yes and 0 for no
    StrCmp $R3 "1" lbl_isinstalled lbl_notinstalled

    lbl_notinstalled:

    SectionIn RO
    ; the following Goto and Label is for consistencey.
    Goto lbl_DownloadRequired

    lbl_DownloadRequired:
      MessageBox MB_ICONEXCLAMATION|MB_YESNO|MB_DEFBUTTON2 "$(DESC_DOTNET_DECISION)" /SD IDNO \
        IDYES +2 IDNO lbl_Done
      DetailPrint "$(DESC_DOWNLOADING1) $(DESC_SHORTDOTNET)..."
      ; "Downloading Microsoft .Net Framework"
      AddSize 286720
      nsisdl::download /TRANSLATE "$(DESC_DOWNLOADING)" "$(DESC_CONNECTING)" \
         "$(DESC_SECOND)" "$(DESC_MINUTE)" "$(DESC_HOUR)" "$(DESC_PLURAL)" \
         "$(DESC_PROGRESS)" "$(DESC_REMAINING)" \
         /TIMEOUT=30000 "${URL_DOTNET}" "$PLUGINSDIR\dotnetfx.exe"
      Pop $0
      StrCmp "$0" "success" lbl_continue
      DetailPrint "$(DESC_DOWNLOADFAILED) $0"
      Abort

    ; start installation of .NET framework
    lbl_continue:
      DetailPrint "$(DESC_INSTALLING) $(DESC_SHORTDOTNET)..."
      Banner::show /NOUNLOAD "$(DESC_INSTALLING) $(DESC_SHORTDOTNET)..."
      nsExec::ExecToStack '"$PLUGINSDIR\dotnetfx.exe" /q /c:"install.exe /noaspupgrade /q"'
      pop $DOTNET_RETURN_CODE
      Banner::destroy
      SetRebootFlag false
      ; silence the compiler
      Goto lbl_NoDownloadRequired

    lbl_NoDownloadRequired:

      ; obtain any error code and inform the user ($DOTNET_RETURN_CODE)
      ; If nsExec is unable to execute the process,
      ; it will return "error"
      ; If the process timed out it will return "timeout"
      ; else it will return the return code from the executed process.
      StrCmp "$DOTNET_RETURN_CODE" "" lbl_NoError
      StrCmp "$DOTNET_RETURN_CODE" "0" lbl_NoError
      StrCmp "$DOTNET_RETURN_CODE" "3010" lbl_NoError
      StrCmp "$DOTNET_RETURN_CODE" "8192" lbl_NoError
      StrCmp "$DOTNET_RETURN_CODE" "error" lbl_Error
      StrCmp "$DOTNET_RETURN_CODE" "timeout" lbl_TimeOut
      ; It's a .Net Error
      StrCmp "$DOTNET_RETURN_CODE" "4101" lbl_Error_DuplicateInstance
      StrCmp "$DOTNET_RETURN_CODE" "4097" lbl_Error_NotAdministrator
      StrCmp "$DOTNET_RETURN_CODE" "1633" lbl_Error_InvalidPlatform lbl_FatalError
      ; all others are fatal

    lbl_Error_DuplicateInstance:
      DetailPrint "$(ERROR_DUPLICATE_INSTANCE)"
      GoTo lbl_Done

    lbl_Error_NotAdministrator:
      DetailPrint "$(ERROR_NOT_ADMINISTRATOR)"
      GoTo lbl_Done

    lbl_Error_InvalidPlatform:
      DetailPrint "$(ERROR_INVALID_PLATFORM)"
      GoTo lbl_Done

    lbl_TimeOut:
      DetailPrint "$(DESC_DOTNET_TIMEOUT)"
      GoTo lbl_Done

    lbl_Error:
      DetailPrint "$(ERROR_DOTNET_INVALID_PATH)"
      GoTo lbl_Done

    lbl_FatalError:
      DetailPrint "$(ERROR_DOTNET_FATAL)[$DOTNET_RETURN_CODE]"
      GoTo lbl_Done

    lbl_Done:
      DetailPrint "$(DESC_LONGDOTNET) $(NOT_INSTALLED)"
      MessageBox MB_ICONEXCLAMATION|MB_YESNO|MB_DEFBUTTON2 "$(FAILED_DOTNET_INSTALL)" /SD IDNO \
      IDYES +2 IDNO 0
      DetailPrint "$(PRODUCT_NAME_ML) $(NOT_INSTALLED)"
      Abort

    lbl_NoError:

    lbl_isinstalled:
  SectionEnd

;--------------------------------
; UniUploader Install

  ; install UniUploader
  Section "UniUploader" SEC01
    SetOutPath "$INSTDIR"
    SetOverwrite on
    File "UniUploader.exe"
    File "LICENSE.TXT"

    ; The following line is for preconfigured Guild Releases.  If you want
    ; to release it to a specific Guild with a preconfigured .ini file, just
    ; uncomment the following line and it will be included in the install
    ;File "settings.ini"

    SetOverwrite ifnewer
    File "logo1.gif"
    File "logo2.gif"

    ; Create the shortcuts
    !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    CreateDirectory "$SMPROGRAMS\$ICONS_GROUP"
    CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\UniUploader.lnk" "$INSTDIR\UniUploader.exe"
    CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\Uninstall.lnk" "$INSTDIR\uninst.exe"
    CreateShortCut "$DESKTOP\UniUploader.lnk" "$INSTDIR\UniUploader.exe"
    !insertmacro MUI_STARTMENU_WRITE_END
  SectionEnd

  ; Write the uninstaller and the registry entries
  Section -Post
    WriteUninstaller "$INSTDIR\uninst.exe"
    WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\UniUploader.exe"
    WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
    WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
    WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\UniUploader.exe"
    WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
    WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
    WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
  SectionEnd

;--------------------------------
; Uninst. funtions

  Function un.onInit
    !insertmacro MUI_UNGETLANGUAGE
  FunctionEnd

;--------------------------------
; Uninst. sections

  Section Uninstall
    !insertmacro MUI_STARTMENU_GETFOLDER "Application" $ICONS_GROUP
    Delete "$INSTDIR\${PRODUCT_NAME}.url"
    Delete "$INSTDIR\uninst.exe"
    Delete "$INSTDIR\logo2.gif"
    Delete "$INSTDIR\logo1.gif"
    Delete "$INSTDIR\UniUploader.exe"
    Delete "$INSTDIR\languages.ini"
    Delete "$INSTDIR\LICENSE.TXT"
    Delete "$INSTDIR\RespNotepad.htm"
    Delete "$INSTDIR\SiteSVIE.htm"
    Delete "$INSTDIR\SiteSVNotepad.htm"
    Delete "$INSTDIR\debug_notepad.txt"
    Delete "$INSTDIR\debug_ie.txt"
    Delete "$INSTDIR\settings.ini"

    Delete "$SMPROGRAMS\$ICONS_GROUP\Uninstall.lnk"
    Delete "$SMPROGRAMS\$ICONS_GROUP\UniUploader.lnk"
    Delete "$DESKTOP\UniUploader.lnk"
    
    RMDir "$SMPROGRAMS\$ICONS_GROUP"
    RMDir "$INSTDIR"

    DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
    DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
    SetAutoClose true
  SectionEnd