Public Class Form1



    Dim ALShooterRight As Boolean ' This Dim ALshooter right as Boolean 

    Dim ALShooterLeft As Boolean  ' This Dim ALshooter left as Boolean 

    Dim GunShotSpeed As Integer   ' This Dim the gunshot speed as Integer

    Dim ShooterSpeed As Integer = 1 ' This Dim the shooter speed as Integer 

    Dim ARight As Integer         ' This Dim the ALshooter to move right as Integer 

    Dim ASpeed As Integer         ' This Dim the AL shooter to move left as Integer 

    Dim ADrop As Integer          ' Declares ADrop as integer 

    Dim shotdown As Integer       ' Declares shotdown as integer 

    Dim MonstersA(numberofMonsters) As Boolean ' Declares the number of aliens as Boolean 

    Dim Monsters(numberofMonsters) As PictureBox ' This Declares the number of monsters as pictuerbox

    Const numberofMonsters As Integer = 10       ' This tells the game how much aliens should be in the game 

    Dim x As Integer                             ' Declare Dim x as integer 

    Dim level As Integer                         ' Declares Dim level as integer data type 

    Dim pause As Integer                         ' Declares pause as integer data type 

    Dim score As Integer                         ' Declares the score as integer data type 

This coding is to tell the shooter direction of whether to go left or right.



    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Right Then

            ALShooterRight = True ' Tells the ALShooter to move right 

            ALShooterLeft = False ' Tells the ALShooter to move left 

        End If

        If e.KeyValue = Keys.Left Then
        ALShooterLeft = True ' The shooter will move left 

            ALShooterRight = False ' The shooter will move right 

        End If

        If e.KeyValue = Keys.Space And picGunShot.Visible = False Then

            picGunShot.Top = picShooter.Top



            picGunShot.Left = picShooter.Left + (picShooter.Width / 2) - (picGunShot.Width / 2) ' This line here tells the bullets to be in line with the shooter 

            'Positioning the bullets on target 



            picGunShot.Visible = True

            picGunShot.Top -= GunShotSpeed

            ‘Move shots to the top of the form

        End If



        If picGunShot.Top + picGunShot.Height < Me.ClientRectangle.Top Then ' This will tell the game to keep in the frame of the form

            picGunShot.Visible = False ' this line tells the game when the bullet has reached the top to disappear 

        End If

    End Sub





    Private Sub TimerT_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerT.Tick



        moveALShooter() 'Function for the movement

        fireBuckShot() ' function to check if the bullet is firing 

        CheckGOver()    ' function to check when the game is over 

        MoveMonsters()   ' function for the aliens movement 

        CheckHit()       ' function to check that the bullet has hit the alien 

    End Sub



To allow the game to be paused:

Private Sub form1_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = "P" Or e.KeyChar = "P" Then

            TimerT.Enabled = True

            Paused = False

        End If

        If e.KeyChar = "e" Or e.KeyChar = "E" Then

            Me.Close()

        End If



    End Sub



This coding is used to control the direction the shooter can move in.

    Private Sub moveALShooter() ' This lin allows the shooter to move left or right '

        If ALShooterRight = True And picShooter.Left + picShooter.Width <

            Me.ClientRectangle.Width Then ' This line here tells the game to not leave the border of the game 

            picShooter.Left += ShooterSpeed ' This line tells the game to allow the shooter touch the border but not cross it '



        End If

        If ALShooterLeft = True And picShooter.Left > Me.ClientRectangle.Left Then ' This line tells the game to not allow the shooter leave the cross the border of the form 

            picShooter.Left -= ShooterSpeed
             End If

    End Sub



This coding the disables the shooter so it can only go left or right in the game.

    Private Sub frmSpaceAttack_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp



        If e.KeyValue = Keys.Right Then ' all of the instructions tell the game that the shooter cannot move vertically only horizontally'

            ALShooterRight = False

        End If

        If e.KeyValue = Keys.Left Then

            ALShooterLeft = False ' all these lines above disable the shooter from going up or down and this will only allow the ashooter to move left or right '

        End If

    End Sub

 Private Sub frmSpaceAttack_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load ' this line allows the form to load 

        LoadpicMonster() ' This is a set of rules for the aliens 

        LoadSettings() ' This is a set of rules that load the settings 

        Levels()       'This is a set of rules of the levels 

    End Sub



This coding controls the speed of the bullet and shooter.

    Private Sub LoadSettings() ' This is a set of rules to allow the bullets to load'

        ShooterSpeed = 6 ' this will tell the game that the value of the speed of the bullet is 6

        GunShotSpeed = 3 ' this will tell the game that the value of the speed of the bullet is 3

        picGunShot.Visible = False ' shows when the bullet is visible 



        For Me.x = 1 To numberofMonsters ' This loops all aliens 



        Next

        ASpeed = 3

        ADrop = 50

        GunShotSpeed = 20 ' this tells the game the speed of the gunshot’

        ALShooterLeft = False ' this will allow the shooter to not move when nothing has been pressed 

        ALShooterRight = False ' this will allow the shooter to not move when nothing has been pressed 

        shotdown = 0 ' the score of the aliens start at 0

        TimerT.Enabled = True ' This line here means when the settings have loaded the game will then begin



    End Sub

