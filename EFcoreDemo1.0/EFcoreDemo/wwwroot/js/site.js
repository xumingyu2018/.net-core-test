$(".edit").click(function(){
    $(this).parents("tr").find(".hide_input").show();
    $(this).parents("tr").find(".hide_text").hide();
    $(this).next().show();
    $(".edit").remove();
})

$(".save").click(function(){
    $(".hide_input").hide()
    
    var inputs = $(this).parents("tr").find("input");
    $.post("Save",{
        "UserID":$(inputs).eq(0).val(), 
        "UserName":$(inputs).eq(1).val(),
        "Password":$(inputs).eq(2).val(),
        "Sex": $(inputs).eq(3).val(),
        "Age":$(inputs).eq(4).val(),
        "Graduated":$(inputs).eq(5).val(),
        "Address":$(inputs).eq(6).val(),
        "Phone":$(inputs).eq(7).val(),  
    },function(){
        window.location.reload();
    })

})
  
   

  

    
  
    
   
