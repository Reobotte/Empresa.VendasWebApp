/*
 * Natael Corrêa - 24/03/2020
 */

function MsgAguarde()
{
    if(document.getElementById('divProcessando'))
    {
        document.getElementById('divProcessando').style.display='';
        return;
    }
    oDiv = document.createElement("div");
    with (oDiv)
    {
	    id = "divProcessando";
	}
	document.body.appendChild(oDiv);
}

function WebForm_OnSubmit() {
    alert("WebForm_OnSubmit");
    if (document.getElementById('divProcessando') && document.getElementById('divProcessando').style.display != 'none')
        return false;
    if (typeof (ValidatorOnSubmit) == 'function' && ValidatorOnSubmit() == false)
        return false;
    MsgAguarde();
    return true;
}