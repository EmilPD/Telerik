/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {
		var books = [];
		var categories = [];
		var uniqueBookID;
		function listBooks(sortBy) {
			if(!sortBy) {
				return books;
			}

			if (books.map(x => x.category).indexOf(sortBy.category) >= 0) {
				return books.filter(x => x.category === sortBy.category);
			}
			if (books.map(x => x.author).indexOf(sortBy.author) >= 0) {
				return books.filter(x => x.author === sortBy.author);
			}
			if (books.map(x => x.category).indexOf(sortBy.category) < 0) {
				return [];
			}
			if (books.map(x => x.author).indexOf(sortBy.author) < 0) {
				return [];
			}
			
		}
		
		function listCategories() {
			return categories;
		}

		function addBook(book) {
			if (!book.title || book.title.length < 2 || book.title.length > 100) {
				throw 'Book Title must be between 2 and 100 chars long!';
			}
			if (books.map(x => x.title).indexOf(book.title) >= 0) {
				throw 'Book Title must be unique!';
			}
			if (!book.category || book.category.length < 2 || book.category.length > 100) {
				throw 'Book Category must be between 2 and 100 chars long!';
			}
			if (!book.author || book.author.length < 1) {
				throw 'Book Author must be any non-empty string!';
			}
			if (!book.isbn || book.isbn.length !== 10 && book.isbn.length !== 13) {
				throw 'Book ISBN must be either 10 or 13 digits!';
			}
			if (books.map(x => x.isbn).indexOf(book.isbn) >= 0 ) {
				throw 'Book ISBN must be unique!';
			}
			uniqueBookID = books.length + 2;
			book.ID = uniqueBookID;
			books.push(book);
			if (categories.indexOf(book.category) === -1) {
				categories.push(book.category);
			}
			return book;
		}


		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;


// testing library
// var book = {
//     title: 'the good parts',
//     isbn: '1234567890',
//     author: 'Crockford',
//     category: 'javascript'
// };

// var book1 = {
//     title: 'the art of unit testing',
//     isbn: '5456897456321',
//     author: 'Osherove',
//     category: 'c#'
// };

// var testCategory = {    
//     category: 'javascript'    
// };

// var testAuthor = {    
//     author: 'Osherove'    
// };

// var library = solve();
// library.books.add(book);
// library.books.add(book1);


// console.log(library.books.list(testAuthor));
// console.log(library.books.list(testCategory));
// console.log(library.categories.list());
// console.log(library.books.list());