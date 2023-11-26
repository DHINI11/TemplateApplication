var BaseURL;

$(document).ready(function () {

    BaseURL = $("#APIBaseURL").val();

});

$(document).on('click', '.EditRow', function () {
    let RowID = $(this).attr('data-itemid');
    OpenEditOption(RowID);
});

$(document).on('click', '.DeleteRow', function () {
    debugger;
    let RowID = $(this).attr('data-itemid');
    DeleteRow(RowID);
});

$(document).on('click', '.SaveRow', function () {
    let RowID = $(this).attr('data-itemid');
    SaveChanges(RowID)
});


function OpenEditOption(Id) {
    $(".MainSpan_" + Id).hide();
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


    if (UserName != "" && Email != "" && Phone != "")
    {
        var postData = {
            ID: Id,
            UserName: UserName,
            Email: Email,
            Phone: Phone
        };

        let ActionCall = "Product/UpdateTableUser";
        DoAjax(ActionCall, 'GET', postData, 'html', SuccessCallBack.Update, ErrorCallBack.Default)

    } else {
        console.log("Invalid Input");
    }
}


function DeleteRow(Id) {


    if (Id !="" ) {
        var postData = {
            ID: Id,
            IsDeleted: true
        };

        let ActionCall = "Product/UpdateTableUser";
        DoAjax(ActionCall, 'GET', postData, 'html', SuccessCallBack.Update, ErrorCallBack.Default)

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

        DoAjax(CallURL, 'POST', JSON.stringify(postData),'json', SuccessCallBack.AddNew, ErrorCallBack.Default);

    } else {
        console.log("Invalid Input");
    }
}



var SuccessCallBack = {
    Default: function (response) {
        ////Common Success
        console.log('Function 1');
    },
    Delete: function (response) {
        console.log('Function 2');
    },
    Update: function (response) {
        debugger;
        $("#MainTable").html(response);
    },
    AddNew: function (response) {
        console.log('Function 2');
    }

};

var ErrorCallBack = {
    Default: function (jqXHR, textStatus, errorThrown) {
        debugger;
        console.log('Function 1');
    },
    func2: function (jqXHR, textStatus, errorThrown) {
        console.log('Function 2');
    }
  
};



function DoAjax(url, method, data, dataType = 'json', successCallback, errorCallback) {
    $.ajax({
        url: url,
        method: method,
        contentType: 'application/json',
        data: data,
        dataType: dataType,// 'json' or html
        success: function (response) {
            if (successCallback && typeof successCallback === 'function') {
                successCallback(response);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (errorCallback && typeof errorCallback === 'function') {
                errorCallback(jqXHR, textStatus, errorThrown);
            }
        }
    });
}