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
	/// Authentication protocol used when connecting to the email server.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Dataverse Model Builder", "1.0.0.24")]
	public enum emailserverprofile_authenticationprotocol
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		AutoDetect = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Negotiate = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		NTLM = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Basic = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		OAuth = 4,
	}
}
#pragma warning restore CS1591
