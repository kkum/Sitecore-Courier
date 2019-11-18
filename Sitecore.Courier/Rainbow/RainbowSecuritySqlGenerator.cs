﻿using System.Text;
using Sitecore.Security.Serialization.ObjectModel;
using Unicorn.Roles.Model;

namespace ConsoleApp1
{
    public class RainbowSecuritySqlGenerator
    {
        public string GenerateAddUserStatements(SyncUser user)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("DECLARE @UserName nvarchar(256)");
            stringBuilder.AppendLine("DECLARE @Email nvarchar(256)");
            stringBuilder.AppendLine($"SET @UserName= '{user.UserName}'");
            stringBuilder.AppendLine($"SET @Email= '{user.Email}'");
            stringBuilder.AppendLine("DECLARE @Now datetime");
            stringBuilder.AppendLine("SET @Now=GETDATE()");
            stringBuilder.AppendLine("EXEC aspnet_Membership_CreateUser 'sitecore',@userName,'qOvF8m8F2IcWMvfOBjJYHmfLABc=', 'OM5gu45RQuJ76itRvkSPFw==',@Email,'','',1,@Now,@Now,0,0,null");

            stringBuilder.AppendLine("DECLARE @UserId nvarchar(256)");
            stringBuilder.AppendLine("SELECT TOP 1 @UserId = [UserId] FROM [aspnet_Users] WHERE [UserName] = @UserName");
            stringBuilder.AppendLine("UPDATE [aspnet_Membership] SET [PasswordFormat] = '1' WHERE UserId = @UserId");

