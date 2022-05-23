

// Write your JavaScript code.

function getPeople() {
    $.get("GetPeople", function (response) {

        document.getElementById("PeopleList").innerHTML = response;
    })

}

//get person detials


function getPerson(url, inputId) {
    let inputElement = $("#" + inputId);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    $.post(url, data, function (response) {
        document.getElementById("PeopleList").innerHTML = response;
        //document.getElementById("PeopleList2").innerHTML ="I am in get person";
    })

};


function deletetPerson(url, input) {
    let inputElement = $("#" + input);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    // document.getElementById("PeopleList").innerHTML = "I am in get delete person";

    $.post(url, data, function (response) {//DeletePerson does not return any thing to view
        document.getElementById("PeopleList").innerHTML = response;
        //document.getElementById("PeopleList2").innerHTML = "I am in get delete person";
        // alert("Data: " + data + "\nStatus: " + status);
    })

};
