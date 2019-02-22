function RemoveArray(array, attachId) {
	for (var i = 0, n = 0; i < array.length; i++) {
		if (array[i] != attachId) {
			array[n++] = array[i]
		}
	}
	array.length -= 1;
}
function containsArray(array, attachId) {
	for (var i = 0; i < array.length; i++) {
		if (array[i] == attachId) {
			return true;
			break;
		}
	}
	return false;
}
Array.prototype.remove = function(obj) {
	return RemoveArray(this, obj);
};
Array.prototype.contains = function(obj) {
	return containsArray(this, obj);
};

// 自定义组件
CheckBoxWithPage = function(selectId) {
	Ext.apply(this, selectId);

	CheckBoxWithPage.superclass.constructor.call(this);

}

var recordIds = new Array();// 选中的Record主键列id列表
var recordsChecked = new Array();// 选中的Record列表

// 扩展CheckboxSelectionModel组件
Ext.extend(CheckBoxWithPage, Ext.grid.CheckboxSelectionModel, {

			// 触发事件
			listeners : {
				// 取消选择
				"rowdeselect" : {
					fn : function(e, rowIndex, record) {
						var selectRecord = record.get(this.selectId);
						if (recordIds.contains(selectRecord)) {
							recordIds.remove(selectRecord);
							recordsChecked.remove(record);
						}

						var hd_checker = this.grid.getEl()
								.select('div.x-grid3-hd-checker');
						var hd = hd_checker.first();

						if (hd != null) {
							if (this.getCount() != this.grid.getStore()
									.getCount()) {
								// 清空表格头的checkBox
								if (hd.hasClass('x-grid3-hd-checker-on')) {
									hd.removeClass('x-grid3-hd-checker-on');
								}
							}
						}

					}
				},
				// 选择
				"rowselect" : {
					fn : function(e, rowIndex, record) {
						var selectRecord = record.get(this.selectId);
						if (!recordIds.contains(selectRecord)) {
							recordIds.push(selectRecord);
							recordsChecked.push(record);
						}

						var hd_checker = this.grid.getEl()
								.select('div.x-grid3-hd-checker');
						var hd = hd_checker.first();

						if (hd != null) {
							if (this.getCount() == this.grid.getStore()
									.getCount()) {
								hd.addClass('x-grid3-hd-checker-on');
							}
						}

					}
				}
			},

			getCurrentPageSelections : function() {
				alert(this.selections.items.length);
				return [].concat(this.selections.items);
			},

			// 重写取得选中的结果
			getSelections : function() {
				return recordsChecked;
			}

		});
