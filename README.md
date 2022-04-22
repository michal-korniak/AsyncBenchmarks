# Fibonacci benchmark

Fibonacci number to be calculated: 7

Number of retries: 1000

* Sync benchmark: 0,1657 ms
* Task.CompletedTask benchmark: 2,8084 ms
* Task.Yield() benchmark: 1036,2944 ms
* Task.Run() benchmark: 1562,6824 ms

# Sigma benchmark

Sigma number to be calculated: 10000

Number of retries: 10000

* Sync benchmark: 78,4899 ms
* Task.FromResult benchmark: 92,657 ms
* Task.CompletedTask benchmark: 191,5219 ms
* Task.Yield() benchmark: 1120,073 ms
* Task.Run() benchmark: 924,0923 ms
