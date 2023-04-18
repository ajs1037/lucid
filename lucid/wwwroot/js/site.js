// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// toggle mobile slide out menu
function toggleMobileFullMenu ( visible )
{
	var fullMenu = $( ".masthead-fullmenu" );

	if ( visible == true )
	{
		fullMenu.removeClass( "offscreen" );
	}
	else
	{
		fullMenu.addClass( "offscreen" );
	}
}
