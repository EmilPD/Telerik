/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {
	return function findPrimes(start, end) {
		if (Number.isNaN(Number(start)) || Number.isNaN(Number(end))) {
			throw 'error';
		}
		function isPrime(num) {
			var maxCheck = Math.sqrt(num);
			for(var i = 2; i < maxCheck; i += 1) {
				if(num % i === 0 && num !== i) {
					return false;
				}
			}
			return num > 1;
		};
		var sieve = [], i, j, primes = [];
		if (start < 2) {
			start = 2;
		}
		for (i = start; i <= end; i += 1) {
			if (!sieve[i] && isPrime(i)) {
				primes.push(i);
				for (j = i << 1; j <= end; j += i) {
					sieve[j] = true;
				}
			}
		}
		return primes;
	}
}

module.exports = solve;
