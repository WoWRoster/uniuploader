using System;
using System.Collections;

namespace PluginInterface
{
	public interface IPlugin
	{
		IPluginHost Host {get;set;}
		
		string Name {get;}
		string Description {get;}
		string Author {get;}
		string Version {get;}
		
		System.Windows.Forms.UserControl MainInterface {get;}
		
		void Initialize();
		void Dispose();
		void message(Hashtable data);
	}
	
	public interface IPluginHost
	{
		void plugin_send_message(string message, IPlugin Plugin);	
		void plugin_send_message(string message, Hashtable data, IPlugin Plugin);	
		Hashtable uu_get_message();
		void uu_send_message(string message, Hashtable data);
	}
}
