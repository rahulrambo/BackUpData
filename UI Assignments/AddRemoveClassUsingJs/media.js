let addClass = document.getElementById("mycontent");
let inputvalue = document.getElementById("inputfield");
let hoverbtns1 = document.getElementById("hoverbtn1");
let hoverbtns2 = document.getElementById("hoverbtn2");
function hoverfunction(){
    if (inputvalue.value == "") {
        addClass.style.fontSize = "1em";
    }
    else {
        addClass.addEventListener("mouseover",increasefont);
        addClass.addEventListener("mouseout",decreasefont);
    }
}
function increasefont(){
    addClass.style.fontSize = "2em";
}
function decreasefont(){
    addClass.style.fontSize="1em";
}
function stophoverfun(){
    addClass.removeEventListener("mouseover",increasefont);
    addClass.removeEventListener("mouseout",decreasefont);
}
function addfun() {
    addClass.classList.add(inputvalue.value);
    hoverbtns1.addEventListener("click", hoverfunction);
    hoverbtns2.addEventListener("click",stophoverfun);
}
function removefun() {
    addClass.classList.remove(inputvalue.value);
}
$(function () {
    $("h1").attr("style", "color:red");
});
$(document).ready(function () {
    $("#btn1").click(function () {
        $("#mycontents").addClass($("#inputfields").val());
    })
    $("#btn2").click(function () {
        $("#mycontents").removeClass($("#inputfields").val());
    })
})