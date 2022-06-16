$( '.js-filter' ).on( 'click', function() {
  
    var $id = $(this).attr(`data-id`);
    
    if ( $id == 'all' ) {
      $( '.js-filterable' ).removeClass( 'is-hidden' );    
    } else {
      $( '.js-filterable' ).addClass( 'is-hidden' );
      $( '.js-filterable[data-color=' + $id + ']' ).removeClass( 'is-hidden' );
    }
    
  });