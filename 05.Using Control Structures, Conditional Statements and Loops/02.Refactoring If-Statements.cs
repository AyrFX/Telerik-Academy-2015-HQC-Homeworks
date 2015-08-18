Potato potato;
//... 
if (potato == null) {
	throw new ArgumentNullException();
}
if(!potato.IsRotten && potato.HasBeenPeeled)
{
	Cook(potato);
}

//================

if (!shouldVisitCell && (MIN_X <= x && x <= MAX_X) && (MIN_Y <= y && y <= MAX_Y)) {
	VisitCell();
}