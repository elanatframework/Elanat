function el_GoToAvatarDirectory(Path)
{
	var CurrentPath = document.getElementById("hdn_Path").value;

    if (CurrentPath != "")
        CurrentPath += "/";

    window.location = "?path=" + CurrentPath + Path;
}

function el_ReturnDirectory()
{
	var CurrentPath = document.getElementById("hdn_Path").value;

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

function el_AddContentAvatar(AvatarName)
{
	if (window.parent.document.getElementsByClassName("el_iframe_load").length > 0)
    {
        var IframeLoad = window.parent.document.getElementsByClassName("el_iframe_load");
        for (var IframeIndexer = 0; IframeIndexer < IframeLoad.length; IframeIndexer++)
        {
            if (!IframeLoad.item(IframeIndexer).contentWindow.document.getElementById("div_ContentAvatar"))
                return;

            var Div_ContentAvatar = IframeLoad.item(IframeIndexer).contentWindow.document.getElementById("div_ContentAvatar");
            var HiddenContentAvatar = IframeLoad.item(IframeIndexer).contentWindow.document.getElementById("hdn_ContentAvatar");

            if (AvatarName == "none")
            {
                Div_ContentAvatar.style.backgroundImage = "url('" + ElanatVariant.SitePath + "client/image/content_avatar/none.png')";
                HiddenContentAvatar.value = "";
            }
            else
            {
                Div_ContentAvatar.style.backgroundImage = "url('" + ElanatVariant.SitePath + "client/image/content_avatar/" + AvatarName + "')";
                HiddenContentAvatar.value = AvatarName;
            }
        }
    }

    if (!document.getElementById("div_ContentAvatar"))
        return;

    var Div_ContentAvatar = document.getElementById("div_ContentAvatar");
    Div_ContentAvatar.style.backgroundImage = "url('" + ElanatVariant.SitePath + "client/image/content_avatar/" + AvatarName + "')";
    var HiddenContentAvatar = document.getElementById("hdn_ContentAvatar");
    HiddenContentAvatar.value = AvatarName;
}