## JavaScript Shorthands

Some articles

Useful JavaScript Shorthand collection

https://medium.com/bits-and-pixels/javascript-shorthand-collection-part-1-203240c826b1

```JavaScript
1. If true … else Shorthand

Longhand:

var big;
if( x > 10 )
{
  big = true;
}
else
{
  big = false;
}

Shorthand:

var big = ( x > 10 ) ? true : false;

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


2. Null, Undefined, Empty Checks Shorthand

Longhand:

if( x !== null || x !== undefined || x !== "")
{
  var y = x;
}

Shorthand:

var y = x || "";

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

3. Object Array Notation Shorthand

Longhand:

var a = new Array();
a[0] = "myString1";
a[1] = "myString2";
a[2] = "myString3";

Shorthand:

var a = ["myString1", "myString2", "myString3"];

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

4. Associative Array Notation Shorthand

Longhand:

var skillSet = new Array();
skillSet['Document language'] = 'HTML5';
skillSet['Styling language'] = 'CSS3';
skillSet['Javascript library'] = 'jQuery';
skillSet['Other'] = 'Usability and accessibility';

Shorthand:

var skillSet = {
    'Document language' : 'HTML5',
    'Styling language' : 'CSS3',
    'Javascript library' : 'jQuery',
    'Other' : 'Usability and accessibility'
};

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

5. Declaring variables Shorthand

Longhand:

var x;
var y;
var z = 3;

Shorthand:

var x, y, z = 3;

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

6. Assignment Operators Shorthand

Longhand:

x=x+1;
minusCount = minusCount - 1;
y=y*10;

Shorthand:

x++;
minusCount --;
y*=10;

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


8. If Presence Shorthand

Longhand:

var a;
if ( a != true ) {
// do something...
}

Shorthand:

var a;
if ( !a ) {
// do something...
}

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

14. Switch Knightmare

Longhand:

switch (something) {

    case 1:
        doX();
    break;

    case 2:
        doY();
    break;

    case 3:
        doN();
    break;

    // And so on...

}

Shorthand:

var cases = {
    1: doX,
    2: doY,
    3: doN
};
if (cases[something]) {
    cases[something]();
}


>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

18. Lookup Tables Shorthand

Longhand:

if (type === 'aligator')
{
    aligatorBehavior();
}
else if (type === 'parrot')
{
    parrotBehavior();
}
else if (type === 'dolphin')
{
    dolphinBehavior();
}
else if (type === 'bulldog')
{
    bulldogBehavior();
}
else
{
    throw new Error('Invalid animal ' + type);
}

Shorthand:

var types = {
  aligator: aligatorBehavior,
  parrot: parrotBehavior,
  dolphin: dolphinBehavior,
  bulldog: bulldogBehavior
};

var func = types[type];
if (!func) throw new Error('Invalid animal ' + type); func();


>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

Short function calling:

Longhand:

function x() {console.log('x')};function y() {console.log('y')};
var z = 3;
if (z == 3) {
    x();
} else {
    y();
}

Shorthand:

function x() {console.log('x')};function y() {console.log('y')};var z = 3;
(z==3?x:y)(); // Short version!

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
```
