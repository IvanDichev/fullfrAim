﻿using System.Collections.Generic;

namespace Shared
{
    public static partial class Constants
    {
        public static class ImagesSeed
        {
            public const string AbstrctImgUrl = "https://res.cloudinary.com/fullfraim/image/upload/v1621962683/tlmnwsfoieruxk7qs3os.jpg";
            public const string ArchitectureImgUrl = "https://res.cloudinary.com/fullfraim/image/upload/v1621962698/q98fftipsjjsvzxxztd7.jpg";
            public const string CatImgUrl = "https://res.cloudinary.com/fullfraim/image/upload/v1621962948/s5e3jmgfwackbkqf1yri.jpg";
            public const string FineArtImgUrl = "https://res.cloudinary.com/fullfraim/image/upload/v1621962965/mn78itrfiweifoitfqki.jpg";
            public const string PortraitImgUrlCover = "https://res.cloudinary.com/fullfraim/image/upload/v1621962983/ska4ybfpaaioa4flg0bo.jpg";
            
            public const string WildlifeImgUrlCover = "https://res.cloudinary.com/fullfraim/image/upload/v1621963776/y37iclssc2ozv18fnioo.jpg";
            public const string WildlifeImgUrl = "https://res.cloudinary.com/fullfraim/image/upload/v1621962999/oq8rxujmom66tvv95jdp.jpg";
            public const string WildlifeImg2Url = "https://res.cloudinary.com/fullfraim/image/upload/v1621963016/voyi4dpg8wtoscgb07ut.png";
            public const string WildlifeImg3Url = "https://res.cloudinary.com/fullfraim/image/upload/v1621963121/lfmos6aoxpblo8b5cksr.jpg";
            public const string WildlifeImg4Url = "https://res.cloudinary.com/fullfraim/image/upload/v1621963134/kdgxq6iorhwjwpphlppn.jpg";
            public const string WildlifeImg5Url = "https://res.cloudinary.com/fullfraim/image/upload/v1621963145/r6hussj1vnw7etwjlwc1.jpg";
            public const string WildlifeImg6Url = "https://res.cloudinary.com/fullfraim/image/upload/v1621963217/rw0eyykyktcyb1ihqdkn.jpg";
        }

        public static class UserSeed
        {
            public const string Ivan = "Ivan";
            public const string Dichev = "Dichev";
            public const string IDichevEmail = "idichev@fullfraim.com";

            public const string Valentin = "Valentin";
            public const string Shikov = "Shikov";
            public const string VShikovEmail = "vshikov@";

            public const string Boryana = "Boryana";
            public const string Mihaylova = "Mihaylova";
            public const string BMihaylovaEmail = "BMihaylova@fullfraim.com";

            public const string Dimitar = "Dimitar";
            public const string Dimitrov = "Dimitrov";
            public const string DDimitrovEmail = "DDimitrov@fullfraim.com";

            public const string Emily = "Emily";
            public const string Ivanova = "Ivanova";
            public const string EIvanovaEmail = "EIvanova@fullfraim.com";
        }

        public static class RolesSeed
        {
            public const string Admin = "Admin";
            public const string Organizer = "Organizer";
            public const string User = "User";
        }

        public static class PhasesSeed
        {
            public const string PhaseI = "PhaseI";
            public const string PhaseII = "PhaseII";
            public const string Finished = "Finished";
        }

        public static class RanksSeed
        {
            public const string Junkie = "Junkie";
            public const string Enthusiast = "Enthusiast";
            public const string Master = "Master";
            public const string WiseAndBenevolentPhotoDictator = "Wise and Benevolent Photo Dictator";
        }

        public static class ConstestCategorySeed
        {
            public const string Abstract = "Abstract";
            public const string Architecture = "Architecture";
            public const string Conceptual = "Conceptual";
            public const string Fashion_Beauty = "Fashion/Beauty";
            public const string Fine_Art = "Fine Art";
            public const string Landscapes = "Landscapes";
            public const string Nature = "Natrue";
            public const string Boudoir = "Boudoir";
            public const string Photojournalism = "Photojournalism";
            public const string Portrait = "Portrait";
            public const string Street = "Street";
            public const string Wildlife = "Wildlife";
        }

        public static class ContestTypeSeed
        {
            public const string Open = "Open";
            public const string Invitational = "Invitational";
        }