            stringBuilder.AppendLine("INSERT [dbo].[aspnet_Profile] ([UserId], [PropertyNames], [PropertyValuesString], [PropertyValuesBinary], [LastUpdatedDate])");
            stringBuilder.AppendLine(" VALUES (@UserId,");
            stringBuilder.AppendLine("  N'IsAdministrator:S:0:5:Portrait:S:5:29:ProfileItemId:S:34:38:SerializedData:B:0:3875:', ");
            stringBuilder.AppendLine("  N'Falseoffice/16x16/default_user.png{AE4C4969-5B7E-4B4E-9042-B2D8701CE214}', ");
            stringBuilder.AppendLine("  0x0001000000FFFFFFFF01000000000000000401000000E20153797374656D2E436F6C6C656374696F6E732E47656E657269632E44696374696F6E61727960325B5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D2C5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D5D040000000756657273696F6E08436F6D7061726572084861736853697A650D4B657956616C756550616972730003000308920153797374656D2E436F6C6C656374696F6E732E47656E657269632E47656E65726963457175616C697479436F6D706172657260315B5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D5D08E60153797374656D2E436F6C6C656374696F6E732E47656E657269632E4B657956616C75655061697260325B5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D2C5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D5D5B5DCE00000009020000002500000009030000000402000000920153797374656D2E436F6C6C656374696F6E732E47656E657269632E47656E65726963457175616C697479436F6D706172657260315B5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D5D00000000070300000000010000001500000003E40153797374656D2E436F6C6C656374696F6E732E47656E657269632E4B657956616C75655061697260325B5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D2C5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D5D04FCFFFFFFE40153797374656D2E436F6C6C656374696F6E732E47656E657269632E4B657956616C75655061697260325B5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D2C5B53797374656D2E537472696E672C206D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038395D5D02000000036B65790576616C7565010106050000000957616C6C70617065720606000000312F73697465636F72652F7368656C6C2F7468656D65732F6261636B67726F756E64732F6C69676874686F7573652E6A706701F9FFFFFFFCFFFFFF06080000001357616C6C70617065724261636B67726F756E640609000000072330373333374301F6FFFFFFFCFFFFFF060B0000001157616C6C7061706572506F736974696F6E060C0000000643656E74657201F3FFFFFFFCFFFFFF060E0000001464696765737463726564656E7469616C68617368060F00000020373130373464333335653834393632396562616532383434656165333436306101F0FFFFFFFCFFFFFF06110000002164696765737463726564656E7469616C68617368776974686F7574646F6D61696E061200000020313961323764323333663534633962303930303764303533326634666464343301EDFFFFFFFCFFFFFF06140000001F2F73697465636F72655C61646D696E2F526962626F6E2F4D792053747269700615000000267B44333341303634312D394631432D343938342D383334322D3036353543334430463132337D01EAFFFFFFFCFFFFFF06170000000D5061636B616765722F46696C6506180000002F536D61727420546F6F6C7320204164642056657273696F6E20616E6420436F707920436F6E74656E7431302E7A697001E7FFFFFFFCFFFFFF061A000000372F73697465636F72655C61646D696E2F557365724F7074696F6E732E436F6E74656E74456469746F722E56697369626C65537472697073061B000000AC037B43334643454242392D463338462D344142342D383537462D4346433431354236413334327D7C7B44304643393944392D354336352D343341332D414342362D3434393544343446423045377D7C7B39324144453739322D363833462D343830442D413330412D3031433146314241414235337D7C7B46353142433531412D463541462D343144462D414431312D4630443142343846464339337D7C7B36353533363336462D453930342D344632442D423232322D3039304430413236323938437D7C7B34434636343731362D384238432D344142432D383643322D4639433546334646313132387D7C7B44363030433133392D393244372D343844452D424239462D3438313241334442394138427D7C7B34383936374331392D433338372D343534442D384544322D3536324446313430394430387D7C7B41454439354537452D383734412D344346302D393234422D3844443930464338443733307D7C7B33333645393943382D433435462D344342372D393133362D4339463846453830324538467D7C7B42423246424235352D454243382D343732342D394131462D3337424346454430333730447D01E4FFFFFFFCFFFFFF061D000000312F73697465636F72655C61646D696E2F436F6E74656E7420456469746F722F53656374696F6E732F436F6C6C6170736564061E0000000B517569636B496E666F3D3001E1FFFFFFFCFFFFFF0620000000232F73697465636F72655C61646D696E2F4D656469612F55706C6F616465644974656D730621000000E0043230313430323039543231303432342373697465636F72653A2F2F6D61737465722F7B44363441363142352D463836332D343634432D423534352D3045434639423637373141437D3F6C616E673D64652D4445267665723D317C73697465636F72653A2F2F6D61737465722F7B35413631433446392D363730322D343143352D424245422D3131393439453243453345467D3F6C616E673D64652D4445267665723D317C73697465636F72653A2F2F6D61737465722F7B31413033373138442D364338462D343732322D424332352D3635464539424245353839367D3F6C616E673D64652D4445267665723D317C73697465636F72653A2F2F6D61737465722F7B39464445464539452D343742332D343532392D394333332D3431394230333239314430467D3F6C616E673D64652D4445267665723D317C73697465636F72653A2F2F6D61737465722F7B38374530313239352D363545342D343943372D383939442D3544304441433744434534387D3F6C616E673D64652D4445267665723D317C73697465636F72653A2F2F6D61737465722F7B34393134424644442D303830392D344635302D413235332D3545423030353232454544337D3F6C616E673D64652D4445267665723D317C73697465636F72653A2F2F6D61737465722F7B42373138433944302D383636332D343746342D424635392D3245434443354633353038317D3F6C616E673D64652D4445267665723D317C73697465636F72653A2F2F6D61737465722F7B42443643364230462D304333382D344433432D393131322D3141444535443537434536347D3F6C616E673D64652D4445267665723D317C01DEFFFFFFFCFFFFFF0623000000212F73697465636F72655C61646D696E2F5075626C6973682F4C616E677561676573062400000002656E01DBFFFFFFFCFFFFFF06260000001F2F73697465636F72655C61646D696E2F5075626C6973682F546172676574730627000000267B38453038303632362D444443332D344546342D413144312D4630424534413230303235347D01D8FFFFFFFCFFFFFF06290000002A2F73697465636F72655C61646D696E2F5075626C6973682F496E6372656D656E74616C5075626C697368062A0000000566616C736501D5FFFFFFFCFFFFFF062C000000242F73697465636F72655C61646D696E2F5075626C6973682F536D6172745075626C697368092A00000001D2FFFFFFFCFFFFFF062F000000212F73697465636F72655C61646D696E2F5075626C6973682F52657075626C6973680630000000047472756501CFFFFFFFFCFFFFFF0632000000272F73697465636F72655C61646D696E2F5075626C6973682F5075626C6973684368696C6472656E093000000001CCFFFFFFFCFFFFFF0635000000282F73697465636F72655C61646D696E2F436F6E74656E7420456469746F722F4C616E67756167657306360000000B65742D45457C656E2D474201C9FFFFFFFCFFFFFF0638000000222F73697465636F72655C61646D696E2F4C69737476696577732F4974656D4C69737406390000000744657461696C7301C6FFFFFFFCFFFFFF063B0000001F2F73697465636F72655C61646D696E732F526563656E74557365724C697374063C0000001173697465636F72655C546573745573657201C3FFFFFFFCFFFFFF063E000000292F73697465636F72655C61646D696E2F486973746F72792F4164642E46726F6D2E54656D706C617465063F000000267B42463242384441322D334342412D343835442D384638352D3337383842384146424442467D01C0FFFFFFFCFFFFFF0641000000202F73697465636F72655C61646D696E2F486973746F72792F54656D706C6174650642000000267B42463242384441322D334342412D343835442D384638352D3337383842384146424442467D0B, GETUTCDATE())");
            stringBuilder.AppendLine("GO");
            return stringBuilder.ToString();
        }

