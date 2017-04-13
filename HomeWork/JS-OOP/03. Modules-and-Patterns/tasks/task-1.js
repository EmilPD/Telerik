/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
	let Course = {

		init: function(title, presentations) {
      if (!title || title.length === 0 || title.search(/^[ ]|\s$|\s\s/g) >= 0) {
        throw 'Invalid Title!';
      }
      if (!presentations || presentations.length < 1) {
        throw 'There are no presentations!';
      }
      presentations.forEach(function(item) {
        if (!item || item.search(/^[ ]|\s$|\s\s/g) >= 0) {
          throw 'There are spaces in presentations title!';
        }
      });
      this.homeworks = [];
      this.examResults;
      this.studentsList = [];
      this.title = title;
      this.presentations = presentations;

      return this;
		},

		addStudent: function(name) {
      let firstName,
          lastName;

      if (!name || name.search(/^[A-Z][a-z]*\s[A-Z][a-z]*$/g) === -1) {
        throw 'Invalid Student Name!';
      }
      
      firstName = name.split(' ')[0];
      lastName = name.split(' ')[1];

      let studentID = this.studentsList.length + 1;
      let student = {
            firstname: firstName, 
            lastname: lastName, 
            id: studentID
      };
 
      this.studentsList.push(student);

      return studentID;
		},

		getAllStudents: function() {

      return this.studentsList;
		},

		submitHomework: function(studentID, homeworkID) {
      if (!studentID || studentID < 1 || studentID > this.studentsList.length || studentID % 1 !== 0 ) {
          throw 'StudentID is incorrect!';
      }
      if (!homeworkID || homeworkID < 1 || homeworkID > this.presentations.length || homeworkID % 1 !== 0 ) {
          throw 'homeworkID is incorrect!';
      }

      let studentHomework = {studentID, homeworkID};
      this.homeworks.push(studentHomework);
		},

		pushExamResults: function(results) {
      if (!results || !results.length || typeof results === 'string') {
        throw 'invalid results!';
      }
      for (var i = 0; i < results.length; i += 1) {
        if (!results[i].StudentID || Number.isNaN(Number(results[i].StudentID))) {
          throw 'StudentID is NaN!';
        }
        if (typeof results[i].score === 'undefined' || !results[i].score || Number.isNaN(Number(results[i].score))) {
          throw new Error('no score given for a student');
        }
        if (results[i].StudentID < results[0].StudentID 
          || results[i].StudentID > this.studentsList.length) {
          throw 'StudentID is Invalid!';
        }
        let resultArr = results.map(function(student){ return student.StudentID });
        let isDuplicate = resultArr.some(function(StudentID, idx){ 
            return resultArr.indexOf(StudentID) != idx;
        });
        if (isDuplicate) {
          throw 'Same Student twice!';
        }
        
        this.examResults = results;
      }
    },

		getTopStudents: function() {
		}
	};

	return Course;
}

module.exports = solve;