        //Exception constants
        public class Exceptions
        {
            public const string APIFilterFail_Critical = "Api Exception filter failed to capture exception!";
            public const string AMVCFilterFail_Critical = "MVC Exception filter failed to capture exception!";
        }

        public static class Email
        {
            public const string SenderName = "FullFrAim";
            public const string NHours = "{0} hours";

            public const string ConfirmEmailSubject = "Confirm email";
            public const string ResetPasswordSubject = "Reset password";
        }

        public static class EmailContents
        {
            public const string ConfirmEmailStyles = @"<style type=""text/css"">
#outlook a {
padding:0;
}
.es-button {
mso-style-priority:100!important;
text-decoration:none!important;
}
a[x-apple-data-detectors] {
color:inherit!important;
text-decoration:none!important;
font-size:inherit!important;
font-family:inherit!important;
font-weight:inherit!important;
line-height:inherit!important;
}
.es-desk-hidden {
display:none;
float:left;
overflow:hidden;
width:0;
max-height:0;
line-height:0;
mso-hide:all;
}
[data-ogsb] .es-button {
border-width:0!important;
padding:10px 30px 10px 30px!important;
}
@media only screen and (max-width:600px) {p, ul li, ol li, a { line-height:150%!important } h1 { font-size:42px!important; text-align:center; line-height:120% } h2 { font-size:26px!important; text-align:center; line-height:120% } h3 { font-size:20px!important; text-align:center; line-height:120% } .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:42px!important } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:26px!important } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important } .es-menu td a { font-size:14px!important } .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a { font-size:16px!important } .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a { font-size:16px!important } .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a { font-size:16px!important } .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a { font-size:12px!important } *[class=""gmail-fix""] { display:none!important } .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 { text-align:right!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important } .es-button-border { display:block!important } a.es-button, button.es-button { font-size:16px!important; display:block!important; border-right-width:0px!important; border-left-width:0px!important; border-bottom-width:15px!important; border-top-width:15px!important } .es-adaptive table, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .es-adapt-td { display:block!important; width:100%!important } .adapt-img { width:100%!important; height:auto!important } .es-m-p0 { padding:0!important } .es-m-p0r { padding-right:0!important } .es-m-p0l { padding-left:0!important } .es-m-p0t { padding-top:0!important } .es-m-p0b { padding-bottom:0!important } .es-m-p20b { padding-bottom:20px!important } .es-mobile-hidden, .es-hidden { display:none!important } tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important } tr.es-desk-hidden { display:table-row!important } table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } table.es-social { display:inline-block!important } table.es-social td { display:inline-block!important } .es-m-p5 { padding:5px!important } .es-m-p5t { padding-top:5px!important } .es-m-p5b { padding-bottom:5px!important } .es-m-p5r { padding-right:5px!important } .es-m-p5l { padding-left:5px!important } .es-m-p10 { padding:10px!important } .es-m-p10t { padding-top:10px!important } .es-m-p10b { padding-bottom:10px!important } .es-m-p10r { padding-right:10px!important } .es-m-p10l { padding-left:10px!important } .es-m-p15 { padding:15px!important } .es-m-p15t { padding-top:15px!important } .es-m-p15b { padding-bottom:15px!important } .es-m-p15r { padding-right:15px!important } .es-m-p15l { padding-left:15px!important } .es-m-p20 { padding:20px!important } .es-m-p20t { padding-top:20px!important } .es-m-p20r { padding-right:20px!important } .es-m-p20l { padding-left:20px!important } .es-m-p25 { padding:25px!important } .es-m-p25t { padding-top:25px!important } .es-m-p25b { padding-bottom:25px!important } .es-m-p25r { padding-right:25px!important } .es-m-p25l { padding-left:25px!important } .es-m-p30 { padding:30px!important } .es-m-p30t { padding-top:30px!important } .es-m-p30b { padding-bottom:30px!important } .es-m-p30r { padding-right:30px!important } .es-m-p30l { padding-left:30px!important } .es-m-p35 { padding:35px!important } .es-m-p35t { padding-top:35px!important } .es-m-p35b { padding-bottom:35px!important } .es-m-p35r { padding-right:35px!important } .es-m-p35l { padding-left:35px!important } .es-m-p40 { padding:40px!important } .es-m-p40t { padding-top:40px!important } .es-m-p40b { padding-bottom:40px!important } .es-m-p40r { padding-right:40px!important } .es-m-p40l { padding-left:40px!important } }
</style>";

            public const string ConfirmEmail = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" style=""font-family:Montserrat, sans-serif"">
