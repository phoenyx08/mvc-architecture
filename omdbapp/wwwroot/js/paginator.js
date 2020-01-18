console.log("paginator attached");
$(document).ready(function(){
    console.log("Inside document.ready");
    var pagesCount = Math.floor(state.totalFound/10);
    var ajaxSender = () => {
        $.ajax({
            type: "POST",
            url: "/Movie/Ajax/Search",
            data: {page: state.currentPage.toString(), searchQuery: state.searchString},
            success: (result) => {
                //console.log(result);
                var htmlString = "";
                result.result.search.map(entry => {
                    console.log(entry);
                    if (entry.poster == "N/A") {
                        entry.poster = "/img/not-available.png"; 
                    }
                    htmlString += "<tr><td><img class=\"poster-preview\" src=\"" + entry.poster + "\"></td><td><a href=\"/Movie/Details/" 
                    + entry.imdbID + "\">"
                     + entry.title + 
                        "</a></td><td>" + entry.year +
                        "</td><td>" + entry.imdbID + 
                        "</td><td>" + entry.type
                        "</td></tr>";
                });
                $(".search-result-table-body").html(htmlString);
            }
        })
    }
    console.log(state);
    console.log(pagesCount);

    $("#pager-previous").click(function(){
        console.log("Pager previous clicked state.currentPage was " + state.currentPage);

        if (state.currentPage == 2) {
            state.currentPage = 1;
            $(".pagination").children().removeClass("active");
            $("#pager-one").parent().addClass("active");
            $("#pager-previous").parent().addClass("disabled");
            $("#pager-one").text(state.currentPage);
            $("#pager-two").text(state.currentPage + 1);
            $("#pager-three").text(state.currentPage + 2);
        } else if (state.currentPage == pagesCount) {
            state.currentPage = pagesCount - 1;
            $(".pagination").children().removeClass("active");
            $("#pager-two").parent().addClass("active");
            $("#pager-one").text(state.currentPage - 1);
            $("#pager-two").text(state.currentPage);
            $("#pager-three").text(state.currentPage + 1);
        } else if (state.currentPage != 1) {
            state.currentPage--;
            $("#pager-one").text(state.currentPage - 1);
            $("#pager-two").text(state.currentPage);
            $("#pager-three").text(state.currentPage + 1);        
        }

        if (state.currentPage < pagesCount){
            $("#pager-next").parent().removeClass("disabled");
        }

        console.log("Pager one clicked. state.currentPage became " + state.currentPage);  
        console.log(state.searchString + " - state.searchQuery");

        ajaxSender();
    });

    $("#pager-one").click(function() {
        console.log("Pager one clicked. state.currentPage was " + state.currentPage);

        if (state.currentPage == 2) {
            state.currentPage = 1;
            $(".pagination").children().removeClass("active");
            $("#pager-one").parent().addClass("active");
            $("#pager-previous").parent().addClass("disabled");
            $("#pager-one").text(state.currentPage);
            $("#pager-two").text(state.currentPage + 1);
            $("#pager-three").text(state.currentPage + 2);
        } else if (state.currentPage == pagesCount) {
            state.currentPage = pagesCount - 2;
            $(".pagination").children().removeClass("active");
            $("#pager-two").parent().addClass("active");
            $("#pager-one").text(state.currentPage - 1);
            $("#pager-two").text(state.currentPage);
            $("#pager-three").text(state.currentPage + 1);
        } else if (state.currentPage != 1) {
            state.currentPage--;
            $("#pager-one").text(state.currentPage - 1);
            $("#pager-two").text(state.currentPage);
            $("#pager-three").text(state.currentPage + 1);        
        }

        if (state.currentPage < 99){
            $("#pager-next").parent().removeClass("disabled");
        }

        console.log("Pager one clicked. state.currentPage became " + state.currentPage);

        ajaxSender();
    });

    $("#pager-two").click(function(){
        console.log("Pager two clicked state.currentPage was " + state.currentPage);

        if (state.currentPage == 1) {
            $(".pagination").children().removeClass("active");
            $("#pager-two").parent().addClass("active");
            state.currentPage = 2;
            
        } else if (state.currentPage == pagesCount) {
            $(".pagination").children().removeClass("active");
            $("#pager-two").parent().addClass("active");
            state.currentPage = pagesCount - 1;
        }
        
        $("#pager-next").parent().removeClass("disabled");
        $("#pager-previous").parent().removeClass("disabled");
        $("#pager-one").text(state.currentPage - 1);
        $("#pager-two").text(state.currentPage);
        $("#pager-three").text(state.currentPage + 1);
        
        console.log("Pager two clicked state.currentPage became " + state.currentPage);

        ajaxSender();
    });

    $("#pager-three").click(function(){
        console.log("Pager three clicked. state.currentPage was " + state.currentPage);
        console.log("Pager tree clicked");
        
        if (state.currentPage == pagesCount - 1) {
            state.currentPage = pagesCount;
            $(".pagination").children().removeClass("active");
            $("#pager-three").parent().addClass("active");
            $("#pager-next").parent().addClass("disabled");
            $("#pager-one").text(state.currentPage - 2);
            $("#pager-two").text(state.currentPage - 1);
            $("#pager-three").text(state.currentPage);
        } else if (state.currentPage == 1) {
            state.currentPage = 3;
            $(".pagination").children().removeClass("active");
            $("#pager-two").parent().addClass("active");
            $("#pager-one").text(state.currentPage - 1);
            $("#pager-two").text(state.currentPage);
            $("#pager-three").text(state.currentPage + 1);
        } else if (state.currentPage != pagesCount) {
            state.currentPage++;
            $("#pager-one").text(state.currentPage - 1);
            $("#pager-two").text(state.currentPage);
            $("#pager-three").text(state.currentPage + 1);
        }
        
        if (state.currentPage > 1){
            $("#pager-previous").parent().removeClass("disabled");
        }
        
        console.log("Pager three clicked. state.currentPage became " + state.currentPage);

        ajaxSender();
    });

    $("#pager-next").click(function(){
        console.log("Pager next clicked state.currentState = " + state.currentPage);
        if (state.currentPage == pagesCount - 1) {
            state.currentPage = pagesCount;
            $(".pagination").children().removeClass("active");
            $("#pager-three").parent().addClass("active");
            $("#pager-next").parent().addClass("disabled");
            $("#pager-one").text(state.currentPage - 2);
            $("#pager-two").text(state.currentPage - 1);
            $("#pager-three").text(state.currentPage);
        } else if (state.currentPage == 1) {
            state.currentPage = 2;
            $(".pagination").children().removeClass("active");
            $("#pager-two").parent().addClass("active");
            $("#pager-one").text(state.currentPage - 1);
            $("#pager-two").text(state.currentPage);
            $("#pager-three").text(state.currentPage + 1);
        } else if (state.currentPage != pagesCount) {
            state.currentPage++;
            $("#pager-one").text(state.currentPage - 1);
            $("#pager-two").text(state.currentPage);
            $("#pager-three").text(state.currentPage + 1);
        }
        
        if (state.currentPage > 1){
            $("#pager-previous").parent().removeClass("disabled");
        }
        
        console.log("Pager next clicked. state.currentPage became " + state.currentPage);

        ajaxSender();
    });
});