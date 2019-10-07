n = int(input())
max_number = -9223372036854775807

for number in range (1, n+1):
    input_number = int(input())
    if input_number > max_number:
        max_number = input_number

print(max_number)