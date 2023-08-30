function el_GetSiteLogo()
{
    var ImageSiteLogo = document.getElementById("img_SiteLogo");
    var DropDownSiteLogo = document.getElementById("ddlst_Site");
    ImageSiteLogo.setAttribute("src", ElanatVariant.SitePath + "client/image/site_logo/" + DropDownSiteLogo.value + ".png");
}

function el_RefreshSiteLogo()
{
    var ImageSiteLogo = document.getElementById("img_SiteLogo");
    var DropDownSiteLogo = document.getElementById("ddlst_Site");
    ImageSiteLogo.setAttribute("src", ElanatVariant.SitePath + "client/image/site_logo/" + DropDownSiteLogo.value + ".png?random=" + Math.floor(Math.random() * 1000000));
}