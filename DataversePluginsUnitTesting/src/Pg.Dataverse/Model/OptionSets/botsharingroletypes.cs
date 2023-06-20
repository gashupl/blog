#pragma warning disable CS1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pg.Dataverse.Model
{
	
	
	/// <summary>
	/// Type of sharing roles associated with Power Virtual Agents bots.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Dataverse Model Builder", "1.0.0.24")]
	public enum botsharingroletypes
	{
		
		/// <summary>
		/// A manager has full access to all bot content, can publish content, is accountable for bot operations, and can configure hand-off, channels and other operational information.
		/// </summary>
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Chatbotmanager = 1,
		
		/// <summary>
		/// Creates, edit and maintains bot content (trigger phrases, topic content, entities and variables). USes Power Automate solutions, authentication action and other extensibility integrations (e.g. skill) provided by developers in content editing.
		/// </summary>
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Chatbotauthor = 2,
		
		/// <summary>
		/// View bot performance in analytics section, monitors CSAT, provides feedback and suggestions.
		/// </summary>
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Chatbotreviewer = 3,
	}
}
#pragma warning restore CS1591