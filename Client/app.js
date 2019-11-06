// $.ajax({
//             url: 'https://localhost:44352/api/movie',
//             dataType: 'json',
//             type: 'get',
//             contentType: 'application/json',
//             data: JSON.stringify(dict),
//             success: function(data, textStatus, jQxhr){
//                 $('#response pre').html(data);
//             },
//             error: function(jqXhr,textStatus, errorThrown){
//                 console.log(errorThrown);
//             }
//         });
// $.getmovies;

(function($){
    function processForm( e ){
        var dict = {
        	Title : this["title"].value,
            Genre: this["genre"].value,
        	Director: this["director"].value
        };

        $.ajax({
            url: 'https://localhost:44352/api/movie',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });

        e.preventDefault();
    }

    $('#my-form').submit( processForm );
})(jQuery);

function getAllMovies(){
    $.ajax({
        url: 'https://localhost:44352/api/movie',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function( data, textStatus, jQxhr ){
            console.log(data);
            for(let i = 0; i < data.length; i++){
                $('#movies').append('<tr> <td>' + data[i].Title +' </td> <td>' + data[i].Genre +'</td> <td> ' + data[i].Director + ' </td> <td> <button onClick="updateMovie(' + data[i].MovieId + ')"> Update </button> </td> </tr>');
            }
        },
        error: function( jqXhr, textStatus, errorThrown ){
            console.log( errorThrown );
        }
    });

    }
$(document).ready(getAllMovies);
// $('#getmovies').submit( getAllMovies );
