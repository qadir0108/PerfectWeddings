﻿// Security Module

var pw = pw || {};

pw.security.register = function (form, name, email, weddingDate) {
    debugger;

    form.validator('validate').on('submit', function (e) {
        debugger;

        if (e.isDefaultPrevented()) {
            // handle the invalid form...
        } else {
            // everything looks good!
        
            e.preventDefault();
            
            pw.blockUI({
                target: form,
                boxed: true,
                message: 'Processing...'
            });

            $.ajax({
                type: "POST",
                url: '/Account/Register',
                data: "{Name : '" + name + "', Email: '" + email + "', WeddingDate: '" + weddingDate + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    debugger;
                    if (response.IsSucess) {
                        pw.showSuccess('Couple has been registered successfully.');
                        setTimeout(
                            function () {
                                location.href = "http://localhost:50000/Account/Login";
                            }, 3000);
                    } else {
                        pw.showError(response.ErrorMessage);
                    }
                },
                failure: function (response) {
                    pw.showError('There is erorr');
                },
                complete: function () {
                    pw.unblockUI(form)
                }
            });
        }
    }) //end validator

    //setTimeout(
    //    function () {
    //        pw.unblockUI('#frmRegister')
    //    }, 3000);
}

pw.security.registerSupplier = function (frmRegSupplier, txtfirstName, txtlastName, txtEmail, txtPhone, category, txtmessage) {
    debugger;

    frmRegSupplier.validator('validate').on('submit', function (e) {
        debugger;

        if (e.isDefaultPrevented()) {
            // handle the invalid form...
        } else {
            // everything looks good!

            e.preventDefault();

            pw.blockUI({
                target: frmRegSupplier,
                boxed: true,
                message: 'Processing...'
            });

            $.ajax({
                type: "POST",
                url: '/Account/RegisterSupplier',
                data: "{firstName : '" + txtfirstName + "', lastName: '" + txtlastName + "', phoneNo: '" + txtPhone + "', message: '" + txtmessage + "', category: '" + category + "', email: '" + txtEmail + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    debugger;
                    if (response.IsSucess) {
                        pw.showSuccess('Registered successfully.');
                        setTimeout(
                            function () {
                                location.href = "http://localhost:50000/Account/RegisterSupplier";
                            }, 3000);
                    } else {
                        pw.showError(response.ErrorMessage);
                    }
                },
                failure: function (response) {
                    pw.showError('There is erorr');
                },
                complete: function () {
                    pw.unblockUI(frmRegSupplier)
                }
            });
        }
    }) //end validator

    //setTimeout(
    //    function () {
    //        pw.unblockUI('#frmRegister')
    //    }, 3000);
}

pw.security.supplierLogin = function (frmSupplierLogin, txtSupplierName, passwordSupplier) {
    debugger;
    frmSupplierLogin.validator('validate').on('submit', function (e) {
        debugger;
       
        if (e.isDefaultPrevented()) {
        
        } else {
            // everything looks good!

            e.preventDefault();

            pw.blockUI({
                target: frmSupplierLogin,
                boxed: true,
                message: 'Processing...'
            });

            $.ajax({
                type: "POST",
                url: '/Account/LoginSupplier',
                data: "{UserName : '" + txtSupplierName + "', Password: '" + passwordSupplier + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    debugger;
                    if (response.IsSucess) {
                        pw.showSuccess('Supplier has been login Successfully.');
                        setTimeout(
                            function () {
                                location.href = "http://localhost:50000/Account/Login";
                            }, 3000);
                    } else {
                        pw.showError(response.ErrorMessage);
                    }
                },
                failure: function (response) {
                    pw.showError('There is erorr');
                },
                complete: function () {
                    pw.unblockUI(frmSupplierLogin)
                }
            });
        }
    }) //end validator

    //setTimeout(
    //    function () {
    //        pw.unblockUI('#frmRegister')
    //    }, 3000);
}

pw.security.coupleLogin = function (frmCoupleLogin, txtCoupleName, passwordCouple) {
    debugger;

    frmCoupleLogin.validator('validate').on('submit', function (e) {
        debugger;

        if (e.isDefaultPrevented()) {
            // handle the invalid form...
        } else {
            // everything looks good!

            e.preventDefault();

            pw.blockUI({
                target: frmCoupleLogin,
                boxed: true,
                message: 'Processing...'
            });

            $.ajax({
                type: "POST",
                url: '/Account/LoginCouple',
                data: "{UserName : '" + txtCoupleName + "', Password: '" + passwordCouple + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    debugger;
                    if (response.IsSucess) {
                        pw.showSuccess('Couple has been login Successfully.');
                        
                        setTimeout(
                            function () {
                                location.href = "http://localhost:50000/Account/Login";
                              
                            }, 1000);
                    } else {
                        pw.showError(response.ErrorMessage);
                       
                        setTimeout(
                         function () {
                      
                             location.href = "http://localhost:50000/Account/Login";
                         }, 1000);
                    }
                },
                failure: function (response) {
                    pw.showError('There is erorr');

                },
                complete: function () {
                    pw.unblockUI(frmCoupleLogin)
                   
                }
            });
        }
    }) //end validator

    //setTimeout(
    //    function () {
    //        pw.unblockUI('#frmRegister')
    //    }, 3000);
}


pw.security.login = function (userName, passWord) {
    debugger;

    pw.blockUI({
        target: '#frmRegister',
        boxed: true,
        message: 'Processing...'
    });

    $.ajax({
        type: "POST",
        url: '/Account/Register',
        data: "{Name : '" + + "', Email: '" + + "', WeddingDate: '" + + "'}",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            debugger;
            if (response.IsSucess) {
                pw.showSuccess('Couple has been registered successfully.');
            } else {
                pw.showError(response.ErrorMessage);
            }

            //var message = response;
            //if (message == "1") {
            //    lblLoginMessage.innerHTML = "User Name or Password is not Valid";
            //    $("#Message").removeClass("hide");
            //    window.setTimeout(function () {
            //        App.unblockUI('.content');
            //    });
            //    return false;
            //}
            //else if (message == "3") {
            //    lblLoginMessage.innerHTML = "User is not Acive,Contact to Administrator";
            //    $("#Message").removeClass("hide");
            //    window.setTimeout(function () {
            //        App.unblockUI('.content');
            //    });
            //    return false;
            //}
            //else if (message == "2") {
            //    location.href = " http://localhost:28862/Home/Index";
            //}
        },

        failure: function (response) {
            pw.showError('There is erorr');
        }
           ,
        complete: function () {
            //$('#Loader_Login').hide();
        }
    });

    setTimeout(
        function () {
            pw.unblockUI('#frmRegister')
        }, 3000);
}

pw.validateEmail = function (email) {
    var re = /\S+@@\S+\.\S+/;
    return re.test(email);
}

pw.validatePassword = function (password) {
    var pa = /(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,20})$/;
    return pa.test(password);
}

pw.security.Listing = function () {
    alert("In");
    $.ajax({
        url: '/Supplier/AddListing',
        type: "GET",
        data: {},
        success: function (response) {

            $('#partialLoadingDiv').html(response);
            alert("working");

        },
        error: function (xhr, desc, err) {
            console.log(xhr);
            alert(err + "1");

        }
    });
}
