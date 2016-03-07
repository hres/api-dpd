$(document).ready(function(){
    $.ajax({
        type: "GET",
        url: "/dataextract/drugnames.xml",
        dataType: "xml",
        success: function(xml){
            var output = 
            $(xml).find("drugname").each(function(){
                var name = $(this).find('name').text();
                out
            });
        }
    })
}