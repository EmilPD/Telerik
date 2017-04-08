function solve() {

	return function(selector, rows, columns) {
		var $selectedElement = $(selector);

		// <table class="spreadsheet-table">

        $('<table class="spreadsheet-table"></table>').appendTo($selectedElement);

	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if(typeof module !== 'undefined') {
	module.exports = solve;
}