<head>
<meta charset=""UTF-8"">
<meta content=""width=device-width, initial-scale=1"" name=""viewport"">
<meta name=""x-apple-disable-message-reformatting"">
<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
<meta content=""telephone=no"" name=""format-detection"">

<link href=""https://fonts.googleapis.com/css2?family=Montserrat&display=swap"" rel=""stylesheet"">
<!--<![endif]-->
{4}
</head>
<body style=""width:100%;font-family:Montserrat, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0"">
<div class=""es-wrapper-color"" style=""background-color:#FFFFFF"">
<!--[if gte mso 9]>
<v:background xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""t"">
<v:fill type=""tile"" color=""#ffffff""></v:fill>
</v:background>
<![endif]-->
<table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#FFFFFF"">
<tr>
<td valign=""top"" style=""padding:0;Margin:0"">
<table cellpadding=""0"" cellspacing=""0"" class=""es-header"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top"">
<tr>
<td align=""center"" style=""padding:0;Margin:0"">
<table bgcolor=""#ffffff"" class=""es-header-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:700px"">
<tr>
<td align=""left"" style=""padding:0;Margin:0;padding-top:20px;padding-left:20px;padding-right:20px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:660px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" style=""padding:15px;Margin:0""><p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;line-height:54px;color:#333333;font-size:36px"">Full FrAim</p></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
<tr>
<td align=""left"" style=""Margin:0;padding-bottom:10px;padding-top:20px;padding-left:20px;padding-right:20px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td class=""es-m-p0r"" valign=""top"" align=""center"" style=""padding:0;Margin:0;width:660px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" style=""padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0"">
<table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td style=""padding:0;Margin:0;border-bottom:1px solid #CCCCCC;background:none;height:1px;width:100%;margin:0px""></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>
<table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
<tr>
<td align=""center"" style=""padding:0;Margin:0"">
<table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:700px"">
<tr>
<td align=""left"" style=""Margin:0;padding-bottom:20px;padding-left:20px;padding-right:20px;padding-top:40px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:660px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" style=""padding:0;Margin:0;font-size:0px""><img src=""https://lnafzz.stripocdn.email/content/guids/CABINET_2663efe83689b9bda1312f85374f56d2/images/10381620386430630.png"" alt style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" width=""100""></td>
</tr>
<tr>
<td align=""center"" style=""padding:0;Margin:0""><h2 style=""Margin:0;line-height:43px;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;font-size:36px;font-style:normal;font-weight:normal;color:#333333"">Verify your email to finish signing up</h2></td>
</tr>
<tr>
<td align=""center"" class=""es-m-txt-c"" style=""padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0"">
<table border=""0"" width=""40%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:40% !important;display:inline-table"" role=""presentation"">
<tr>
<td style=""padding:0;Margin:0;border-bottom:1px solid #CCCCCC;background:none;height:1px;width:100%;margin:0px""></td>
</tr>
</table></td>
</tr>
<tr>
<td align=""center"" class=""es-m-p0r"" style=""padding:0;Margin:0;padding-top:5px;padding-bottom:5px;padding-right:40px""><p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;line-height:24px;color:#333333;font-size:16px"">Welcome to Full FrAim.</p><p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;line-height:24px;color:#333333;font-size:16px""><br></p><p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;line-height:24px;color:#333333;font-size:16px"">Please confirm that <strong><a target=""_blank"" href=""{0}"" style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:none;color:#134F5C;font-size:16px"">{0}</a></strong>&nbsp;is your email address by clicking on the button below or use this link <a target=""_blank"" href=""{1}"" style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:none;color:#134F5C;font-size:16px;word-break:break-all"">{2}</a> within <strong>{3}</strong>.</p></td>
</tr>
<tr>
<td align=""center"" class=""es-m-txt-c"" style=""padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0"">
<table border=""0"" width=""40%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:40% !important;display:inline-table"" role=""presentation"">
<tr>
<td style=""padding:0;Margin:0;border-bottom:1px solid #CCCCCC;background:none;height:1px;width:100%;margin:0px""></td>
</tr>
</table></td>
</tr>
<tr>
<td align=""center"" class=""es-m-txt-l"" style=""padding:0;Margin:0;padding-top:10px;padding-bottom:10px""><span class=""es-button-border"" style=""border-style:solid;border-color:#999999;background:#FFFFFF;border-width:1px;display:inline-block;border-radius:0px;width:auto""><a href=""{1}"" class=""es-button"" target=""_blank"" style=""mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;color:#666666;font-size:16px;border-style:solid;border-color:#FFFFFF;border-width:10px 30px 10px 30px;display:inline-block;background:#FFFFFF;border-radius:0px;font-family:Montserrat, sans-serif;font-weight:normal;font-style:normal;line-height:19px;width:auto;text-align:center"">Verify my email</a></span></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>
<table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
<tr>
<td align=""center"" style=""padding:0;Margin:0"">
<table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:700px"">
<tr>
<td align=""left"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px;padding-top:40px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:660px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" style=""padding:0;Margin:0""><h2 style=""Margin:0;line-height:43px;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;font-size:36px;font-style:normal;font-weight:normal;color:#333333"">Need help?</h2></td>
</tr>
<tr>
<td align=""center"" class=""es-m-txt-c"" style=""padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0"">
<table border=""0"" width=""40%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:40% !important;display:inline-table"" role=""presentation"">
<tr>
<td style=""padding:0;Margin:0;border-bottom:1px solid #CCCCCC;background:none;height:1px;width:100%;margin:0px""></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
<tr>
<td align=""left"" style=""padding:0;Margin:0;padding-top:20px;padding-left:20px;padding-right:20px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:660px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" class=""es-m-txt-l"" style=""padding:0;Margin:0;padding-bottom:5px;padding-top:10px""><h3 style=""Margin:0;line-height:24px;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;font-size:20px;font-style:normal;font-weight:normal;color:#333333"">Ask at</h3></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
<tr>
<td align=""left"" style=""padding:0;Margin:0;padding-top:20px;padding-left:20px;padding-right:20px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:660px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""left"" class=""es-m-txt-l"" style=""padding:0;Margin:0;padding-top:10px;padding-bottom:10px""><span class=""es-button-border"" style=""border-style:solid;border-color:#999999;background:#FFFFFF;border-width:1px;display:block;border-radius:0px;width:auto""><a href="""" class=""es-button"" target=""_blank"" style=""mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;color:#666666;font-size:16px;border-style:solid;border-color:#FFFFFF;border-width:10px 30px 10px 30px;display:block;background:#FFFFFF;border-radius:0px;font-family:Montserrat, sans-serif;font-weight:normal;font-style:normal;line-height:19px;width:auto;text-align:center;border-left-width:30px;border-right-width:30px"">FullFrAim@gmail.com</a></span></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>
<table cellpadding=""0"" cellspacing=""0"" class=""es-footer"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top"">
<tr>
<td align=""center"" style=""padding:0;Margin:0"">
<table bgcolor=""#ffffff"" class=""es-footer-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:700px"">
<tr>
<td align=""left"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""left"" style=""padding:0;Margin:0;width:660px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" style=""padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0"">
<table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td style=""padding:0;Margin:0;border-bottom:1px solid #CCCCCC;background:none;height:1px;width:100%;margin:0px""></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
<tr>
<td align=""left"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""left"" style=""padding:0;Margin:0;width:660px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" style=""padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0"">
<table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td style=""padding:0;Margin:0;border-bottom:1px solid #CCCCCC;background:none;height:1px;width:100%;margin:0px""></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
<tr>
<td align=""left"" style=""padding:20px;Margin:0"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:660px"">
<table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
<tr>
<td align=""center"" style=""padding:0;Margin:0""><p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;line-height:18px;color:#333333;font-size:12px"">You are receiving this email because you have visited our site or asked us about the regular newsletter. Make sure our messages get to your Inbox (and not your bulk or junk folders).<br></p></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>
</div>
</body>
</html>";

            public const string PasswordResetLink = @"Follow the link to reset your password: <a href='{0}'>Reset password</a>";
        }

        public static class TempDataNotifications
        {
            public const string PasswordResetTokenSuccessfullySend = "Password reset token successfully send";
        }
    }
}
