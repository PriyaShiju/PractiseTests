// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*
document.getElementById("divForm").hidden = true;


btnbuy = document.getElementById("btnbuy");
btnbuy.addEventListener("click", function () {
    alert("buy clicked");
});
divprod = document.getElementByClassName("product-info");
listitems = divprod.item[0].children[0].innerText; //this.innerText;
*/

$(document).ready(function () {

    //$("div").live("rightclick", function () {
    //    return false;
    //});
    //$("div").live("keydown", function () {
    //    return false;
    //});
    $("#btnSaveMarks").click( function () {
            //$("#btnSubmit").text = "Close";

        //$("a").live("click", function () {
        //    return false;
        //});
        var marks = 0;
        var noofquestions = parseInt($("#hiddenrowNo").val());
        for (var i = 1; i < noofquestions; i++)
        {
                var radiobtn = 'Answer' + i.toString();
                Checked = $("input[name='" + radiobtn + "']:checked").val();
                CorrectAnswer = $("#CorrectAnswer" + i.toString()).val();
                //checked = $("input[name='Answer'+rowNo]:checked");
                //if (checked)
                if (Checked == CorrectAnswer)
                {
                    //alert("Answer ");
                    $("#DisplayAnswer" + i).prop("value" , "Correct Answer is " + CorrectAnswer + ". "); 
                    $("#DisplayAnswer" + i).prop("class", "btn btn-success");
                    marks += 1;
                }
                else {
                    //alert(" submitted");
                    $("#DisplayAnswer" + i).prop("value" , "InCorrect Answer. Correct Answer is " + CorrectAnswer + ". ");
                    $("#DisplayAnswer" + i).prop("class", "btn btn-danger");
                }
                
                $("#Question" + i).prop("disabled", "disabled");
                //$("div").live("rightclick", function () {
                //    return false;
                //});
                //$("#DisplayAnswer" + i).show();


        }
        //$("#TestPaper").prop('disabled', true);
        $("#displayMarks").html("You have scored " + marks + " marks out of " + noofquestions + " questions.");
        $("#displayMarks").prop("class", "btn btn-outline-success");
        $("#btnSaveMarks").hide(); // prop('disabled', true);
     });

});
    


    /////old index.html
    /*$("#divForm").hide(); // jquery
    //$("#frmLogin").hide();
    $("#frmSignUp").hide();
    //alert("inside");


    $("#signupToggle").on("click", function () { $("#frmLogin").hide(); $("#frmSignUp").toggle(1000); });
    //$("#loginToggle").on("click", function () { $("#frmSignUp").hide(); $("#frmLogin").toggle(1000); });


    btnbuy = $("#btnbuy");
    btnbuy.on("click", function () {
        alert("buy clicked");
    });
    divprod = $(".productprops li");
    divprod.on("click", function () {
        console.log("clicked on" + $(this).text()); // this.innerText;
    });*/
