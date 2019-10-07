n = int(input())
min_number = 9223372036854775807

for number in range (1, n+1):
    input_number = int(input())
    if input_number < min_number:
        min_number = input_number

print(min_number)