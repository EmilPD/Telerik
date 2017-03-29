// function solve() {
// 	const deleteClassName = 'delete';

// 	const appendEntry = (function() {
// 		const liEntry = document.createElement('li');
// 		liEntry.className = 'entry';

// 		const deleteIcon = document.createElement('img');
// 		deleteIcon.className = deleteClassName;
// 		deleteIcon.src = 'imgs/Remove-icon.png';

// 		liEntry.appendChild(deleteIcon);

// 		return function(el, text) {
// 			const entry = liEntry.cloneNode(true);
// 			entry.className = 'entry';

// 			const textEl = document.createTextNode(text);
// 			entry.appendChild(textEl);

// 			el.appendChild(entry);
// 		};
// 	}());

// 	return function(selector, defaultLeft, defaultRight) {
// 		defaultLeft = defaultLeft || [];
// 		defaultRight = defaultRight || [];

// 		const leftRadio = document.createElement('input');
// 		leftRadio.type = 'radio';
// 		leftRadio.name = 'column-select';

// 		// Not required, just for convenience
// 		const leftLabel = document.createElement('label');
// 		leftLabel.innerHTML = 'Add here';

// 		const leftList = document.createElement('ol');

// 		const leftColumn = document.createElement('div');
// 		leftColumn.className = 'column';

// 		const heading = document.createElement('div');
// 		heading.className = 'select';

// 		heading.appendChild(leftRadio);
// 		heading.appendChild(leftLabel);
// 		leftColumn.appendChild(heading);
// 		leftColumn.appendChild(leftList);

// 		const rightColumn = leftColumn.cloneNode(true);
// 		const rightList = rightColumn.querySelector('ol');
// 		const rightLabel = rightColumn.querySelector('label');
// 		const rightRadio = rightColumn.querySelector('input');

// 		leftRadio.checked = true;
// 		leftRadio.id = 'select-left-column';
// 		rightRadio.id = 'select-right-column';

// 		leftLabel.htmlFor = leftRadio.id;
// 		rightLabel.htmlFor = rightRadio.id;

// 		const columns = document.createElement('div');
// 		columns.className = 'column-container';
// 		columns.appendChild(leftColumn);
// 		columns.appendChild(rightColumn);

// 		const input = document.createElement('input');

// 		defaultLeft.forEach(x => appendEntry(leftList, x));
// 		defaultRight.forEach(x => appendEntry(rightList, x));

// 		input.size = 40;
// 		input.autofocus = true;

// 		const button = document.createElement('button');
// 		button.innerHTML = 'Add';

// 		const root = document.createDocumentFragment();
// 		root.appendChild(columns);
// 		root.appendChild(input);
// 		root.appendChild(button);

// 		// append to real root
// 		let realRoot = document.querySelector(selector);
// 		realRoot.innerHTML = '';
// 		realRoot.appendChild(root);

// 		function putEntry() {
// 			const text = input.value.trim();
// 			if(text !== '') {
// 				input.value = '';
// 				appendEntry((leftRadio.checked ? leftList : rightList), text);
// 			}
// 		}

// 		button.addEventListener('click', putEntry);
// 		input.addEventListener('keypress', function(ev) {
// 			// Not required, just for convenience
// 			if(ev.key === 'Enter') {
// 				putEntry();
// 			}
// 		});

// 		columns.addEventListener('click', function(ev) {
// 			if(ev.target.className.indexOf(deleteClassName) >= 0) {
// 				const entry = ev.target.parentNode;
// 				input.value = entry.childNodes[1].textContent;
// 				entry.parentNode.removeChild(entry);
// 			}
// 		});
// 	};
// }

// // SUBMIT THE CODE ABOVE THIS LINE

// if(typeof module !== 'undefined') {
// 	module.exports = solve;
// }


