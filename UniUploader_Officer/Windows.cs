using System;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace UniUploader_Officer
{
    public class Windows
    {
        private class myObjectComparer : IEqualityComparer
        {
            public CaseInsensitiveComparer myComparer;
            public myObjectComparer()
            {
                myComparer = CaseInsensitiveComparer.DefaultInvariant;
            }
            public myObjectComparer(CultureInfo myCulture)
            {
                myComparer = new CaseInsensitiveComparer(myCulture);
            }
            public new Boolean Equals(object x, object y)
            {
                if (myComparer.Compare((String)x, (String)y) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public int GetHashCode(object obj)
            {
                return obj.ToString().ToLower().GetHashCode();
            }
        }
        public static bool SetTitle(IntPtr Handle, String Text)
        {
            System.Text.StringBuilder StringBuilder = new System.Text.StringBuilder(Text);
            return SetWindowText(Handle, StringBuilder.ToString());
        }
        public static byte[] FileToByteArray(string file)
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
        public static Boolean ScrollToBottom(IntPtr Handle)
        {
            return ScrollToBottom(Handle, true);
        }
        public static Boolean ScrollToBottom(IntPtr Handle, Boolean Blocking)
        {
            WindowMessage Message = new WindowMessage();
            Message.Handle = Handle;
            Message.InVal = KEYWORDS.WM_VSCROLL;
            Message.PtrLparam = new IntPtr(0);
            Message.PtrWparam = KEYWORDS.SB_BOTTOM;
            if (Blocking)
            {
                return System.Boolean.Equals(true, SendWindowMessage(Message));
            }
            else
            {
                ParameterizedThreadStart pts = new ParameterizedThreadStart(SendWindowMessage);
                Thread t = new Thread(pts);
                t.Start(Message);
                return false;
            }
        }
        public Windows()
        {
        }
        #region externs and keywords
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr Handle, IntPtr InVal, IntPtr PtrWparam, IntPtr PtrLparam);
        [DllImport("user32.dll")]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);
        public static class KEYWORDS
        {
            public static readonly IntPtr WM_VSCROLL = new IntPtr(277);
            public static readonly IntPtr SB_BOTTOM = new IntPtr(7);
            public static readonly IntPtr SB_LINEUP = new IntPtr(0);
            public static readonly IntPtr SB_LINEDOWN = new IntPtr(1);
            public static readonly IntPtr SB_PAGEUP = new IntPtr(2);
            public static readonly IntPtr SB_PAGEDOWN = new IntPtr(3);
            public static readonly IntPtr SB_TOP = new IntPtr(6);
            public static readonly IntPtr ATTACH_PARENT_PROCESS = new IntPtr(-1);
            public static readonly IntPtr ERROR_ACCESS_DENIED = new IntPtr(5);
        }
        private System.Collections.Hashtable AsyncResults = new System.Collections.Hashtable(new myObjectComparer());
        static int WindowMessageSize = IntPtr.Size;
        [StructLayout(LayoutKind.Explicit, Pack = 16, CharSet = CharSet.Ansi)]
        public struct WindowMessage
        {
            [FieldOffset(0)]
            public IntPtr Handle;
            [FieldOffset(4)]
            public IntPtr InVal;
            [FieldOffset(8)]
            public IntPtr PtrWparam;
            [FieldOffset(12)]
            public IntPtr PtrLparam;
        }
        /// <summary>Identifies the console of the parent of the current process as the console to be attached.
        /// always pass this with AttachConsole in .NET for stability reasons and mainly because
        /// I have NOT tested interprocess attaching in .NET so dont blame me if it doesnt work! </summary>

        /// <summary>
        /// calling process is already attached to a console
        /// </summary>
        #endregion externs and keywords
        private static void SendWindowMessage(Object o)
        {
            WindowMessage Message = (WindowMessage)o;
            SendWindowMessage(Message);
        }
        private static IntPtr SendWindowMessage(WindowMessage Message)
        {
            return SendMessage(Message.Handle, Message.InVal, Message.PtrWparam, Message.PtrLparam);
        }
        private static IntPtr SendWindowMessage(WindowMessage Message, Boolean Blocking)
        {
            if (!Blocking)
            {
                return SendWindowMessage(Message);
            }
            else
            {
                ParameterizedThreadStart pts = new ParameterizedThreadStart(SendWindowMessage);
                Thread t = new Thread(pts);
                t.Start(Message);
                return IntPtr.Zero;
            }
        }



    }
    public class GUI_helper : Form
    {
        #region GUI object helpers
        //misc
        public static class MyTreeNodeCollection
        {
            public static TreeNodeCollection getNewTNC()
            {
                TreeView tv1 = new TreeView();
                return tv1.Nodes;
            }
        }

        //form
        public delegate void CloseFormDelegate();
        public virtual void CloseForm()
        {
            if (this.InvokeRequired)
            {
                CloseFormDelegate dele = new CloseFormDelegate(CloseForm2);
                this.Invoke(dele);
            }
            else
            {
                CloseForm2();
            }
        }
        private void CloseForm2()
        {
            this.Close();
        }

        //control
        public delegate void SetControlEnabledDelegate(Control Control, Boolean Enabled);
        public virtual void setControlEnabled(Control Control, Boolean Enabled)
        {
            if (this.InvokeRequired)
            {
                SetControlEnabledDelegate dele = new SetControlEnabledDelegate(setControlEnabled2);
                this.Invoke(dele, new object[] { Control, Enabled });
            }
            else
            {
                setControlEnabled2(Control, Enabled);
            }
        }
        private void setControlEnabled2(Control Control, Boolean Enabled)
        {
            Control.Enabled = Enabled;
        }
        public delegate void SetControlTextDelegate(Control Control, String Text);
        public virtual void setControlText(Control Control, String Text)
        {
            if (this.InvokeRequired)
            {
                SetControlTextDelegate dele = new SetControlTextDelegate(setControlText2);
                this.Invoke(dele, new object[] { Control, Text });
            }
            else
            {
                setControlText2(Control, Text);
            }
        }
        private void setControlText2(Control Control, String Text)
        {
            Control.Text = Text;
        }
        public delegate String GetControlTextDelegate(Control Control);
        public virtual String getControlText(Control Control)
        {
            if (this.InvokeRequired)
            {
                GetControlTextDelegate dele = new GetControlTextDelegate(getControlText2);
                return (String)this.Invoke(dele, new object[] { Control });
            }
            else
            {
                return getControlText2(Control);
            }
        }
        private String getControlText2(Control Control)
        {
            return Control.Text;
        }
        public delegate void SetControlTagDelegate(Control Control, Object Text);
        public virtual void SetControlTag(Control Control, Object TagObject)
        {
            if (this.InvokeRequired)
            {
                SetControlTagDelegate dele = new SetControlTagDelegate(SetControlTag2);
                this.Invoke(dele, new object[] { Control, TagObject });
            }
            else
            {
                SetControlTag2(Control, TagObject);
            }
        }
        private void SetControlTag2(Control Control, Object TagObject)
        {
            Control.Tag = TagObject;
        }
        private delegate void setControlBoxEnabledDelegate(bool enabled);
        public virtual void setControlBoxEnabled(bool enabled)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new setControlBoxEnabledDelegate(setControlBoxEnabled2), new object[] { enabled });
            }
            else
            {
                setControlBoxEnabled2(enabled);
            }
        }
        private void setControlBoxEnabled2(bool enabled)
        {
            this.ControlBox = enabled;
        }

        //picturebox
        public delegate void SetPictureBoxImageLocationDelegate(PictureBox Object, String Location);
        public virtual void SetPictureBoxImageLocation(PictureBox Object, String Location)
        {
            if (this.InvokeRequired)
            {
                SetPictureBoxImageLocationDelegate dele = new SetPictureBoxImageLocationDelegate(SetPictureBoxImageLocation2);
                this.Invoke(dele, new object[] { Object, Location });
            }
            else
            {
                SetPictureBoxImageLocation2(Object, Location);
            }
        }
        private void SetPictureBoxImageLocation2(PictureBox Object, String Location)
        {
            Object.ImageLocation = Location;
        }
        public delegate void SetPictureBoxImageDelegate(PictureBox Object, Image Image);
        public virtual void SetPictureBoxImage(PictureBox Object, Image Image)
        {
            if (this.InvokeRequired)
            {
                SetPictureBoxImageDelegate dele = new SetPictureBoxImageDelegate(SetPictureBoxImage2);
                this.Invoke(dele, new object[] { Object, Image });
            }
            else
            {
                SetPictureBoxImage2(Object, Image);
            }
        }
        private void SetPictureBoxImage2(PictureBox Object, Image Image)
        {
            Object.Image = Image;
        }

        //status bar panel
        public delegate void SetStatusBarPanelTextDelegate(StatusBarPanel Object, String Text);
        public virtual void SetStatusBarPanelText(StatusBarPanel Object, String Text)
        {
            if (this.InvokeRequired)
            {
                SetStatusBarPanelTextDelegate dele = new SetStatusBarPanelTextDelegate(SetStatusBarPanelText2);
                this.Invoke(dele, new object[] { Object, Text });
            }
            else
            {
                SetStatusBarPanelText2(Object, Text);
            }
        }
        private void SetStatusBarPanelText2(StatusBarPanel Object, String Text)
        {
            Object.Text = Text;
        }

        //progress bar
        public delegate void InvokeProgressBarUpdateDelegate(ProgressBar Object);
        public virtual void InvokeProgressBarUpdate(ProgressBar Object)
        {
            if (this.InvokeRequired)
            {
                InvokeProgressBarUpdateDelegate dele = new InvokeProgressBarUpdateDelegate(InvokeProgressBarUpdate2);
                this.Invoke(dele, new object[] { Object });
            }
            else
            {
                InvokeProgressBarUpdate2(Object);
            }
        }
        private void InvokeProgressBarUpdate2(ProgressBar Object)
        {
            Object.Update();
        }
        public delegate void SetProgressBarValueDelegate(ProgressBar Object, Int32 Value);
        public virtual void SetProgressBarValue(ProgressBar Object, Int32 Value)
        {
            if (this.InvokeRequired)
            {
                SetProgressBarValueDelegate dele = new SetProgressBarValueDelegate(SetProgressBarValue2);
                this.Invoke(dele, new object[] { Object, Value });
            }
            else
            {
                SetProgressBarValue2(Object, Value);
            }
        }
        private void SetProgressBarValue2(ProgressBar Object, Int32 Value)
        {
            if (Value >= 0 && Value >= Object.Minimum && Value <= Object.Maximum)
                Object.Value = Value;
        }
        public delegate void SetProgressBarMaximumDelegate(ProgressBar Object, Int32 Maximum);
        public virtual void SetProgressBarMaximum(ProgressBar Object, Int32 Maximum)
        {
            if (this.InvokeRequired)
            {
                SetProgressBarMaximumDelegate dele = new SetProgressBarMaximumDelegate(SetProgressBarMaximum2);
                this.Invoke(dele, new object[] { Object, Maximum });
            }
            else
            {
                SetProgressBarMaximum2(Object, Maximum);
            }
        }
        private void SetProgressBarMaximum2(ProgressBar Object, Int32 Maximum)
        {
            if (Maximum > 0 && Maximum > Object.Minimum)
                Object.Maximum = Maximum;
        }
        public delegate Int32 GetProgressBarValueDelegate(ProgressBar Object);
        public virtual Int32 GetProgressBarValue(ProgressBar Object)
        {
            if (this.InvokeRequired)
            {
                GetProgressBarValueDelegate dele = new GetProgressBarValueDelegate(GetProgressBarValue2);
                return (Int32)this.Invoke(dele, new object[] { Object });
            }
            else
            {
                return GetProgressBarValue2(Object);
            }
        }
        private Int32 GetProgressBarValue2(ProgressBar Object)
        {
            return Object.Value;
        }
        public delegate Int32 GetProgressBarMaximumDelegate(ProgressBar Object);
        public virtual Int32 GetProgressBarMaximum(ProgressBar Object)
        {
            if (this.InvokeRequired)
            {
                GetProgressBarMaximumDelegate dele = new GetProgressBarMaximumDelegate(GetProgressBarMaximum2);
                return (Int32)this.Invoke(dele, new object[] { Object });
            }
            else
            {
                return GetProgressBarMaximum2(Object);
            }
        }
        private Int32 GetProgressBarMaximum2(ProgressBar Object)
        {
            return Object.Maximum;
        }

        //textbox
        public delegate void TextBoxClearDelegate(TextBox Object);
        public virtual void TextBoxClear(TextBox Object)
        {
            if (this.InvokeRequired)
            {
                TextBoxClearDelegate dele = new TextBoxClearDelegate(TextBoxClear2);
                this.Invoke(dele, new object[] { Object });
            }
            else
            {
                TextBoxClear2(Object);
            }
        }
        private void TextBoxClear2(TextBox Object)
        {
            Object.Clear();
        }
        public delegate void TextBoxAppendTextDelegate(TextBox Object, String Text);
        public virtual void TextBoxAppendText(TextBox Object, String Text)
        {
            if (this.InvokeRequired)
            {
                TextBoxAppendTextDelegate dele = new TextBoxAppendTextDelegate(TextBoxAppendText2);
                this.Invoke(dele, new object[] { Object, Text });
            }
            else
            {
                TextBoxAppendText2(Object, Text);
            }
        }
        private void TextBoxAppendText2(TextBox Object, String Text)
        {
            Object.AppendText(Text);
        }

        //listbox
        public delegate void ListBoxItemAddDelegate(ListBox Object, Object Item);
        public virtual void ListBoxItemAdd(ListBox Object, Object Item)
        {
            if (this.InvokeRequired)
            {
                ListBoxItemAddDelegate dele = new ListBoxItemAddDelegate(ListBoxItemAdd2);
                this.Invoke(dele, new object[] { Object, Item });
            }
            else
            {
                ListBoxItemAdd2(Object, Item);
            }
        }
        private void ListBoxItemAdd2(ListBox Object, Object Item)
        {
            Object.Items.Add(Item);
        }
        public delegate void SetListBoxSelectedIndexDelegate(ListBox Object, Int32 Value);
        public virtual void SetListBoxSelectedIndex(ListBox Object, Int32 Value)
        {
            if (this.InvokeRequired)
            {
                SetListBoxSelectedIndexDelegate dele = new SetListBoxSelectedIndexDelegate(SetListBoxSelectedIndex2);
                this.Invoke(dele, new object[] { Object, Value });
            }
            else
            {
                SetListBoxSelectedIndex2(Object, Value);
            }
        }
        private void SetListBoxSelectedIndex2(ListBox Object, Int32 Value)
        {
            Object.SelectedIndex = Value;
        }

        //treeview
        public delegate void TreeViewClearDelegate(TreeView Object);
        public virtual void TreeViewClear(TreeView Object)
        {
            if (this.InvokeRequired)
            {
                TreeViewClearDelegate dele = new TreeViewClearDelegate(TreeViewClear2);
                this.Invoke(dele, new object[] { Object });
            }
            else
            {
                TreeViewClear2(Object);
            }
        }
        private void TreeViewClear2(TreeView Object)
        {
            Object.Nodes.Clear();
        }

        //listview
        public delegate void ListViewClearDelegate(ListView Object);
        public virtual void ListViewClear(ListView Object)
        {
            if (this.InvokeRequired)
            {
                ListViewClearDelegate dele = new ListViewClearDelegate(ListViewClear2);
                this.Invoke(dele, new object[] { Object });
            }
            else
            {
                ListViewClear2(Object);
            }
        }
        private void ListViewClear2(ListView Object)
        {
            Object.Items.Clear();
            Object.Columns.Clear();
        }

        //listbox
        public delegate void ListBoxClearDelegate(ListBox Object);
        public virtual void ListViewClear(ListBox Object)
        {
            if (this.InvokeRequired)
            {
                ListBoxClearDelegate dele = new ListBoxClearDelegate(ListBoxClear2);
                this.Invoke(dele, new object[] { Object });
            }
            else
            {
                ListBoxClear2(Object);
            }
        }
        private void ListBoxClear2(ListBox Object)
        {
            Object.Items.Clear();
        }

        //combobox
        public delegate void SetComboBoxSelectedIndexDelegate(ComboBox Object, Int32 Value);
        public virtual void SetComboBoxSelectedIndex(ComboBox Object, Int32 Value)
        {
            if (this.InvokeRequired)
            {
                SetComboBoxSelectedIndexDelegate dele = new SetComboBoxSelectedIndexDelegate(SetComboBoxSelectedIndex2);
                this.Invoke(dele, new object[] { Object, Value });
            }
            else
            {
                SetComboBoxSelectedIndex2(Object, Value);
            }
        }
        private void SetComboBoxSelectedIndex2(ComboBox Object, Int32 Value)
        {
            Object.SelectedIndex = Value;
        }
        public delegate void SetComboBoxSelectedItemDelegate(ComboBox Object, Object Value);
        public virtual void SetComboBoxSelectedItem(ComboBox Object, Object Value)
        {
            if (this.InvokeRequired)
            {
                SetComboBoxSelectedItemDelegate dele = new SetComboBoxSelectedItemDelegate(SetComboBoxSelectedItem2);
                this.Invoke(dele, new object[] { Object, Value });
            }
            else
            {
                SetComboBoxSelectedItem2(Object, Value);
            }
        }
        private void SetComboBoxSelectedItem2(ComboBox Object, Object Value)
        {
            Object.SelectedItem = Value;
        }

        //tab control
        public delegate void TabControlSwitchTabDelegate(TabControl Object, Int32 Value);
        public virtual void TabControlSwitchTab(TabControl Object, Int32 Value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new TabControlSwitchTabDelegate(TabControlSwitchTab2), new object[] { Object, Value });
            }
            else
            {
                TabControlSwitchTab2(Object, Value);
            }
        }
        private void TabControlSwitchTab2(TabControl Object, Int32 Value)
        {
            Object.SelectedIndex = Value;
        }


        public virtual System.Windows.Forms.Control getControlRecursive(System.Windows.Forms.Control c, String ControlName)
        {
            if (c.HasChildren)
            {
                foreach (System.Windows.Forms.Control C in c.Controls)
                {
                    if (C.Name == ControlName)
                    {
                        return C;
                    }
                    else
                    {
                        System.Windows.Forms.Control d = getControlRecursive(C, ControlName);
                        if (!object.Equals(null, d))
                        {
                            return d;
                        }
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
