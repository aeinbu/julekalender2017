
let n = 6;
while(n*4 != roundshift(n.toString()))
{
	n+=10;
}

console.log(n);
console.log("\nDone!");


function roundshift(s){
	let l = s.length;
	return s[l-1] + s.substr(0, l-1);
}


