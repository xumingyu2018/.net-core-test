
var frm = $('#loginform');
frm.submit(function (ev) {
    $.ajax({
        type: frm.attr('method'),
        url: frm.attr('action'),
        data: frm.serialize(),
        success: function (data) {
            console.log("URL"+frm.attr('action'));
            console.log(data.isLogin);
            console.log(data.isSuccess);
            if (data.isLogin) {
                //登录
                if (data.isSuccess) {
                    alert(data.msg);
                    window.location.href = "/Users/Index";
                } else {
                    $(".msg").html(data.msg);
                    $(".inputwords input").val("");
                    $(" input[ name='Account' ] ").focus();
                }
            } else {
                //注册
                if (data.isSuccess) {
                    alert(data.msg);
                    window.location.href = "/Auth/Index";
                } else {
                    $(".msg").html(data.msg);
                    $(".inputwords input").val("");
                    $(" input[ name='Account' ] ").focus();
                }
            }
        }
    });
    ev.preventDefault();
});


$(".quitbtn2").click(function () {
    window.location.href = "http://localhost:5000/Auth/Logout";
 })

