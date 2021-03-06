### 1. Непонятный/нечитабельный код
#### В проекте код написан достаточно просто, проблем с пониманием кода на данном этапе разработки не имеется. Рефакторинг для улучшения понимания кода производился сразу после проверки его работы
![image alt](https://github.com/ViachaslauS/QJoin/blob/master/UX/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA.JPG)
### 2. Дублирующийся код
#### В ходе разработки мы проектировали код таким образом, чтобы повторяющихся элементов не было, или они были в минимальном количестве. Несмотря на это, будет производится дальнейшее изучение кода для поиска таких проблем.
### 3. Отсутствие автоматизации (тестов, сборки, развёртывания)
#### В проекте отсутствуют тесты, но они необходимы для проверки правильности работы сервера, поэтому имеется необходимость их написания.
### 4. Запутанная архитектура и ненужные сложные зависимости
#### Архитектура и зависимости построены в соответствии с планом их составления, но также необходимо следить за их усложнением и не допускать проблем, ухудшающих структуру программы.
### 5. Медленные / неэффективные средства
#### Используются доступные средства разработки. 
### 6. Незакоммиченый код / долгоживущие ветки
#### Код постоянно комититься, ветки не создаются за ненадобностью.
### 7. Отсутствие / несоответствие технической документации
#### Документация по проекту отсутствует, но ее необходимо добавлять
### 8. Отсутствие тестовой среды
#### Тестовая среда имеется в программе, однако мы не создавали в ней тесты.
### 9. Длинные циклы интеграции / отсутствие непрерывной интеграции
#### Интеграция в проекте производится постоянно, проблем или отставаний не имеется.

### План устранения
Главными проблемами в приложении являются отсутствие тестов и документации. Документацию необходимо вводить постоянно в ходе разработки, из-за чего на данный момент необходимо пристановить разработку новых модулей и реализовать документацию по имеющимся. Далее вести документацию вместе с написанием кода.
Написание тестов необходимо реализовать только для определенных модулей, которые на данный момент тестируются без использования специализированных тестов. Это необходимо изменить для улучшения тестирования в программе.

### Необходимость
Наличие документации и тестов очень важная часть разработки, поэтому задача устранения этого долга является высокоприоритетной и для нее необходимо уделить отдельное внимание. Дальнейшая разработка без решения данной проблемы приведет к тяжелым последствиям в будущей разработке.
