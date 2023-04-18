//<script type="text/javascript" src="/cdn-js/ui-effect-navbar.js"></script>

//This will be true / false depending on the page width.
var navbarFadeEnabled = true;

// adds on "onload" hook to the window.onload function chain
var oldonload = window.onload;
window.onload = (typeof window.onload != 'function') ?
  handleOnLoad : function() { 
   oldonload(); handleOnLoad();
};

function handleOnLoad() {
  // setup a callback for when the media query triggers
  // CU: Temporarily disabling
  //const mq = window.matchMedia( "(min-width: 800px)" );
  //mq.addListener( navbarQueryTriggered );
  
  //navbarQueryTriggered( mq );
}

$(document).scroll( function() {
	
	// anytime the browser is resized or scrolled, 
	// we need to update the positioning of the nav bars
   if( navbarFadeEnabled ) {
      updateNavbarForScroll( );
   }
});

$(window).resize(function() {
	
	// anytime the browser is resized or scrolled, 
	// we need to update the positioning of the nav bars
	if( navbarFadeEnabled ) {
      updateNavbarForScroll( );
   }
});

function navbarQueryTriggered( mediaQuery ) {
	
   // we want to know if the browser is within our "desktop size" media query.
   // if so, enable the navbar fade effect. If not, we'll turn it off
	if( mediaQuery.matches ) {
		toggleNavbarEffect( true );
	}
	else {
		toggleNavbarEffect( false );
	}
}

function toggleNavbarEffect( enabled ) {
	navbarFadeEnabled = enabled;
	
   // whenever we turn it off, force the background to black.
	if( navbarFadeEnabled == false ) {
		var navBar = $(".masthead");
      navBar.css( "background-color", "rgba( 0, 0, 0, 1 )" );
      var dropdown = $(".navigation-primary-dropdown-content");
		dropdown.css( "background-color", "rgba( 0, 0, 0, 1 )" );
	}
   else {
      // otherwise, let it update according to where the page is scrolled
      updateNavbarForScroll( );
   }
}

function updateNavbarForScroll( ) {
   // first get the navbar
   var navBar = $(".masthead");

   // get the primary navigation dropdown
   var dropdown = $(".navigation-primary-dropdown-content");

   var windowPos = $(window).scrollTop();

   // get the height of the navbar
   var navbarHeight = navBar.outerHeight( );
          
   // take the distance from the windowPos TO the end of the navbar (since the navbar is at 0 we can just use its height)
   var deltaPos = Math.max( navbarHeight - windowPos, 0 );
   
   // invert alpha so its transparent when we aren't scrolled
   var alpha = 1.0 - (deltaPos / navbarHeight);

   navBar.css( "background-color", 'rgba( 0, 0, 0,' +  alpha + ')' );

   dropdown.css( "background-color", 'rgba( 0, 0, 0,' +  alpha + ')' );
}
//
