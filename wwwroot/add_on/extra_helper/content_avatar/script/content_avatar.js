var GoToDeleteConflict = false;
function el_GoToAvatarDirectory(Path)
{
    if (GoToDeleteConflict)
    {
        GoToDeleteConflict = false;
        return;
    }

	var CurrentPath = document.getElementById("hdn_ContentAvatarPath").value;

    if (CurrentPath != "")
        CurrentPath += "/";

    window.location = "?path=" + CurrentPath + Path;
}

function el_ReturnDirectory()
{
	var CurrentPath = document.getElementById("hdn_ContentAvatarPath").value;

    var ArrayPath = CurrentPath.split("/");

    var Path = "";

    for (var i = 0; i < ArrayPath.length - 1; i++)
    {
        Path += ArrayPath[i] + "/";
    }

    if (Path[Path.length -1] == "/")
        Path = Path.slice(0, -1);

    window.location = "?path=" + Path;
}

async function el_DeleteAvatar(obj, AvatarName)
{
	if (AvatarName == "none.png")
        return;

    var OkClick = await el_Confirm(AvatarLanguageVariant.Delete);

    if (!OkClick)
        return;

    var CurrentPath = document.getElementById("hdn_ContentAvatarPath").value;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
            el_RemoveParentNode(obj);

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", ElanatVariant.SitePath + "add_on/extra_helper/content_avatar/action/DeleteAvatar.aspx?avatar_path=" + CurrentPath + "/" + AvatarName, false);
    xmlhttp.send();
}

async function el_DeleteDirectory(obj, DirectoryName)
{
    GoToDeleteConflict = true;

    var OkClick = await el_Confirm(AvatarLanguageVariant.DeleteDirectory);

    if (!OkClick)
        return;

    var CurrentPath = document.getElementById("hdn_ContentAvatarPath").value;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
            el_RemoveParentNode(obj);

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", ElanatVariant.SitePath + "add_on/extra_helper/content_avatar/action/DeleteDirectory.aspx?directory_path=" + CurrentPath + "/" + DirectoryName, false);
    xmlhttp.send();
}