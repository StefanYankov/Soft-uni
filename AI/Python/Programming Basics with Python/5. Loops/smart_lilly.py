age = int(input())
washing_machine_price = float(input())
toy_price = int(input())

toy_count = 0
sum = 0

money = 0
brother_money = 0

for year in range(1, age+1):
    if year%2 == 0:
        money = money + 10
        sum += money
        brother_money += 1
    else:
        toy_count+= 1

sum = sum + toy_count*toy_price - brother_money
diff = abs(sum - washing_machine_price)

if sum >= washing_machine_price:
    print('Yes! {0:.2f}'.format(diff))
else:
    print('No! {0:.2f}'.format(diff))