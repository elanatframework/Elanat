function el_RefreshUserAvatar(UserId)
{
    var ImageSiteLogo = document.getElementById("img_AvatarLogo");
    ImageSiteLogo.setAttribute("src", ElanatVariant.SitePath + "client/image/user_avatar/" + UserId + ".png?random=" + Math.floor(Math.random() * 1000000));
}