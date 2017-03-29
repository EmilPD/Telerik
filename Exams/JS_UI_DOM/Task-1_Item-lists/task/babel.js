'use strict';

function solve() {

	return function (selector, defaultLeft, defaultRight) {

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
		addInput.id = 'add-input';

		var button = document.createElement('button');
		button.innerHTML = 'Add';
		button.addEventListener('click', addButtonClicked, false);

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
			var inputValue = input.value.trim();
			newLi.innerHTML = inputValue;

			var img = document.createElement('img');
			img.className = 'delete';
			img.src = 'imgs/Remove-icon.png';
			img.addEventListener('click', deleteElement, false);

			newLi.appendChild(img);
			if (input.value.length > 0) {
				if (inputSelectLeft.checked) {
					olLeft.appendChild(newLi);
				} else {
					olRight.appendChild(newLi);
				}
			}
		}

		var deleteElementSelector = document.getElementsByClassName('delete');

		for (var i = 0, len = deleteElementSelector.length; i < len; i += 1) {
			deleteElementSelector[i].addEventListener('click', deleteElement, false);
		}

		function deleteElement(ev) {
			this.parentElement.parentElement.removeChild(this.parentElement);
			addInput.value = this.parentElement.innerText;
		}
	};
}