function solve() {

	return function(selector, defaultLeft, defaultRight) {

		var selectedElement = document.querySelector(selector);

		var leftColumnArray = defaultLeft || [];
		var rightColumnArray = defaultRight || [];

		var columnContainer = document.createElement('div');
		columnContainer.className = 'column-container';

		// Left Column
		var divColumnLeft = document.createElement('div');
		divColumnLeft.className = 'column';
		
		var divSelectLeft = document.createElement('div');
		divSelectLeft.className = 'select';
		
		var inputSelectLeft = document.createElement('input');
		inputSelectLeft.setAttribute('type', 'radio');
		inputSelectLeft.setAttribute('name', 'column-select');
		inputSelectLeft.id = 'select-left-column';
		inputSelectLeft.checked = true;

		var labelSelectLeft = document.createElement('label');
		labelSelectLeft.setAttribute('for', 'select-left-column');
		labelSelectLeft.innerHTML = 'Add here';

		divSelectLeft.appendChild(inputSelectLeft);
		divSelectLeft.appendChild(labelSelectLeft);

		var olLeft = document.createElement('ol');

		for (var i = 0, len = leftColumnArray.length; i < len; i += 1) {
			var li = document.createElement('li');
			li.className = 'entry';
			li.innerHTML = leftColumnArray[i];

			var img = document.createElement('img');
			img.className = 'delete';
			img.src = 'imgs/Remove-icon.png';

			li.appendChild(img);
			olLeft.appendChild(li);
		}

		divColumnLeft.appendChild(divSelectLeft);
		divColumnLeft.appendChild(olLeft);

		// Right Column
		var divColumnRight = document.createElement('div');
		divColumnRight.className = 'column';

		var divSelectRight = document.createElement('div');
		divSelectRight.className = 'select';
		
		var inputSelectRight = document.createElement('input');
		inputSelectRight.setAttribute('type', 'radio');
		inputSelectRight.setAttribute('name', 'column-select');
		inputSelectRight.id = 'select-right-column';

		var labelSelectRight = document.createElement('label');
		labelSelectRight.setAttribute('for', 'select-right-column');
		labelSelectRight.innerHTML = 'Add here';

		divSelectRight.appendChild(inputSelectRight);
		divSelectRight.appendChild(labelSelectRight);

		var olRight = document.createElement('ol');

		for (var i = 0, len = rightColumnArray.length; i < len; i += 1) {
			var li = document.createElement('li');
			li.className = 'entry';
			li.innerHTML = rightColumnArray[i];

			var img = document.createElement('img');
			img.className = 'delete';
			img.src = 'imgs/Remove-icon.png';

			li.appendChild(img);
			olRight.appendChild(li);
		}

		divColumnRight.appendChild(divSelectRight);
		divColumnRight.appendChild(olRight);

		var addInput = document.createElement('input');
		

		var button = document.createElement('button');
		button.innerHTML = 'Add';
		button.addEventListener('click', addButtonClicked);


		// Appending to main div
		columnContainer.appendChild(divColumnLeft);
		columnContainer.appendChild(divColumnRight);

		selectedElement.appendChild(columnContainer);
		selectedElement.appendChild(addInput);
		selectedElement.appendChild(button);

		function addButtonClicked() {
			var input = document.getElementById('add-input');
			var newLi = document.createElement('li');
			newLi.className = 'entry';
			var inputValue = addInput.value.trim();
			newLi.innerHTML = inputValue;
			
			var img = document.createElement('img');
			img.className = 'delete';
			img.src = 'imgs/Remove-icon.png';
			img.addEventListener('click', deleteElement);

			newLi.appendChild(img);
			if (addInput.value.length > 0 && addInput.value.trim()) {
				if (inputSelectLeft.checked) {
					olLeft.appendChild(newLi);
				}
				else {
					olRight.appendChild(newLi);
				}
				addInput.value = '';
			}
		}

		var deleteElementSelector = document.getElementsByClassName('delete');

		for (var i = 0, len = deleteElementSelector.length; i < len; i += 1) {
			deleteElementSelector[i].addEventListener('click', deleteElement);
		}
		
		function deleteElement(ev) {
			addInput.value = this.parentElement.innerText;
			this.parentElement.parentElement.removeChild(this.parentElement);
		}

	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if(typeof module !== 'undefined') {
	module.exports = solve;
}
