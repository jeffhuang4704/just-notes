## jQuery to add table rows, use mark.js to highlight keywords

- use jquery to add table rows
- use mark.js to hightlight keywords

```JavaScript

$(document).ready(function () {

});

//referenes
// 1. use jquery to add table rows
// 2. use mark.js to hightlight keywords

// <table id="id_result_table" class="table table-sm">
function populateResult2Table(records, terms) {
    // populate the result to table, #id_result_table
    // clear table (keep header)
    $("#id_result_table").find("tr:gt(0)").remove();

    records.forEach(function (record) {

        let c1 = $("<td></td>").text(record.IDSession);

        let c3btn = $('<a></a>').attr({
            id: "id_download_" + record.IDSession,
            //apiContentProviderEndpoint = '/ContentProvider';
            //href: "/test2/ContentProvider?idsession=" + record.IDSession,
            href: apiContentProviderEndpoint + '?idsession=' + record.IDSession,
            target: "_blank"
        }).text("Download").data("idsession", record.IDSession);

        let c3 = $("<td></td>").append(c3btn);

        //let c4 = $("<td></td>").text("Samsung S8");

        let list = $("<ol></ol>").attr({
            class: "smallfont-80"
        });
        record.snippets.forEach(function (s) {
            let oneMatch = $('<li></li>')
                .attr({
                    class: "matchsnippet"
                })
                .text(s);
            list.append(oneMatch);
        });
        let c5 = $("<td></td>").append(list);

        var row = $("<tr></tr>");
        row.append(c1);
        row.append(c3);
        //row.append(c4);
        row.append(c5);

        $('#id_result_table').append(row);
    });

    // highlight search terms
    if (terms) {
        var items = terms.split('AND');
        var highlights = [];
        items.forEach(function (item) {
            highlights.push(item.trim());
        });
        $('.matchsnippet').mark(highlights);
    }
}
```

## Another Reference

```JavaScript

function showWordBody(word, indexLabel) {

    //<li class="word_list">
    //    <div class="word_body_container">
    //        <div id="id_word_body" class="word_body">reunion</div>
    //    </div>
    //    <div class="action_container">
    //          <a class="action_item" href="#" data-action="prev_word"><i class="far fa-arrow-alt-circle-left"></i></a>
    //          <a class="action_item" href="#" data-action="next_word"><i class="far fa-arrow-alt-circle-right"></i></a>
    //          <a class="action_item" href="#" data-action="edit"><i class="fas fa-edit"></i></i></a >
    //          <a class="action_item" href="#" data-action="tagging"><i class="fas fa-tags"></i></a>
    //          <a class="action_item" href="#" data-action="thumb_up"><i class="far fa-thumbs-up"></i></a>
    //          <a class="action_item" href="#" data-action="thumb_down"><i class="far fa-thumbs-down"></i></a>
    //          <a class="action_item" href="#" data-action="add_word"><i class="far fa-plus-square"></i></a>
    //          <a class="action_item" href="#" data-action="search_it"><i class="fab fa-google"></i></a>
    //     </div>
    //</li >

    let bodyContainer = $('<div/>', { 'class': 'word_body_container' });
    let body = $('<div/>', { 'html': word.word, 'class': 'word_body' });

    let wordIndex = $('<span/>', { 'html': indexLabel, 'class': 'badge badge-secondary' });

    $(bodyContainer).append(body);
    $(bodyContainer).append(wordIndex);

    //let action_prev_word = $('<a/>', { 'class': 'action_item' }).attr('data-action', 'prev_word').attr('href', '#').append(
    //    $('<i/>', { 'class': 'far fa-arrow-alt-circle-left' }));

    //let action_next_word = $('<a/>', { 'class': 'action_item' }).attr('data-action', 'next_word').attr('href', '#').append(
    //    $('<i/>', { 'class': 'far fa-arrow-alt-circle-right' }));

    let action_edit = $('<a/>', { 'class': 'action_item' }).attr('data-action', 'edit').attr('href', '#').append(
        $('<i/>', { 'class': 'fas fa-edit' }));

    let action_tagging = $('<a/>', { 'class': 'action_item' }).attr('data-action', 'tagging').attr('href', '#').append(
        $('<i/>', { 'class': 'fas fa-tags' }));

    let action_thumb_up = $('<a/>', { 'class': 'action_item' }).attr('data-action', 'thumb_up').attr('href', '#').append(
        $('<i/>', { 'class': 'far fa-thumbs-up' }));

    let action_thumb_down = $('<a/>', { 'class': 'action_item' }).attr('data-action', 'thumb_down').attr('href', '#').append(
        $('<i/>', { 'class': 'far fa-thumbs-down' }));

    let action_add_word = $('<a/>', { 'class': 'action_item' }).attr('data-action', 'add_word').attr('href', '#').append(
        $('<i/>', { 'class': 'far fa-plus-square' }));

    let action_search_it = $('<a/>', { 'class': 'action_item' }).attr('data-action', 'search_it').attr('href', '#').append(
        $('<i/>', { 'class': 'fab fa-google' }));

    let action_container = $('<div/>', { 'class': 'action_container' });
    //$(action_container).append(action_prev_word);
    //$(action_container).append(action_next_word);
    $(action_container).append(action_edit);

    $(action_container).append(action_tagging);
    $(action_container).append(action_thumb_up);
    $(action_container).append(action_thumb_down);

    $(action_container).append(action_add_word);
    $(action_container).append(action_search_it);

    let listItemContainer = $('<li/>', { 'class': 'word_list' });
    $(listItemContainer).append(bodyContainer);
    $(listItemContainer).append(action_container);

    $('#main_container').append(listItemContainer);
}

```
