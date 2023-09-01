function el_SetConnectionValue()
{
    var ServerName = document.getElementById("txt_ServerName").value;
    var DatabaseName = document.getElementById("txt_DatabaseName").value;
    var UserId = document.getElementById("txt_UserId").value;
    var Password = document.getElementById("txt_Password").value;
    document.getElementById("txt_ConnectionString").value = "Server=" + ServerName + ";Database=" + DatabaseName + ";User Id=" + UserId + ";Password=" + Password + ";";
}