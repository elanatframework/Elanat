function el_OpenElanatBox(IdName,Width,Height)
{
    // Hide Body Scroll
    el_SetHiddenBodyScroll();

    // Load Saved Elanat Box
    if (document.getElementById("elanat_box_" + IdName))
    {
        document.getElementById("elanat_box_" + IdName).className = "elanat_box_show";
    }
    else if (parent.document.getElementById("elanat_box_" + IdName))
    {
        // Load Saved Elanat Box From Parrent Iframe
        parent.document.getElementById("elanat_box_" + IdName).className = "elanat_box_show";
    }
    else
    {
        var IdNameElement = document.getElementById(IdName);

        var div_ElanatBox = document.createElement("div");
        div_ElanatBox.id = "elanat_box_" + IdName;
        div_ElanatBox.className = "elanat_box_show";

        var div_FullPage = document.createElement("div");
        div_FullPage.className = "elanat_box_full_page";
        div_FullPage.setAttribute("onclick", "el_CloseElanatBox('" + IdName + "')");

        div_ElanatBox.appendChild(div_FullPage);

        var div_Body = document.createElement("div");
        div_Body.className = "elanat_box";
        div_Body.setAttribute("onclick", "javascript:void(0)");


        // Set Width And Height
        if (Width)
            div_Body.style.width = Width + "px";

        if (Height)
            div_Body.style.height = Height + "px";


        var div_head = document.createElement("div");
        div_head.className = "elanat_box_head";
        div_head.setAttribute("ondblclick", "el_MaximizeElanatBox('" + div_ElanatBox.id + "')");

        var div_CloseBox = document.createElement("div");
        div_CloseBox.className = "elanat_box_close";

        var div_ImageClose = document.createElement("div");
        div_ImageClose.className = "elanat_box_img_close";
        div_ImageClose.setAttribute("onclick", "el_CloseElanatBox('" + IdName + "')");

        var div_Title = document.createElement("div");
        div_Title.className = "elanat_box_title";
        div_Title.innerHTML = IdNameElement.title;

        var div_MaximizeBox = document.createElement("div");
        div_MaximizeBox.className = "elanat_box_close";

        var div_Maximize = document.createElement("div");
        div_Maximize.className = "elanat_box_maximize";
        div_Maximize.setAttribute("onclick", "el_MaximizeElanatBox('" + div_ElanatBox.id + "')");

        div_MaximizeBox.appendChild(div_Maximize)

        var div_Main = document.createElement("div");
        div_Main.className = "elanat_box_main";
				
        var div_MinimizeElanatBox = document.createElement("div");
        div_MinimizeElanatBox.className = "elanat_box_close_saved_box";
        div_MinimizeElanatBox.setAttribute("onclick", "el_MinimizeElanatBox('" + "elanat_box_" + IdName + "')");
        div_MinimizeElanatBox.innerText = "-";

        var div_Content = document.createElement("div");
        div_Content.innerHTML = IdNameElement.outerHTML;

        div_Content.className = "el_inner_box";
        div_Content.id = "elanat_box_id_" + IdNameElement.id;

        if (IdNameElement.className == "elanat_box_hidden")
        {
            div_Content.getElementsByTagName(IdNameElement.tagName)[0].className = "";
            IdNameElement.outerHTML = null;
        }


        div_CloseBox.appendChild(div_ImageClose);
        div_head.innerHTML = div_Title.outerHTML + div_CloseBox.outerHTML + div_MaximizeBox.outerHTML;
        div_Main.innerHTML = div_MinimizeElanatBox.outerHTML + div_Content.outerHTML;
        div_Body.innerHTML = div_head.outerHTML + div_Main.outerHTML;
        div_ElanatBox.appendChild(div_Body);

        (el_PageLoadWithIframeCheck()) ? parent.document.body.appendChild(div_ElanatBox) : document.body.appendChild(div_ElanatBox);

        // Remove Hidden Element
        if(document.getElementById(IdName).className == "el_hidden")
            document.getElementById(IdName).outerHTML = null;
    }
}

function el_SetHiddenBodyScroll()
{
    if (el_PageLoadWithIframeCheck())
        (parent.document.body.getAttribute("class")) ? parent.document.body.className += " elanat_box_hidden_scroll" : parent.document.body.setAttribute("class", "elanat_box_hidden_scroll");
    else 
        (document.body.getAttribute("class")) ? document.body.className += " elanat_box_hidden_scroll" : document.body.setAttribute("class", "elanat_box_hidden_scroll");
}

function el_DeleteHiddenBodyScroll()
{
    if (el_PageLoadWithIframeCheck())
    {
        if (parent.document.body.getAttribute("class"))
            (parent.document.body.className == "elanat_box_hidden_scroll") ? parent.document.body.removeAttribute("class") : parent.document.body.className = parent.document.body.className.replace("elanat_box_hidden_scroll", "");
    }
    else
    {
        if (document.body.getAttribute("class"))
            (document.body.className == "elanat_box_hidden_scroll") ? document.body.removeAttribute("class") : document.body.className = document.body.className.replace("elanat_box_hidden_scroll", "");
    }
}

function el_MinimizeElanatBox(IdName)
{
    (el_PageLoadWithIframeCheck()) ? parent.document.getElementById(IdName).className = "elanat_box_hidden" : document.getElementById(IdName).className = "elanat_box_hidden";

    el_DeleteHiddenBodyScroll();
}
	
function el_CloseElanatBox(IdName)
{
    if (!document.getElementById(IdName))
        return;

    if (el_PageLoadWithIframeCheck())
        parent.document.getElementById("elanat_box_" + IdName).outerHTML = null;
    else
        document.getElementById("elanat_box_" + IdName).outerHTML = null;

    el_DeleteHiddenBodyScroll();
}

function el_MaximizeElanatBox(TagId)
{
    var ClassName = (el_PageLoadWithIframeCheck()) ? parent.document.getElementById(TagId).getElementsByClassName("elanat_box").item(0).className : document.getElementById(TagId).getElementsByClassName("elanat_box").item(0).className;

    if (parseInt(ClassName.indexOf("maximize")) < 0)
        (el_PageLoadWithIframeCheck()) ? parent.document.getElementById(TagId).getElementsByClassName("elanat_box").item(0).className = ClassName + " maximize" : document.getElementById(TagId).getElementsByClassName("elanat_box").item(0).className = ClassName + " maximize";
    else
        (el_PageLoadWithIframeCheck()) ? parent.document.getElementById(TagId).getElementsByClassName("elanat_box").item(0).className = ClassName.replace(" maximize", "") : document.getElementById(TagId).getElementsByClassName("elanat_box").item(0).className = ClassName.replace(" maximize", "");
}

function el_PageLoadWithIframeCheck()
{
	return window.self !== window.top;
}