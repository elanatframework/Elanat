function el_SetConnectionValue()
{
    var ServerName = document.getElementById("txt_ServerName").value;
    var DatabaseName = document.getElementById("txt_DatabaseName").value;
    var UserId = document.getElementById("txt_UserId").value;
    var Password = document.getElementById("txt_Password").value;
    document.getElementById("txt_ConnectionString").value = "Server=" + ServerName + ";Database=" + DatabaseName + ";User Id=" + UserId + ";Password=" + Password + ";";
}

function el_CutInstallDirectoryAfterInstall()
{
    var xmlhttp = (window.XMLHttpRequest)? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
	{

    }
		
    xmlhttp.open("GET", ElanatVariant.SitePath + "install/action/CutInstallDirectoryAfterInstall.aspx", false);
    xmlhttp.send();
}