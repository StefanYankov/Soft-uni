n = int(input())
odd_sum = 0
even_sum = 0

for number in range(1, n+1):
    current_number = int(input())
    if number % 2 == 0:
        even_sum += current_number
    else:
        odd_sum += current_number

if odd_sum == even_sum:
    print('Yes, sum = ' + str(odd_sum))
else:
    diff = abs(odd_sum - even_sum)
    print('No, diff = ' + str(diff))