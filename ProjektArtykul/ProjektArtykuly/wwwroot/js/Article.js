
function getCommentLength() {
    var commentLen = 0;
    setInterval(function x() {
        var len = $(".userComent > textarea").val().length;
       
        if (commentLen != len) {
            $(".userComent > div > p").text(len + "/500");
            commentLen = len;
            console.log(len);
        } 
     
    }, 100);

}