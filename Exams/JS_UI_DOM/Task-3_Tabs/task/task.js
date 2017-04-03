function solve() {
	// return 'Your template';

	var template = [
            '<div class="tabs-control">',
            	'<ul class="list list-titles">',
					'{{#titles}}',
						'<li class="list-item">',
                    		'<label for="{{link}}" class="title">{{text}}</label>',
                		'</li>',
					'{{/titles}}',
				'</ul>',
				'<ul class="list list-contents">',
					'{{#contents}}',
						'<li class="list-item">',
							'<input class="tab-content-toggle" id="{{link}}" name="tab-toggles" type="radio">',
							'<div class="content">',
								'{{{text}}}',
							'</div>',
						'</li>',
					'{{/contents}}',
				'</ul>',
            '</div>'
        ].join('\n');

	return template;
}

if(typeof module !== 'undefined') {
	module.exports = solve;
}

var data = {
	titles: [{
		text: "Tab 1",
		link: "tab-1"
	}, {
		text: "Tab 2",
		link: "tab-2"
	}, {
		text: "Tab 3",
		link: "tab-3"
	}],
	contents: [{
		link: "tab-1",
		text: "Tab 1, no so special...",
	}, {
		link: "tab-2",
		text: "<p>Some text in a p</p><a href=\"#\">a link</a>",
	}, {
		link: "tab-3",
		text: "<strong>And a list</strong><ul><li>Just</li><li>a</li><li>regular</li><li>list</li></ul>"
	}]
};

                <li class="list-item">

                    <input class="tab-content-toggle" id="tab-1" name="tab-toggles" checked="checked/" type="radio">
                    <div class="content">
                        Tab 1, no so special...
                    </div>
                </li>
                <li class="list-item">
                    <input class="tab-content-toggle" id="tab-2" name="tab-toggles" type="radio">
                    <div class="content">
                        <p>Some text in a p</p><a href="#">a link</a>
                    </div>
                </li>
                <li class="list-item">
                    <input class="tab-content-toggle" id="tab-3" name="tab-toggles" type="radio">
                    <div class="content">
                        <strong>And a list</strong>
                        <ul>
                            <li>Just</li>
                            <li>a</li>
                            <li>regular</li>
                            <li>list</li>
                        </ul>
                    </div>
                </li>
            </ul>