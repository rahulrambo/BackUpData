let emptyValueMessage="It can't be empty Please enter some value!";
let minFiveCharacters="Please enter atleast 5 characters!";
let alphaFiveToFiftyCharacters="It can take only alphabet of length between 5 and 50 and special character is not accepted!";
let invalidValue="Invalid";
let sixDigitNumber="It can take only 6 digit number";
let startsWithMessage="It should starts with 'http'";
let matchCondition="Please match the condition";
let pastDateMessage="Past dates are not allowed";
function showMessage(element, inputElement) {
    element.innerHTML = "Valid data";
    inputElement.style.border = "1px solid green";
    element.style.color = "green";
    setTimeout(() => {
        element.innerHTML = "";
        inputElement.style.border = "1px solid";
    }, 1000)
}
function showError(element, inputElement,message) {
    element.innerHTML = message;
    inputElement.style.border = "1px solid red";
    element.style.color = "red";
}
function errorMessage(element,message){
    element.innerHTML=message;
    element.style.color="red";
}
let clientname = document.getElementById("client_name");
clientname.addEventListener("focusout", clientFunction);
let clientpara = document.getElementById("client-name");
function clientFunction() {
    document.getElementById("client-name").style.display = "block";
    var clientdata = /^[A-Za-z]{5,50}$/;
    if (clientdata.test(client_name.value)) {
        showMessage(clientpara, clientname);
    }
    else {
        if (client_name.value == "") {
            showError(clientpara, clientname,emptyValueMessage);
        }
        else if (client_name.value.length < 5 || client_name.value.length > 50) {
            showError(clientpara, clientname,minFiveCharacters);
        }
        else {
            showError(clientpara, clientname,alphaFiveToFiftyCharacters);
        }
    }
}
let companyname = document.getElementById("company_name");
companyname.addEventListener("focusout", companyfun);
let companypara = document.getElementById("company-name");
function companyfun() {
    document.getElementById("company-name").style.display = "block";
    var companydata = /^[A-Za-z]{5,50}$/;
    if (companydata.test(company_name.value)) {
        showMessage(companypara, companyname);
    }
    else {
        if (company_name.value == "") {
            showError(companypara, companyname,emptyValueMessage)
        }
        else if (company_name.value.length < 5 || company_name.value.length > 50) {
            showError(companypara, companyname,minFiveCharacters);
        }
        else {
            showError(companypara, companyname,alphaFiveToFiftyCharacters);
        }
    }
}
let departmentName = document.getElementById("dept");
departmentName.addEventListener("focusout", deptfun);
let deptpara = document.getElementById("dept-section");
function deptfun() {
    document.getElementById("dept-section").style.display = "block";
    if (dept.value == "") {
        showError(deptpara, departmentName,emptyValueMessage);
    }
    else {
        showMessage(deptpara, departmentName)
    }
}
let radiovalue = "email";
let allRadio = document.querySelectorAll('input[type="radio"]');
let mailPhoneLable = document.getElementById("mail-section");
let emailPhoneInput = document.getElementById("emailPhoneInput");
let maildata = document.getElementById("mailphonedata");
allRadio.forEach(element => {
    element.addEventListener("change", () => {
        radiovalue = element.value;
        mailPhoneLable.innerHTML = element.value;
    })
});
let validEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
let validPhone = /^[9]\d{9}$/;
emailPhoneInput.addEventListener("focusout", () => {
    if (radiovalue == "email") {
        if (validEmail.test(emailPhoneInput.value)) {
            showMessage(maildata, emailPhoneInput);
        }
        else if (emailPhoneInput.value == "") {
            showError(maildata, emailPhoneInput,emptyValueMessage);
        }
        else {
            showError(maildata, emailPhoneInput,invalidValue);
        }
    }
    else {
        if (validPhone.test(emailPhoneInput.value)) {
            showMessage(maildata, emailPhoneInput);
        }
        else if (emailPhoneInput.value == "") {
            showError(maildata, emailPhoneInput,emptyValueMessage);
        }
        else {
            showError(maildata, emailPhoneInput,invalidValue);
        }
    }
})
let streetAdd = document.getElementById("street_add");
streetAdd.addEventListener("focusout", streetfun);
let streetpara = document.getElementById("street-add");
function streetfun() {
    document.getElementById("street-add").style.display = "block";
    if (street_add.value == "") {
        showError(streetpara, streetAdd,emptyValueMessage);
    }
    else {
        showMessage(streetpara, streetAdd);
    }
}
let lineAdd = document.getElementById("line_add");
lineAdd.addEventListener("focusout", lineAddfun);
let linepara = document.getElementById("line-add");
function lineAddfun() {
    document.getElementById("line-add").style.display = "block";
    if (line_add.value == "") {
        showError(linepara, lineAdd,emptyValueMessage);
    }
    else {
        showMessage(linepara, lineAdd);
    }
}
let cityAdd = document.getElementById("city_add");
cityAdd.addEventListener("focusout", cityAddfun);
let citypara = document.getElementById("city-add");
function cityAddfun() {
    document.getElementById("city-add").style.display = "block";
    if (city_add.value == "") {
        showError(citypara, cityAdd,emptyValueMessage);
    }
    else {
        showMessage(citypara, cityAdd);
    }
}
let stateAdd = document.getElementById("state_add");
stateAdd.addEventListener("focusout", statefun);
let statepara = document.getElementById("state-add");
function statefun() {
    document.getElementById("state-add").style.display = "block";
    if (state_add.value == "") {
        showError(statepara, stateAdd,emptyValueMessage);
    }
    else {
        showMessage(statepara, stateAdd);
    }
}
let zipAdd = document.getElementById("zip_code");
zipAdd.addEventListener("focusout", zipfun);
let zippara = document.getElementById("zip-code");
function zipfun() {
    document.getElementById("zip-code").style.display = "block";
    var zipdata = /^[0-9]{6}$/;
    if (zipdata.test(zip_code.value)) {
        showMessage(zippara, zipAdd);
    }
    else {
        if (zip_code.value == "") {
            showError(zippara, zipAdd,emptyValueMessage);
        }
        else {
            showError(zippara, zipAdd,sixDigitNumber);
        }
    }
}
let countries = document.getElementById("country");
countries.addEventListener("focusout", countryfun);
let countrypara = document.getElementById("country-add");
function countryfun() {
    document.getElementById("country-add").style.display = "block";
    if (country.value == "") {
        showError(countrypara, countries,emptyValueMessage);
    }
    else {
        showMessage(countrypara, countries);
    }
}
let companyWeb = document.getElementById("company_web");
companyWeb.addEventListener("focusout", companyWebfun);
let webpara = document.getElementById("company-web");
function companyWebfun() {
    document.getElementById("company-web").style.display = "block";
    if (company_web.value.startsWith("http")) {
        showMessage(webpara, companyWeb);
    }
    else {
        if (company_web.value == "") {
            showError(webpara, companyWeb,emptyValueMessage);
        }
        else {
            showError(webpara, companyWeb,startsWithMessage);
        }
    }
}
let billingDates = document.getElementById("dates");
billingDates.addEventListener("focusout", billingfun);
let billingpara = document.getElementById("billing-cycle");
function billingfun() {
    let months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"];
    document.getElementById("billing-cycle").style.display = "block";
    let presentDate = new Date();
    let dd = presentDate.getDate();
    let mm = presentDate.getMonth() + 1;
    let yy = presentDate.getFullYear();
    let datevalue = billingDates.value;
    // console.log(datevalue);
    let datearr = datevalue.split("-");
    // console.log(datearr[0]);
    if (datearr[0] >= yy && datearr[1] >= mm && datearr[2] >= dd) {
        var datas = document.getElementById("billing_cycle");
        // datas.value = datevalue;
        datas.value = datearr[2] + "th" + " " + months[datearr[1] - 1] + " " + datearr[0] + "";
        billingpara.innerHTML = "Selected";
        billingpara.style.color = "green";
    }
    else if (datevalue == "") {
        errorMessage(billingpara,emptyValueMessage);
    }
    else {
        errorMessage(billingpara,pastDateMessage);
    }
}
let textArea = document.getElementById("t_area");
textArea.addEventListener("focusout", textAreafun);
let textpara = document.getElementById("t-area");
function textAreafun() {
    document.getElementById("t-area").style.display = "block";
    if (t_area.value.length > 0 && t_area.value.length <= 200) {
        showMessage(textpara, textArea);
    }
    else {
        if (t_area.value == "") {
            showError(textpara, textArea,emptyValueMessage);
        }
        else {
            showError(textpara, textArea,matchCondition);
        }
    }
}
var allclients = [];
let subbtn = document.getElementById("submitbtn");
subbtn.addEventListener("click", () => {
    allclients = [];
    let previousData = JSON.parse(localStorage.getItem("testJSON"));
    console.log(previousData);
    if (previousData != []) {
        allclients = allclients.concat(previousData);
        getData();
    }
    let clientobj = {
        clinetName: client_name.value,
        companyName: company_name.value,
        department: dept.value,
        contact_method: emailPhoneInput.value,
        company_Address: addressfun(),
        billingDate: billingDates.value,
    }
    function addressfun() {
        return (street_add.value + " " + line_add.value + " " + city_add.value + " " + state_add.value + " " + zip_code.value + " " + country.value);
    }
    if (client_name.value != "" && company_name.value != "" && dept.value != "" && emailPhoneInput.value != "" && billingDates.value != "" && street_add.value != "" && line_add.value != "" && city_add.value != "" && state_add.value != "" && zip_code.value != "" && country.value != "") {
        allclients.push(clientobj);
        let myjson = JSON.stringify(allclients);
        localStorage.setItem("testJSON", myjson);
        let text = localStorage.getItem("testJSON");
        let obj = JSON.parse(text);
        getData();
        console.log(document.getElementsByClassName("deleteBtn"));
    }
    else {
        alert("Please enter the empty section");
        
    }
    deleteFunctionality();
    document.clientForm.reset();
})
function getData() {
    let text = localStorage.getItem("testJSON");
    let obj = JSON.parse(text);
    console.log(obj);
    tbody = document.querySelector("tbody");
    tbody.innerHTML = "";
    obj.forEach(element => {
        let element2 = element;
        tbody.innerHTML +=
            `<tr>
        <td>${element.clinetName}</td><td>${element.companyName}</td><td>${element.department}</td><td>${element.contact_method}</td><td>${element.company_Address}</td><td>${element.billingDate}</td><td><button class="editBtn">Edit</button> <button class="deleteBtn">Delete</button></td>
    </tr>
    `
    })
}
window.addEventListener("load",()=>{
    let previousData = JSON.parse(localStorage.getItem("testJSON"));
    console.log(previousData);
    if (previousData != []) {
        allclients = allclients.concat(previousData);
        myjson = JSON.stringify(allclients);
        localStorage.setItem("testJSON", myjson);
        getData();
    }
    deleteFunctionality();
})
function deleteFunctionality(){
    console.log(document.getElementsByClassName("deleteBtn"));
    let all_deleteButns = document.getElementsByClassName("deleteBtn");
    for (let k = 0; k < all_deleteButns.length; k++) {
        all_deleteButns[k].addEventListener("click", (event) => {
            console.log(event);
            
            console.log(allclients);
            allclients.splice(allclients.indexOf(allclients[k]), 1);
            console.log(allclients);
            myjson = JSON.stringify(allclients);
            localStorage.setItem("testJSON", myjson);
            getData();
            deleteFunctionality();
        })
    }
}