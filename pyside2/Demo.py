import sys
from PySide2.QtWidgets import QApplication, QMainWindow, QDialog, QMessageBox, QPushButton
from PySide2.QtUiTools import QUiLoader
from PySide2.QtCore import Qt
import math

class MyForm(QMainWindow):
  def __init__(self):
    super().__init__()
    self.window = QUiLoader().load('PTBH.ui')

    self.window.btnGiai.clicked.connect(self.giai)
    self.window.btnXoaRong.clicked.connect(self.xoaRong)
    self.window.btnThoat.clicked.connect(self.thoat)

    self.window.actionAbout.triggered.connect(self.showAboutDialog)

    self.window.show()

  def showAboutDialog(self):
    QMessageBox.information(self, self.tr("Thông tin"), self.tr(" Chương trình giải phương trình bậc 2\n Nguyễn Quang Huy\n 2019"), QMessageBox.Ok)

  def giai(self):
    try:
      a = int(self.window.txtNhapA.text())
      b = int(self.window.txtNhapB.text())
      c = int(self.window.txtNhapC.text())

      delta = b * b - 4 * a * c

      if a == 0:
        if b == 0:
          if c != 0:
            self.window.txtKetQua.setText("Phương trình vô nghiệm")
          elif c == 0:
            self.window.txtKetQua.setText("Phương trình vô số nghiệm")
        elif b != 0:
          x = (-c * 1.0) / b
          self.window.txtKetQua.setText("x = " + str(x))
      else:
        if delta < 0:
          self.window.txtKetQua.setText("Phương trình vô nghiệm")
        elif delta == 0:
          x = (-b * 1.0) / (2 * a)
          self.window.txtKetQua.setText("x = " + str(x))
        elif delta > 0:
          x1 = round((-b + math.sqrt(delta)) / (2 * a), 2)
          x2 = round((-b - math.sqrt(delta)) / (2 * a), 2)
          self.window.txtKetQua.setText("x1 = " + str(x1) + " ,x2 = " + str(x2))
    except:
      self.window.txtKetQua.setText("Không thể bỏ trống hoặc nhập chữ")

  def thoat(self):
    QApplication.exit()

  def xoaRong(self):
    self.window.txtNhapA.clear()
    self.window.txtNhapB.clear()
    self.window.txtNhapC.clear()
    self.window.txtKetQua.clear()

if __name__ == "__main__":
    app = QApplication(sys.argv)
    w = MyForm()
    sys.exit(app.exec_())
    