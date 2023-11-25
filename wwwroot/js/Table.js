var BaseURL = $("#APIBaseURL").val();

$(document).ready(function () {

    $(".EditRow").click(function ( ) {
        debugger;
        let RowID = $(this).attr('data-itemid');
        OpenEditOption(RowID);
    });


    $(".DeleteRow").click(function () {
        debugger;
        alert("The paragraph was clicked.");

    });

    $(".SaveRow").click(function () {
        debugger;
        let RowID = $(this).attr('data-itemid');
        SaveChanges(RowID)
    });

});

function OpenEditOption(Id) {
    $(".MainSpanEmail_" + Id).hide();
    $(".MainSpanName_" + Id).hide();
    $(".MainSpanPhone_" + Id).hide();
    $("#Edit_" + Id).hide(); 
    $("#Delete_" + Id).hide(); 
    $(".InputUpdateEmail_" + Id).removeAttr("hidden");
    $(".InputUpdateName_" + Id).removeAttr("hidden");
    $(".InputUpdatePhone_" + Id).removeAttr("hidden");
    $("#Save_" + Id).removeAttr("hidden");

}


function SaveChanges (Id) {

    let UserName = $(".InputUpdateName_" + Id).val().trim();
    let Email = $(".InputUpdateEmail_" + Id).val().trim();
    let Phone = $(".InputUpdatePhone_" + Id).val().trim();  
    let CallURL = BaseURL;

    if (UserName != "" && Email != "" && Phone != "")
    {
        var postData = {
            ID: Id,
            UserName: UserName,
            Email: Email,
            Phone: Phone
        };

        DoAjax(CallURL, 'POST', postData, SuccessCallBack.Update, ErrorCallBack.Default)

    } else {
        console.log("Invalid Input");
    }
}


function DeleteRow(Id) {


    var CallURL = BaseURL;

    if (Id !="" ) {
        var postData = {
            ID: Id,
        };

        DoAjax(CallURL, 'POST', postData, SuccessCallBack.Delete, ErrorCallBack.Default)

    } else {
        console.log("Invalid Input");
    }
}

function AddNewRow() {

    let UserName = $("#InputName").val().trim();
    let Email = $("#InputEmail").val().trim();
    let Phone = $("#InputPhone").val().trim();

    var CallURL = BaseURL;

    if (UserName != "" && Email != "" && Phone != "") {
        var postData = {
            UserName: UserName,
            Email: Email,
            Phone: Phone
        };

        DoAjax(CallURL, 'POST', postData, SuccessCallBack.AddNew, ErrorCallBack.Default)

    } else {
        console.log("Invalid Input");
    }
}



var SuccessCallBack = {
    Default: function () {
        ////Common Success
        console.log('Function 1');
    },
    Delete: function () {
        console.log('Function 2');
    },
    Update: function () {
        console.log('Function 2');
    },
    AddNew: function () {
        console.log('Function 2');
    }

};

var ErrorCallBack = {
    Default: function () {
        //Common Exception Log
        console.log('Function 1');
    },
    func2: function () {
        console.log('Function 2');
    }
  
};


function DoAjax (url, method, data, successCallback, errorCallback) {
    $.ajax({
        url: url,
        type: method,
        data: data,
        dataType: 'json',
        success: successCallback,
        error: errorCallback
    });
}