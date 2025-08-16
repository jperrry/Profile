#!/bin/bash

#Random Password Generator

#Input validation function
get_integer(){
	local prompt="$1"	#First argument
	local -n integer="$2"	#Second argument
	local input		#Read user input value

	while true; do
		echo -n "$prompt"	#Echo first argument
		read input		#Read user input

	if [[ "$input" =~ ^[0-9]+$ ]]; then	#Integer input validation
	integer="$input"			#Assign user input to second argument
		return
	else
		echo "Invalid input. Enter an integer: "	#Error message if integer is not entered
	fi
done
}

#First prompt
get_integer "Enter the length of the password you want to generate: " password_length	#Call function, give two arguments

#Second prompt
get_integer "How many variations would you like to generate? " password_variations	#Reuse function, give two arguments

#Create for loop to run at least once
for x in $(seq "$password_variations");		#seq == password_variations value
do
	openssl rand -base64 48 | cut -c1-"$password_length"	#Call openssl, generate random value, decalre base64 encoding, pipe output, cut value from column 1 (first value) until user defined password length 
done

