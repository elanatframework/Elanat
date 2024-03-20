async function el_RestoreBackup(BackupPhysicalName)
{
	var OkClick = await el_Confirm(BackupLanguageVariant.Restore);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                alert("ok");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/backup/action/RestoreBackup.aspx?backup_physical_name=" + BackupPhysicalName, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteBackup(obj, BackupPhysicalName)
{
	var OkClick = await el_Confirm(BackupLanguageVariant.Delete);

    if (!OkClick)
        return;

    var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
            el_RemoveParentNode(obj);

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/backup/action/DeleteBackup.aspx?backup_physical_name=" + BackupPhysicalName, false);
    xmlhttp.send();
}

async function el_DeleteSelectedBackup()
{
	var ArrayBackupPhysicalName = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
    {
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
        {
            ArrayBackupPhysicalName[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(BackupLanguageVariant.Delete);
    if (OkClick)
    {
        var ArrayBackupPhysicalNameLength = ArrayBackupPhysicalName.length;
        var i = 0;
        while (i < ArrayBackupPhysicalNameLength)
        {
            var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");


            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                {
                    var RowItem = document.getElementById("cbx_Item" + ArrayBackupPhysicalName[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/backup/action/DeleteBackup.aspx?backup_physical_name=" + ArrayBackupPhysicalName[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

function el_SelectAllItem(obj)
{
	var CheckCheckedUnchecked = null;
    if (obj.checked)
        CheckCheckedUnchecked = "cheched";

    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        CheckBoxItem.checked = CheckCheckedUnchecked;
        i++;
    }
}