This coding controls the number of aliens shown in the game.



    Private Sub MoveMonsters() ' Tells the alien to move left or right '

        For Me.x = 1 To numberofMonsters ' this is a loop to make x a value 



            If MonstersA(x) = True Then ' this makes the alien come from the top left side

                Monsters(x).Left += ASpeed ' this makes the aliens go in the right direction 

            Else

                Monsters(x).Left -= ASpeed ' This wont allow the aliens to go left 

            End If

            If Monsters(x).Left + Monsters(x).Width > Me.ClientRectangle.Width And MonstersA(x) = True Then ' this tells the aliens not to go more than the border 
            MonstersA(x) = False ' this stops the aliens in from going right and makes them begin form the left

                Monsters(x).Top += ADrop ' when the alien has touched the border it will drop down one line 

            End If



            If Monsters(x).Left < Me.ClientRectangle.Left And MonstersA(x) = False Then ' this line here tells the aliens not to go more then the border 



                MonstersA(x) = True 'this makes the aliens go in the right direction 

                Monsters(x).Top += ADrop ' this line instructs the aliens to drop down one line 



            End If

        Next



    End Sub

This coding controls the direction of the bullet.

    Private Sub CheckHit() ' This is a set of rules that declares that the shooter should hit the alien 

        For Me.x = 1 To numberofMonsters





            If (picGunShot.Top + picGunShot.Height >= Monsters(x).Top) And

                (picGunShot.Top <= Monsters(x).Top + Monsters(x).Height) And

                (picGunShot.Left + picGunShot.Width >= Monsters(x).Left) And

                (picGunShot.Left <= Monsters(x).Left + Monsters(x).Width) And

                picGunShot.Visible = True And

                Monsters(x).Visible = True Then ' all these instructions tell the game that once the bullet hits any part of the alien then the alien will disappear 

                Monsters(x).Visible = False ' when hit the alien will automatically disappear 



                picGunShot.Visible = False



                shotdown += 1 ' This instruction will add on to the score each time an alien is hit



                lblScore.Text = "Score of:" & shotdown ' This is the instructions labelled for the score 

            End If

        Next

    End Sub

The here loads all the monsters that are going into the game 

    Private Sub LoadpicMonster() ' This line allows the game to load all the aliens '

        Monsters(1) = picMonster ' This line loads monster 1

        Monsters(2) = picMonster1 'This line loads monster 2

        Monsters(3) = picMonster2 ' This line loads monster 3

        Monsters(4) = picMonster3 ' This line loads monster 4

        Monsters(5) = picMonster4 ' This line loads monster 5

        Monsters(6) = picMonster5 ' This line loads monster 6

        Monsters(7) = picMonster6 ' This line loads monster 7

        Monsters(8) = picMonster7 ' This line loads monster 8

        Monsters(9) = picMonster8 ' This line loads monster 9

        Monsters(10) = picMonster9 ' This line loads monster 10

        For Me.x = 1 To numberofMonsters

            MonstersA(x) = True ' This loop will direct the aliens from left to right 

            Monsters(x).Left = (-50 * x) - (x * 5) ' This will tell the alien not to overlap 

            Monsters(x).Top = 0 ' This line here allows the aliens to stay in the top line 

            Monsters(x).Visible = True ' This line instructs to the game that the aliens should be visible 

        Next
        End Sub



This coding checks over the game to make sure that the game has been executed properly 

    Private Sub CheckGOver() ' This tells the game to execute the rules 

        For Me.x = 1 To numberofMonsters ' This is a loop for the value x 



        Next

        If picMonster.Top + picMonster.Height >= picShooter.Top And picMonster.Visible = True Then

            TimerT.Enabled = False

            Me.x = numberofMonsters



            MsgBox("game over") ' This message will be displayed when the game is over 

            Playagain()

        End If



        If shotdown = numberofMonsters Then

            TimerT.Enabled = False ' This tells the game to continue to run



            If pause = False Then

            End If



            MsgBox("Congratulations You Win!") ' This message will be displayed when the all the aliens are dead 

            picGunShot.Visible = False

            Playagain()

        End If

    End Sub





    Private Sub fireBuckShot()

        If picGunShot.Visible = True Then

            picGunShot.Top -= ShooterSpeed 'move shots to the top of the form

        End If

        If picGunShot.Top + picGunShot.Height < Me.ClientRectangle.Top Then

            picGunShot.Visible = False ' The shooter will appear visible in the game 



        End If

    End Sub

This coding is for the levelling up of the game.

    Private Sub Levels()

        level = level + 1

        If level = 1 Then

            LoadpicMonster() ' This tells the game to load all the aliens 

            lblLevel.Text = "level" & level

            GunShotSpeed += 8 ' This line here incerase the bullet speed with each level 

            ASpeed = ASpeed + 2 ' The alien speed will incerase with each level 

            ADrop = ADrop + 2  ' The alien drop speed incerases with each level 

        End If

        If level = 2 Then

            LoadpicMonster() ' This tells the game to load all the aliens 

            lblLevel.Text = "level" & level

            GunShotSpeed += 10 ' This line here incerase the bullet speed with each level

            ASpeed = ASpeed + 3 ' The alien speed will incerase with each level 

            ADrop = ADrop + 3 ' The alien drop speed incerases with each level 

        End If

        If level = 3 Then
        LoadpicMonster() ' This tells the game to load all the aliens 

            lblLevel.Text = "level" & level

            GunShotSpeed += 10 ' This line here incerase the bullet speed with each level

            ASpeed = ASpeed + 4 ' The alien speed will incerase with each level

            ADrop = ADrop + 4   ' The alien drop speed incerases with each level 

        End If

  Private Sub btnQ_Click(sender As System.Object, e As System.EventArgs) Handles btnQ.Click

        Me.Close()

    End Sub

End Class

    End Sub

This is code allows the game to play again 

    Private Sub Playagain()

        Dim Results = MsgBox("play Again", MsgBoxStyle.YesNo) ' This line will allow a message to appear on the screen '

        If Results = MsgBoxResult.Yes Then

            LoadSettings() ' This line here loads the levels 

            Levels() ' function for the level 

            LoadpicMonster()

        Else

            Me.Close() ' This closes the window 

        End If

    End Sub ' This line here tells the code to private sub 



End Class