        public string GenerateAddRoleStatements(IRoleData role)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("DECLARE @applicationId nvarchar(256)");
            stringBuilder.AppendLine("SELECT TOP 1 @applicationId = [ApplicationId] FROM [aspnet_Applications] WHERE [ApplicationName] = 'sitecore'");
            stringBuilder.AppendLine(string.Concat("IF NOT EXISTS (SELECT TOP 1 [RoleId] FROM [aspnet_Roles] WHERE [ApplicationId] = @applicationId AND [RoleName] = '", role.RoleName, "')"));
            stringBuilder.AppendLine("BEGIN");
            stringBuilder.AppendLine("    INSERT INTO [aspnet_Roles] (ApplicationId, RoleId, RoleName, LoweredRoleName, Description)");
            stringBuilder.AppendLine(string.Concat(new string[] { "    VALUES (@applicationId, NEWID(), '", role.RoleName, "', LOWER('", role.RoleName, "'), NULL)" }));
            stringBuilder.AppendLine("END");
            foreach (string membership in role.MemberOfRoles)
            {
                stringBuilder.AppendLine(string.Concat(new string[] { "IF NOT EXISTS (SELECT TOP 1 * FROM [RolesInRoles] WHERE [MemberRoleName] = '", role.RoleName, "' AND [TargetRoleName] = '", membership, "')" }));
                stringBuilder.AppendLine("BEGIN");
                stringBuilder.AppendLine("    INSERT INTO [RolesInRoles] (Id, MemberRoleName, TargetRoleName, ApplicationName, Created)");
                stringBuilder.AppendLine(string.Concat(new string[] { "    VALUES (NEWID(), '", role.RoleName, "', '", membership, "', '', SYSUTCDATETIME())" }));
                stringBuilder.AppendLine("END");
            }
            stringBuilder.AppendLine("GO");
            return stringBuilder.ToString();
        }

        public string GenerateAddUserToRoleStatements(string userName, string roleName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("DECLARE @ApplicationId nvarchar(256)");
            stringBuilder.AppendLine("SELECT TOP 1 @ApplicationId = [ApplicationId] FROM [aspnet_Applications] WHERE [ApplicationName] = 'sitecore'");

            stringBuilder.AppendLine("DECLARE @UserName nvarchar(256)");
            stringBuilder.AppendLine($"SET @UserName = '{userName}'");

            stringBuilder.AppendLine("DECLARE @RoleName nvarchar(256)");
            stringBuilder.AppendLine($"SET @RoleName = '{roleName}'");

            stringBuilder.AppendLine("DECLARE @UserId nvarchar(256)");
            stringBuilder.AppendLine("SELECT TOP 1 @UserId = [UserId] FROM [aspnet_Users] WHERE [UserName] = @UserName");

            stringBuilder.AppendLine("DECLARE @RoleId nvarchar(256)");
            stringBuilder.AppendLine("SELECT TOP 1 @RoleId = [RoleId] FROM [aspnet_Roles] WHERE [RoleName] = @RoleName");

            stringBuilder.AppendLine("IF NOT EXISTS (SELECT TOP 1 [RoleId] FROM [aspnet_UsersInRoles] WHERE [UserId] = @UserId AND [RoleId] = @RoleId) AND @RoleId IS NOT NULL");
            stringBuilder.AppendLine("BEGIN");
            stringBuilder.AppendLine("    INSERT INTO [aspnet_UsersInRoles] (RoleId, UserId) VALUES (@RoleId, @UserId)");
            stringBuilder.AppendLine("END");
            stringBuilder.AppendLine("GO");
            return stringBuilder.ToString();
        }
    }
}